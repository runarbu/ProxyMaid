namespace ProxyMaid
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonStartStop = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.dataGridViewProxySources = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.logToFile = new System.Windows.Forms.CheckBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxProxyMinAnonymity = new System.Windows.Forms.ComboBox();
            this.labelOutFIleInfo = new System.Windows.Forms.Label();
            this.labelOutFileTime = new System.Windows.Forms.Label();
            this.buttonOutFileOpen = new System.Windows.Forms.Button();
            this.buttonChange = new System.Windows.Forms.Button();
            this.textBoxOutFile = new System.Windows.Forms.TextBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAllProxiesSourcesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveWorkinProxiesSourcesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addProxiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelThreads = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProxySources)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonStartStop
            // 
            this.buttonStartStop.Location = new System.Drawing.Point(184, 23);
            this.buttonStartStop.Margin = new System.Windows.Forms.Padding(2);
            this.buttonStartStop.Name = "buttonStartStop";
            this.buttonStartStop.Size = new System.Drawing.Size(56, 25);
            this.buttonStartStop.TabIndex = 0;
            this.buttonStartStop.Text = "Start";
            this.buttonStartStop.UseVisualStyleBackColor = true;
            this.buttonStartStop.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBox1.Location = new System.Drawing.Point(2, 34);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(589, 264);
            this.textBox1.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(2, 2);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(589, 296);
            this.dataGridView1.TabIndex = 3;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabControl1.Location = new System.Drawing.Point(0, 52);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(601, 326);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage1.Size = new System.Drawing.Size(593, 300);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Proxy servers";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.dataGridViewProxySources);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(593, 300);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Proxy sources";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // dataGridViewProxySources
            // 
            this.dataGridViewProxySources.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProxySources.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridViewProxySources.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewProxySources.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewProxySources.Name = "dataGridViewProxySources";
            this.dataGridViewProxySources.RowTemplate.Height = 24;
            this.dataGridViewProxySources.Size = new System.Drawing.Size(593, 300);
            this.dataGridViewProxySources.TabIndex = 0;
            this.dataGridViewProxySources.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewProxySources_CellContentClick);
            this.dataGridViewProxySources.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridViewProxySources_RowsAdded);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.logToFile);
            this.tabPage2.Controls.Add(this.textBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage2.Size = new System.Drawing.Size(593, 300);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Log";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // logToFile
            // 
            this.logToFile.AutoSize = true;
            this.logToFile.Location = new System.Drawing.Point(4, 273);
            this.logToFile.Margin = new System.Windows.Forms.Padding(2);
            this.logToFile.Name = "logToFile";
            this.logToFile.Size = new System.Drawing.Size(72, 17);
            this.logToFile.TabIndex = 3;
            this.logToFile.Text = "Log to file";
            this.logToFile.UseVisualStyleBackColor = true;
            this.logToFile.CheckedChanged += new System.EventHandler(this.logToFile_CheckedChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.comboBoxProxyMinAnonymity);
            this.tabPage3.Controls.Add(this.labelOutFIleInfo);
            this.tabPage3.Controls.Add(this.labelOutFileTime);
            this.tabPage3.Controls.Add(this.buttonOutFileOpen);
            this.tabPage3.Controls.Add(this.buttonChange);
            this.tabPage3.Controls.Add(this.textBoxOutFile);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(593, 300);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Out";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 27);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Minimum level of anonymity:";
            // 
            // comboBoxProxyMinAnonymity
            // 
            this.comboBoxProxyMinAnonymity.FormattingEnabled = true;
            this.comboBoxProxyMinAnonymity.Items.AddRange(new object[] {
            "High",
            "Low",
            "None"});
            this.comboBoxProxyMinAnonymity.Location = new System.Drawing.Point(196, 21);
            this.comboBoxProxyMinAnonymity.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxProxyMinAnonymity.Name = "comboBoxProxyMinAnonymity";
            this.comboBoxProxyMinAnonymity.Size = new System.Drawing.Size(92, 21);
            this.comboBoxProxyMinAnonymity.TabIndex = 5;
            this.comboBoxProxyMinAnonymity.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // labelOutFIleInfo
            // 
            this.labelOutFIleInfo.AutoSize = true;
            this.labelOutFIleInfo.Location = new System.Drawing.Point(40, 118);
            this.labelOutFIleInfo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelOutFIleInfo.Name = "labelOutFIleInfo";
            this.labelOutFIleInfo.Size = new System.Drawing.Size(63, 13);
            this.labelOutFIleInfo.TabIndex = 4;
            this.labelOutFIleInfo.Text = "Last output:";
            // 
            // labelOutFileTime
            // 
            this.labelOutFileTime.AutoSize = true;
            this.labelOutFileTime.Location = new System.Drawing.Point(106, 118);
            this.labelOutFileTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelOutFileTime.Name = "labelOutFileTime";
            this.labelOutFileTime.Size = new System.Drawing.Size(34, 13);
            this.labelOutFileTime.TabIndex = 3;
            this.labelOutFileTime.Text = "never";
            // 
            // buttonOutFileOpen
            // 
            this.buttonOutFileOpen.Location = new System.Drawing.Point(185, 113);
            this.buttonOutFileOpen.Margin = new System.Windows.Forms.Padding(2);
            this.buttonOutFileOpen.Name = "buttonOutFileOpen";
            this.buttonOutFileOpen.Size = new System.Drawing.Size(102, 25);
            this.buttonOutFileOpen.TabIndex = 2;
            this.buttonOutFileOpen.Text = "Open in notepad";
            this.buttonOutFileOpen.UseVisualStyleBackColor = true;
            this.buttonOutFileOpen.Click += new System.EventHandler(this.buttonOutFileOpen_Click);
            // 
            // buttonChange
            // 
            this.buttonChange.Location = new System.Drawing.Point(231, 66);
            this.buttonChange.Margin = new System.Windows.Forms.Padding(2);
            this.buttonChange.Name = "buttonChange";
            this.buttonChange.Size = new System.Drawing.Size(56, 26);
            this.buttonChange.TabIndex = 1;
            this.buttonChange.Text = "Change";
            this.buttonChange.UseVisualStyleBackColor = true;
            this.buttonChange.Click += new System.EventHandler(this.buttonChange_Click);
            // 
            // textBoxOutFile
            // 
            this.textBoxOutFile.Location = new System.Drawing.Point(40, 67);
            this.textBoxOutFile.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxOutFile.Name = "textBoxOutFile";
            this.textBoxOutFile.Size = new System.Drawing.Size(179, 20);
            this.textBoxOutFile.TabIndex = 0;
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(314, 23);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(2);
            this.trackBar1.Maximum = 50;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(121, 45);
            this.trackBar1.TabIndex = 5;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(439, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "0";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(601, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveAllProxiesSourcesToolStripMenuItem,
            this.saveWorkinProxiesSourcesToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveAllProxiesSourcesToolStripMenuItem
            // 
            this.saveAllProxiesSourcesToolStripMenuItem.Name = "saveAllProxiesSourcesToolStripMenuItem";
            this.saveAllProxiesSourcesToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.saveAllProxiesSourcesToolStripMenuItem.Text = "Save all proxies sources";
            this.saveAllProxiesSourcesToolStripMenuItem.Click += new System.EventHandler(this.saveAllProxiesSourcesToolStripMenuItem_Click);
            // 
            // saveWorkinProxiesSourcesToolStripMenuItem
            // 
            this.saveWorkinProxiesSourcesToolStripMenuItem.Name = "saveWorkinProxiesSourcesToolStripMenuItem";
            this.saveWorkinProxiesSourcesToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.saveWorkinProxiesSourcesToolStripMenuItem.Text = "Save workin proxies sources";
            this.saveWorkinProxiesSourcesToolStripMenuItem.Click += new System.EventHandler(this.saveWorkinProxiesSourcesToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setingsToolStripMenuItem,
            this.addProxiesToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // setingsToolStripMenuItem
            // 
            this.setingsToolStripMenuItem.Name = "setingsToolStripMenuItem";
            this.setingsToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.setingsToolStripMenuItem.Text = "Settings";
            this.setingsToolStripMenuItem.Click += new System.EventHandler(this.setingsToolStripMenuItem_Click);
            // 
            // addProxiesToolStripMenuItem
            // 
            this.addProxiesToolStripMenuItem.Name = "addProxiesToolStripMenuItem";
            this.addProxiesToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.addProxiesToolStripMenuItem.Text = "Add proxies";
            this.addProxiesToolStripMenuItem.Click += new System.EventHandler(this.addProxiesToolStripMenuItem_Click);
            // 
            // labelThreads
            // 
            this.labelThreads.AutoSize = true;
            this.labelThreads.Location = new System.Drawing.Point(260, 29);
            this.labelThreads.Name = "labelThreads";
            this.labelThreads.Size = new System.Drawing.Size(49, 13);
            this.labelThreads.TabIndex = 8;
            this.labelThreads.Text = "Threads:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 378);
            this.Controls.Add(this.labelThreads);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.buttonStartStop);
            this.Controls.Add(this.tabControl1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "ProxyMaid";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProxySources)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStartStop;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox logToFile;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setingsToolStripMenuItem;
        private System.Windows.Forms.Label labelOutFIleInfo;
        private System.Windows.Forms.Label labelOutFileTime;
        private System.Windows.Forms.Button buttonOutFileOpen;
        private System.Windows.Forms.Button buttonChange;
        private System.Windows.Forms.TextBox textBoxOutFile;
        private System.Windows.Forms.Label labelThreads;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ComboBox comboBoxProxyMinAnonymity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataGridView dataGridViewProxySources;
        private System.Windows.Forms.ToolStripMenuItem addProxiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAllProxiesSourcesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveWorkinProxiesSourcesToolStripMenuItem;
    }
}

