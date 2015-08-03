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
        public FormReport(Globals Global)
        {
            InitializeComponent();

            textBoxReport.AppendText("# Checked with ProxyMaid ( http://www.proxymaid.com/ )\n");
            textBoxReport.AppendText("# Time out: " + Properties.Settings.Default.ProxyTimeOut + "s\n");
            

            string[] anonymitylevels = { "High", "Low", "None" };
            foreach (string anonymity in anonymitylevels)
            {
                textBoxReport.AppendText("#\n");
                textBoxReport.AppendText("# Proxies with " + anonymity.ToLower() + " anonymity:\n");

                foreach (ProxyServer server in Global.ProxyServers.ToList())
                {
                    if (server.Status.Substring(0, 2) == "Ok" && server.Anonymity == anonymity)
                    {
                        textBoxReport.AppendText(server.Ip + ":" + server.Port + "\n");
                    }
                }
            }
        }
    }
}
