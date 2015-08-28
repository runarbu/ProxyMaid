using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProxyMaid
{
    public partial class FormSettings : Form
    {
        public FormSettings()
        {
            InitializeComponent();

            textBoxProxyJudge.Text = Properties.Settings.Default.ProxyJudge;
            textBoxProxyTimeOut.Text = Properties.Settings.Default.ProxyTimeOut.ToString();
            textBoxProxyOutTime.Text = Properties.Settings.Default.ProxyOutTime.ToString();
            textBoxProxyReCheck.Text = Properties.Settings.Default.ProxyReCheck.ToString();

            checkBoxUsePublicProxySources.Checked = Properties.Settings.Default.UsePublicProxySources;
            checkBoxDebugMode.Checked = Properties.Settings.Default.Debug;

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {

            Properties.Settings.Default.ProxyJudge = textBoxProxyJudge.Text;
            Properties.Settings.Default.ProxyTimeOut = Convert.ToUInt16(textBoxProxyTimeOut.Text);
            Properties.Settings.Default.ProxyOutTime = Convert.ToUInt16(textBoxProxyOutTime.Text);
            Properties.Settings.Default.ProxyReCheck = Convert.ToUInt16(textBoxProxyReCheck.Text);

            Properties.Settings.Default.UsePublicProxySources = checkBoxUsePublicProxySources.Checked;
            Properties.Settings.Default.Debug = checkBoxDebugMode.Checked;

            Properties.Settings.Default.Save();
            this.Close();
        }
    }
}
