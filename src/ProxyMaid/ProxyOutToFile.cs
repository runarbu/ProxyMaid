using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace ProxyMaid
{
    class ProxyOutToFile
    {

        volatile bool shutdown = false;
        private volatile Globals _Global;
        private volatile Form _Form;
        private volatile Label _labelOutFileTime;

        public ProxyOutToFile(Form myForm, Globals Global, Label labelOutFileTime)
        {
            _Form = myForm;
            _Global = Global;
            _labelOutFileTime = labelOutFileTime;
        }

        public void StopWork()
        {
            shutdown = true;
        }

        // This method will be called when the thread is started. 
        public void DoWork()
        {
            while (!shutdown)
            {
                System.IO.StreamWriter file = null;

                if (_Global.ProxyServers.Count != 0)
                {

                    try
                    {

                        //_Global.log("Writing proxies to file");

                        file = new System.IO.StreamWriter(Properties.Settings.Default.ProxyOutFile);

                        foreach (ProxyServer server in _Global.ProxyServers)
                        {
                            if (server.Status == "Ok" && AnonymityToInt(server.Anonymity) >= AnonymityToInt(Properties.Settings.Default.ProxyMinAnonymity))
                            {
                                file.WriteLine(server.Ip + ":" + server.Port + ", Anonymity:" + server.Anonymity);
                            }
                        }


                        _Form.Invoke((MethodInvoker)delegate
                        {
                            _labelOutFileTime.Text = DateTime.Now.ToShortTimeString();
                        });

                    }
                    catch (Exception ex)
                    {
                        _Global.log("Can not writ to out file '" + Properties.Settings.Default.ProxyOutFile + "': " + ex.Message);
                    }
                    finally
                    {
                        file.Close();
                    }

                }

                Thread.Sleep(10000);
            }
        }

        // Convert human readable anonymity levels (High, Low, None) to something easier to use in comparisons
        private int AnonymityToInt(String Anonymity)
        { 
            int level = 0;
            if (Anonymity == "None") {
                level = 1;
            }
            else if (Anonymity == "Low")
            {
                level = 2;
            }
            else if (Anonymity == "High") {
                level = 3;
            }
            else {
                throw new Exception("Unknown anonymity level '" + Anonymity + "'.");
            }

            return level;
        }
    }
}
