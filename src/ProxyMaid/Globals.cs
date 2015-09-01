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
                int i;

                if (!running) {
                    return -1;
                }

                if (!ProxyCheckerContinue())
                {
                    return -2;
                }

                // Go troght all proxy servers and sellect with to test.

                // Priorety 1: working proxy serers that have not been testet sines ProxyReCheck time
                i = 0;
                foreach (ProxyServer server in ProxyServers.ToList())
                {

                    if (server.Shudled != default(DateTime) && DateTime.Compare(DateTime.Now, server.Shudled.AddMinutes(Properties.Settings.Default.ProxyReCheck)) > 0 && server.Status.Substring(0, 2) == "Ok")
                    {
                        server.Shudled = DateTime.Now;
                        debug("ProxyServersToCheck: Found pri 1. Last checked " + server.Shudled.ToShortTimeString() + " with status " + server.Status);

                        return i;
                    }

                    i++;

                }

                // Priorety 2: new proxy serrvers
                i = 0;
                foreach (ProxyServer server in ProxyServers.ToList())
                {

                    if (server.Shudled == default(DateTime))
                    {
                        server.Shudled = DateTime.Now;
                        debug("ProxyServersToCheck: Found pri 2. Newer checked. ");

                        return i;
                    }

                    i++;

                }

                // Priorety 3: old proxy serrvers that was not ok when we testet them last time
                i = 0;
                foreach (ProxyServer server in ProxyServers.ToList())
                {

                    if (server.Shudled != default(DateTime) && DateTime.Compare(DateTime.Now, server.Shudled.AddMinutes(Properties.Settings.Default.ProxyReCheck)) > 0 && server.Status.Substring(0, 2) != "Ok")
                    {
                        server.Shudled = DateTime.Now;
                        debug("ProxyServersToCheck: Found pri 3. Last checked " + server.Shudled.ToShortTimeString() + " with status " + server.Status);

                        return i;
                    }

                    i++;

                }

                return -1;
            }
        }


        public void debug(string text)
        {
            //if (Properties.Settings.Default.Debug)
            //{
                log(text);
            //}
        }

        public void log(string text)
        {

            lock (logLock)
            { 
                try
                {
                    _Form.Invoke((MethodInvoker)delegate
                    {
                        _textBox1.AppendText(text + "\r\n");
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
                            _textBox1.AppendText("Can not log to file: " + ex.Message + "\r\n");
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
                return Directory.GetCurrentDirectory() + @"\Out\proxies.txt";
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
