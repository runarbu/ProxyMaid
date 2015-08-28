using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ProxyMaid
{
    public partial class FormReport : Form
    {

        private volatile Globals _Global;

        public FormReport(Globals Global)
        {
            InitializeComponent();

            _Global = Global;

            comboBoxReportType.Items.Add("Text");
            comboBoxReportType.Items.Add("BB code");


            comboBoxReportType.SelectedIndex = comboBoxReportType.FindStringExact(Properties.Settings.Default.ReportType);

        }

        public void report(string type) {

            AssemblyAttribute AssemblyAttribute = new AssemblyAttribute();

            string[] anonymitylevels = { "High:high", "Low:low", "None:no" };

            textBoxReport.Clear();

            if (type == "Text")
            {
                textBoxReport.AppendText(String.Format("Checked with ProxyMaid, Version {0} ( http://www.proxymaid.com/ )\n", AssemblyAttribute.AssemblyVersion));
                textBoxReport.AppendText("# Time out: " + Properties.Settings.Default.ProxyTimeOut + "s\n");

                foreach (string anonymity in anonymitylevels)
                {
                    textBoxReport.AppendText("#\n");
                    textBoxReport.AppendText("# Proxies with " + anonymity.Split(':')[1] + " anonymity:\n");

                    foreach (ProxyServer server in _Global.ProxyServers.ToList())
                    {
                        if (server.Status.Substring(0, 2) == "Ok" && server.Anonymity == anonymity.Split(':')[0])
                        {
                            textBoxReport.AppendText(server.Ip + ":" + server.Port + "\n");
                        }
                    }
                }
            }
            else if (type == "BB code")
            {
                
                textBoxReport.AppendText(String.Format("Checked with ProxyMaid, Version {0}\n", AssemblyAttribute.AssemblyVersion));
                textBoxReport.AppendText("Time out: " + Properties.Settings.Default.ProxyTimeOut + "s\n");

                foreach (string anonymity in anonymitylevels)
                {
                    textBoxReport.AppendText("\n");
                    textBoxReport.AppendText("Proxies with " + anonymity.Split(':')[1] + " anonymity:\n");

                    textBoxReport.AppendText("[CODE]\n");
                    foreach (ProxyServer server in _Global.ProxyServers.ToList())
                    {
                        if (server.Status.Substring(0, 2) == "Ok" && server.Anonymity == anonymity.Split(':')[0])
                        {
                            textBoxReport.AppendText(server.Ip + ":" + server.Port + "\n");
                        }
                    }
                    textBoxReport.AppendText("[/CODE]\n");
                }
            }
            else {
                MessageBox.Show("Unknown report type '" + type + "'.");
            }
        }

        private void comboBoxReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            report(comboBoxReportType.SelectedItem.ToString());

            Properties.Settings.Default.ReportType = comboBoxReportType.SelectedItem.ToString();
            Properties.Settings.Default.Save();
        }
    }
}
