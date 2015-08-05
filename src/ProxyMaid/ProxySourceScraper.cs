using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Net;



namespace ProxyMaid
{
    class ProxySourceScraper
    {

        [DataContract]
        class Spell
        {
            [DataMember]
            public String url = null;

            [DataMember]
            public String prepattern = null;

            [DataMember]
            public String prereplacement = null;

            [DataMember]
            public int interval = 0;
            
        }

        volatile bool shutdown = false;
        private volatile Globals _Global;
        private volatile Form _Form;

        public ProxySourceScraper(Form myForm, Globals Global)
        {
            _Form = myForm;
            _Global = Global;
        }

        public void StopWork()
        {
            shutdown = true;
        }

        private int ExtractProxies(string sourceurl, string result, List<string> banned)
        {
            int found = 0;

            foreach (Match match in Regex.Matches(result, @"[0-9]+\.[0-9]+\.[0-9]+\.[0-9]+:[0-9]+"))
            {
                
                //_Global.log("Found new proxy server " + match.Value);
                string[] server = match.Value.Split(':');

                lock (_Global.ProxyServers)
                {
                    if (_Global.ProxyServers.Any(s => s.Ip == server[0]) == true)
                    {
                        //_Global.log("Skippet known ip " + server[0]);
                    }
                    else if (banned != null && banned.Exists(s => s == server[0]) == true)
                    {
                        _Global.log("Skippet banned ip " + server[0]);
                    }
                    else 
                    {
                        _Global.ProxyServers.Add(new ProxyServer(_Form, server[0], Convert.ToInt32(server[1]), sourceurl));

                        found++;
                    }
                }
                
            }

            return found;
        }

        public List<string> getList(string url)
        {

            List<string> list = new List<string>();
            string result = "";

            {
                try
                {
                    WebRequest web = WebRequest.Create(url);
                    web.Timeout = 15000;

                    HttpWebResponse response = (HttpWebResponse)web.GetResponse();
                    Stream dataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(dataStream);
                    result = reader.ReadToEnd();
                }
                catch (Exception ex)
                {
                    _Global.log("Can not download web proxy list: " + ex.Message);
                    Thread.Sleep(30000);
                }

            }

            // Debug: _Global.log("getList: " + result);


            // Add found public proxy sources to the list
            foreach (string line in Regex.Split(result, "\n"))
            {

                // Skip comments that starts on #
                if (Regex.IsMatch(line, @"^#"))
                {
                    continue;
                }

                // Skip blank lines
                if (line == "")
                {
                    continue;
                }

                list.Add(line);
            }

            return list;
        }
        // This method will be called when the thread is started. 
        public void DoWork()
        {

            string ip = null;
            List<string> banned = null;

            _Global.log("Query to find our own ip adress");
 
            // Find our own ip address
            do {
                try
                {
                    ProxyJudge pj = new ProxyJudge(_Form, _Global);

                    WebRequest web = WebRequest.Create(Properties.Settings.Default.ProxyJudge);
                    web.Timeout = 30000;
                    HttpWebResponse response = (HttpWebResponse)web.GetResponse();
                    Stream dataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(dataStream);
                    string result = reader.ReadToEnd();


                    Dictionary<string, string> values = pj.parse(result);

                    if (values.TryGetValue("REMOTE_ADDR", out ip))
                    {
                        _Global.log("Found own ip: " + ip);

                        _Global.OwnIp = ip;
                    }
                    else {
                        throw new Exception("REMOTE_ADDR missing in field");
                    }
                }
                catch (Exception ex) {
                    _Global.log("Can not find our own ip: " + ex.Message);
                    Thread.Sleep(30000);
                }
            } while (ip == null);

            // Debug: Add a proxy server manually
            //_Global.ProxyServers.Add(new ProxyServer(_Form, "199.189.84.217", Convert.ToInt32("3128"), "runarb"));
            //return;

            if (Properties.Settings.Default.UsePublicProxySources == false)
            {
                _Global.log("Usage of public proxy sources is off, so will not download list");
            }
            else {
                
                // Get public proxy sources
                List<string> proxysources = getList(Properties.Settings.Default.ProxySource);

                foreach (string url in proxysources)
                {

                    lock (_Global.ProxySources)
                    {

                        if (_Global.ProxySources.Any(s => s.Url == url) == false)
                        {
                            ProxySource source = new ProxySource(_Form, url, null, null, 15, 0);
                            _Global.ProxySources.Add(source);
                        }
                    }
                }

                // Get public proxy sources
                banned = getList(Properties.Settings.Default.ProxyBanned);



            }


            _Global.log("Entering main source scraper loop with " + _Global.ProxySources.Count + " sources");

            while (!shutdown)
            {

                foreach (ProxySource source in _Global.ProxySources.ToList())
                {
                    
                    if (source.Shudled != default(DateTime) && source.Interval == 0)
                    {
                        if (Properties.Settings.Default.Debug) 
                        { 
                            _Global.log("Skipping server " + source.Url + " because it shall only be checked once");
                        }
                        continue;
                    }

                    if (source.Shudled != default(DateTime) && DateTime.Compare(source.Shudled, source.Shudled.AddMinutes(source.Interval)) < 0)
                    {
                        if (Properties.Settings.Default.Debug)
                        {
                            _Global.log("Skipping server " + source.Url + " because it have been checked all ready");
                        }
                        continue;
                    }
                    

                    source.Shudled = DateTime.Now;
                        
                    _Global.log("Trying to get proxy servers from " + source.Url);


                    Process proc = new Process
                    {
                        StartInfo = new ProcessStartInfo
                        {
                            FileName = @"PhantomJS\phantomjs.exe",
                            Arguments = @"JavaScript\plainText.js " + source.Url,
                            UseShellExecute = false,
                            RedirectStandardOutput = true,
                            CreateNoWindow = true
                        }
                    };

                    proc.Start();

                    // Go thought the data and use different methods to find proxy servers
                    using (StreamReader reader = proc.StandardOutput)
                    {
                        string result = reader.ReadToEnd();
                        int found = 0;

                        // method 0: No tricks
                        found = ExtractProxies(source.Url, result, banned);
                        source.Proxies += found;
                        _Global.log("Extracted " + found.ToString() + " with method 0 from " + source.Url);
                        

                        
                        // method 1: find ip and port separated with a space or tab
                        found = ExtractProxies(source.Url, Regex.Replace(result, @"([0-9]+\.[0-9]+\.[0-9]+\.[0-9]+)[\t ]+([0-9]+)", @"$1:$2"), banned);
                        source.Proxies += found;
                        _Global.log("Extracted " + found.ToString() + " with method 1 from " + source.Url);


                        // http://www.idcloak.com/proxylist/proxy-list.html
                        // method 2: find port and ip separated with a space or tab
                        found = ExtractProxies(source.Url, Regex.Replace(result, @"([0-9]+)[\t ]+([0-9]+\.[0-9]+\.[0-9]+\.[0-9]+)", @"$2:$1"), banned);
                        source.Proxies += found;
                        _Global.log("Extracted " + found.ToString() + " with method 2 from " + source.Url);
                        
                        
                    }

                   

                    // If asked to shut down we will exit the loop here
                    if (shutdown) {
                        break;
                    }

                    
                }

                // Take a little nap to prevent hammering 
                if (!shutdown)
                {
                    Thread.Sleep(10000);
                }

                
            }

        }

    }
}
