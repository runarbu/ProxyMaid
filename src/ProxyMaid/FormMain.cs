using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Diagnostics;



namespace ProxyMaid
{
    public partial class FormMain : Form
    {

        private volatile Globals Global;

        private ProxySourceScraper LeadsScraperObject;
        private Thread LeadsScraperThread = null;
        private ProxyOutToFile ProxyOutToFileObject;
        private Thread ProxyOutToFileThread = null;

        public FormMain()
        {
            InitializeComponent();

            Global = new Globals(this, textBox1);

            // Setup the data grid that shows found proxies
            dataGridView1.AutoGenerateColumns = false;

            string[] columbsProxiesServers = { "Ip:100", "Port:50", "Anonymity:100", "Checked:100", "Status:100", "Source:100" };
            foreach (string columb in columbsProxiesServers)
            {
                DataGridViewTextBoxColumn makeColumn = new DataGridViewTextBoxColumn();
                makeColumn.DataPropertyName = columb.Split(':')[0];
                makeColumn.HeaderText = columb.Split(':')[0];
                makeColumn.Width = Int32.Parse(columb.Split(':')[1]);
                
                dataGridView1.Columns.Add(makeColumn);
            }
        
            dataGridView1.DataSource = Global.ProxyServers;

            // Setup the data grid that shows proxy sources
            dataGridViewProxySources.AutoGenerateColumns = false;

            string[] columbsProxiesSources = { "Url:100", "Proxies:100", "Working:100", "Bad:100", "Interval:100" };
            foreach (string columb in columbsProxiesSources)
            {
                DataGridViewTextBoxColumn makeColumn = new DataGridViewTextBoxColumn();
                makeColumn.DataPropertyName = columb.Split(':')[0];
                makeColumn.HeaderText = columb.Split(':')[0];
                makeColumn.Width = Int32.Parse(columb.Split(':')[1]);

                dataGridViewProxySources.Columns.Add(makeColumn);
            }

            // Setup the use button
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            dataGridViewProxySources.Columns.Add(btn);
           
            btn.Text = "Use";
            btn.Name = "Use";
            
            btn.UseColumnTextForButtonValue = false;

            // Set the data source for the dataGrid showing proxy sources
            dataGridViewProxySources.DataSource = Global.ProxySources;

            // Set minimum anonymity
            comboBoxProxyMinAnonymity.SelectedIndex = comboBoxProxyMinAnonymity.FindStringExact(Properties.Settings.Default.ProxyMinAnonymity);

            trackBar1.Value = 10;
            // ToDo: Load old proxies from the out file


        }

        

        private void button1_Click(object sender, EventArgs e)
        {

            if (buttonStartStop.Text == "Start")
            {
                buttonStartStop.Text = "Stop";



                // Start the LeadsScraper thread
                {
                    LeadsScraperObject = new ProxySourceScraper(this, Global);
                    LeadsScraperThread = new Thread(LeadsScraperObject.DoWork);

                    LeadsScraperThread.IsBackground = true;
                    LeadsScraperThread.Start();
                   
                    
                }
                
                // Start the out file thread
                {
                    ProxyOutToFileObject = new ProxyOutToFile(this, Global, labelOutFileTime, labelProxyOutFilePath);
                    ProxyOutToFileThread = new Thread(ProxyOutToFileObject.DoWork);

                    ProxyOutToFileThread.Start();
                }

                // Tell other threds that we are runnig
                Global.running = true;
            }
            else 
            {
                buttonStartStop.Text = "Start";

                LeadsScraperObject.StopWork();
                ProxyOutToFileObject.StopWork();

                // Tell other threds that we are not runnig
                Global.running = false;

            }
            
             
        }

        

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            label1.Text = trackBar1.Value.ToString();
            Global.ProxyCheckerThreadsWantSet( trackBar1.Value );

            // Start the ProxyChecker threads
            while (Global.ProxyCheckerCreate()) {
                
                ProxyChecker ProxyCheckerObject = new ProxyChecker(this, Global);
                Thread ProxyCheckerThread = new Thread(ProxyCheckerObject.DoWork);

                ProxyCheckerThread.IsBackground = true;
                ProxyCheckerThread.Start();

            }
        }

        

        private void setingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSettings fms = new FormSettings();
            fms.Show();
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            // Displays a SaveFileDialog so the user can change the out file
           SaveFileDialog saveFileDialogOutFile = new SaveFileDialog();
           saveFileDialogOutFile.Filter = "Text file|*.txt";
           saveFileDialogOutFile.Title = "Save proxy servers";
           saveFileDialogOutFile.ShowDialog();

           // If the file name is not an empty string open it for saving.
           if (saveFileDialogOutFile.FileName != "")
           {
               Properties.Settings.Default.ProxyOutFile = saveFileDialogOutFile.FileName;
               Properties.Settings.Default.Save();

               labelProxyOutFilePath.Text = saveFileDialogOutFile.FileName;
           }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonOutFileOpen_Click(object sender, EventArgs e)
        {
            Process.Start("notepad.exe", Global.ProxyOutFilePath());
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ProxyMinAnonymity = comboBoxProxyMinAnonymity.SelectedItem.ToString();
            Properties.Settings.Default.Save();
        }

        private void addProxiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddProxySource fms = new FormAddProxySource(this, Global);
            fms.Show();
        }

        private void saveWorkinProxiesSourcesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveProxySource(true);
        }

        private void SaveProxySource(bool onlyWorking)
        {

            // Displays a SaveFileDialog so the user can change the out file
            SaveFileDialog saveFileDialogOutFile = new SaveFileDialog();
            saveFileDialogOutFile.Filter = "Text file|*.txt";
            saveFileDialogOutFile.Title = "Save proxy servers";
            saveFileDialogOutFile.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (saveFileDialogOutFile.FileName != "")
            {


                System.IO.StreamWriter file = null;
                try
                {
                    file = new System.IO.StreamWriter(saveFileDialogOutFile.FileName);

                    foreach (ProxySource source in Global.ProxySources)
                    {
                        if (source.Use == false)
                        {
                            continue;
                        }

                        if ((onlyWorking && source.Working > 0) || onlyWorking == false)
                        {
                            file.WriteLine(source.Url);
                        }
                        
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Can not save file: " + ex.Message,
                    "Important Note",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);
                }
                finally
                {
                    file.Close();
                }
            }

        }

        private void saveAllProxiesSourcesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveProxySource(false);
        }

        private void dataGridViewProxySources_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.ColumnIndex == 5)
            {
                if (dataGridViewProxySources.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == "Stop")
                {
                    Global.ProxySources.First(s => s.Url == dataGridViewProxySources.Rows[e.RowIndex].Cells[0].Value.ToString()).Use = false;
                    dataGridViewProxySources.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "Start";
                }
                else {
                    Global.ProxySources.First(s => s.Url == dataGridViewProxySources.Rows[e.RowIndex].Cells[0].Value.ToString()).Use = true;
                    dataGridViewProxySources.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "Stop";
                }

            }
        }



        private void dataGridViewProxySources_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            // Set the name of the button.
            // Unfortunately this is some buggy shit where dataGridViewProxySources_RowsAdded() get called when dataGridViewProxySources 
            // gets created also. Test to see if we actually have any proxy servers in ProxySources to get around that...
            if (Global.ProxySources.Count != 0)
            { 
                dataGridViewProxySources.Rows[e.RowIndex].Cells[5].Value = "Stop";
            }
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (LeadsScraperThread != null)
            {
                LeadsScraperThread.Abort();
            }

            if (ProxyOutToFileThread != null)
            {
                ProxyOutToFileThread.Abort();
            }
        }

        private void reportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fms = new FormReport(Global);
            fms.Show();
        }

        private void logToFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Global.LogToFile = true;
        }



    }

}
