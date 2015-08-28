using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Deployment.Application;

namespace ProxyMaid
{
    partial class FormAboutBox : Form
    {
        public FormAboutBox()
        {
            InitializeComponent();

            AssemblyAttribute AssemblyAttribute = new AssemblyAttribute();


            this.Text = String.Format("About {0}", AssemblyAttribute.AssemblyTitle);
            this.labelProductName.Text = AssemblyAttribute.AssemblyProduct;
            this.labelVersion.Text = String.Format("Version {0}", AssemblyAttribute.AssemblyVersion);
            this.labelCopyright.Text = AssemblyAttribute.AssemblyCopyright;
            this.labelCompanyName.Text = AssemblyAttribute.AssemblyCompany;
            this.textBoxDescription.Text = AssemblyAttribute.AssemblyDescription;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
