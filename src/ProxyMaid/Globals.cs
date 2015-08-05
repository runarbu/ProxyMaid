using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.ComponentModel;
using System.Threading;
using System.IO;

namespace ProxyMaid
{
    public class Globals
    {

        private static object SmalLock = new object();
        private static object logLock = new object();
        private volatile TextBox _textBox1;
        private volatile Form _Form;
        private volatile bool _running = false;

        /*
        public Globals(Form myForm, TextBox mytextBox)
        {
            ProxyServers = new BindingList<ProxyServer>();
            ProxySources = new BindingList<ProxySource>();
            _textBox1 = mytextBox;
            _Form = myForm;
        }
        */
        public Globals(Form myForm, TextBox mytextBox)
        {
            ProxyServers = new ThreadedBindingList<ProxyServer>();
            ProxySources = new ThreadedBindingList<ProxySource>();

            ProxyServers.SynchronizationContext = SynchronizationContext.Current;
            ProxySources.SynchronizationContext = SynchronizationContext.Current;

            _textBox1 = mytextBox;
            _Form = myForm;
        }

        public ThreadedBindingList<ProxyServer> ProxyServers
        {
            get;
            set;
        }

        public ThreadedBindingList<ProxySource> ProxySources
        {
            get;
            set;
        }
        

        public int ProxyServersToCheck()
        {
            lock (ProxyServers)
            {
                int i = 0;

                if (!running) {
                    return -1;
                }

                foreach (ProxyServer server in ProxyServers.ToList())
                {

                    if (!ProxyCheckerContinue())
                    {
                        return -2;
                    }


                    if (server.Shudled == default(DateTime) || DateTime.Compare(server.Shudled, server.Shudled.AddMinutes(15)) > 0)
                    {
                        server.Shudled = DateTime.Now;

                        return i;
                    }

                    i++;

                }

                return -1;
            }
        }


        public void log(string text)
        {

            lock (logLock)
            { 
                try
                {
                    _Form.Invoke((MethodInvoker)delegate
                    {
                        _textBox1.AppendText(text + "\n");
                    });
                }
                catch (Exception ex)
                {

                }

                if (LogToFile) { 
                    try
                    {
                        System.IO.StreamWriter file = new System.IO.StreamWriter("c:\\temp\\test.txt", true);
                        file.WriteLine(text);
                        file.Close();
                    }
                    catch (Exception ex)
                    {
                        _Form.Invoke((MethodInvoker)delegate
                        {
                            _textBox1.AppendText("Can not log to file: " + ex.Message + "\n");
                        });

                    }
                }
            }
        }


        private static int ProxyCheckerThreadsCount = 0;
        private static object ProxyCheckerThreadsLock = new object();

        private static int ProxyCheckerThreadsWant = 0;

        public int ProxyCheckerThreadsCountGet()
        {
            lock (ProxyCheckerThreadsLock)
            {
                return ProxyCheckerThreadsCount;
            }
        }
        public void ProxyCheckerThreadsWantSet(int i)
        {
            lock (ProxyCheckerThreadsLock)
            {
                ProxyCheckerThreadsWant = i;
            }
        }
        public bool ProxyCheckerContinue()
        {
            lock (ProxyCheckerThreadsLock)
            {
                if (ProxyCheckerThreadsCount <= ProxyCheckerThreadsWant)
                {

                    return true;
                }
                else
                {
                    --ProxyCheckerThreadsCount;
                    return false;
                }
            }
        }

        public bool ProxyCheckerCreate()
        {
            lock (ProxyCheckerThreadsLock)
            {
                if (ProxyCheckerThreadsCount < ProxyCheckerThreadsWant)
                {
                    ++ProxyCheckerThreadsCount;
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        // Own ip
        private static string _OwnIp = "";


        public string OwnIp
        {
            get {
                lock (SmalLock)
                {
                    return _OwnIp;
                }
            }

            set {
                lock (SmalLock)
                {
                    _OwnIp = value;
                }
            }
        }
        

        // Log to file
        private static bool _LogToFile = false;

        public bool LogToFile
        {
            get {
                lock (SmalLock)
                {
                    return _LogToFile;
                }
            }

            set {
                lock (SmalLock)
                {
                    _LogToFile = value;
                }
            }
        }

        public string ProxyOutFilePath()
        {

            if (Properties.Settings.Default.ProxyOutFile == "" || Properties.Settings.Default.ProxyOutFile == null)
            {
                return Directory.GetCurrentDirectory() + @"\out\proxies.txt";
            }
            else {
                return Properties.Settings.Default.ProxyOutFile;
            }
        }

        public bool running
        {
            get
            {
                lock (SmalLock)
                {
                    return _running;
                }
            }

            set
            {
                lock (SmalLock)
                {
                    _running = value;
                }
            }
        }
        
    }
}
