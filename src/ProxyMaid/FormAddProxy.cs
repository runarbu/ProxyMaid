using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;


namespace ProxyMaid
{
    public partial class FormAddProxy : Form
    {
        private volatile Globals _Global;
        private volatile Form _Form;

        public FormAddProxy(Form myForm, Globals Global)
        {
            InitializeComponent();

            _Global = Global;
            _Form = myForm;
        }

        private void buttonSaveAddProxy_Click(object sender, EventArgs e)
        {

            int found = 0;

            string[] allLines = textBoxAddProxy.Text.Split('\n');

            foreach (string line in allLines)
            {
                if (Regex.IsMatch(line, @"([0-9]+\.[0-9]+\.[0-9]+\.[0-9]+):([0-9]+)") == false)
                {
                    _Global.log("Skippet incorrect formatted proxy " + line);
                    continue;
                }

                string[] server = line.Split(':');

                lock (_Global.ProxyServers)
                {
                    if (_Global.ProxyServers.Any(s => s.Ip == server[0]) == true)
                    {
                        //_Global.log("Skippet known ip " + server[0]);
                    }
                    // ToDo: implement banned list here also:
                    //else if (banned != null && banned.Exists(s => s == server[0]) == true)
                    //{
                    //    _Global.log("Skippet banned ip " + server[0]);
                    //}
                    else
                    {
                        _Global.ProxyServers.Add(new ProxyServer(_Form, server[0], Convert.ToInt32(server[1]), "Added manually"));
                        found++;
                    }
                }

                // Update the sourc about total proxies added
                ProxySource source = _Global.ProxySources.Single(s => s.Url == "Added manually");

                lock (_Global.ProxySources)
                {
                    source.Proxies += found;
                }

            }

            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
