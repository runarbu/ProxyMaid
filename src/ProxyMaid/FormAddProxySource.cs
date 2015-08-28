using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace ProxyMaid
{
    public partial class FormAddProxySource : Form
    {
        private volatile Globals _Global;
        private volatile Form _Form;

        public FormAddProxySource(Form myForm, Globals Global)
        {
            InitializeComponent();

            _Global = Global;
            _Form = myForm;
        }

        private void buttonSaveProxies_Click(object sender, EventArgs e)
        {

            string[] allLines = textBoxAddProxies.Text.Split('\n');

            foreach (string line in allLines)
            {

                if (Regex.IsMatch(line, @"http") == false)
                {
                    _Global.log("Skippet incorrect formatted proxy source " + line);
                    continue;
                }

                if (_Global.ProxySources.Any(s => s.Url == line) == false) 
                {
                    _Form.Invoke((MethodInvoker)delegate
                    {
                        ProxySource source = new ProxySource(_Form, line, "", "", 0, -1);
                        _Global.ProxySources.Add(source);
                    });
                }

            }

            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
