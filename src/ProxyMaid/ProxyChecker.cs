#define USE_RESTSHARP

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Net;
using System.IO;

#if USE_RESTSHARP
using RestSharp;
#endif

namespace ProxyMaid
{
    class ProxyChecker
    {
        private volatile Globals _Global;
        private volatile Form _Form;

        public ProxyChecker(Form myForm, Globals Global)
        {
            _Form = myForm;
            _Global = Global;
        }

        // This method will be called when the thread is started. 
        public void DoWork()
        {

            // Hardcoded list of bad and good headers. 
            Dictionary<string, bool> revealingheader = new Dictionary<string, bool>()
	        {
                {"HTTP_X_REAL_IP", true},
                {"HTTP_X_FORWARDED_FOR", true},
                {"HTTP_PROXY_CONNECTION", true},
                {"HTTP_CLIENT_IP", true},
                {"HTTP_VIA", true},
                {"HTTP_X_BLUECOAT_VIA", true},
                {"HTTP_MAX_FORWARDS", true},
                {"HTTP_HOST", false},
                {"HTTP_CACHE_CONTROL", false},
                {"HTTP_ACCEPT", false},
                {"HTTP_CONNECTION", false},
                {"REMOTE_ADDR", false},
                {"REMOTE_PORT", false},
                {"REQUEST_METHOD", false},
                {"REQUEST_URI", false},
                {"REQUEST_TIME_FLOAT", false},
                {"REQUEST_TIME", false},
                {"HTTP_ACCEPT_ENCODING", false},
                {"HTTP_USER_AGENT", false}
	        };

            Thread.CurrentThread.Name = "ProxyChecker";

            while (_Global.ProxyCheckerContinue())
            {
                int i = _Global.ProxyServersToCheck();
                

                // Asked to exit. Wil do so.
                if (i == -2) {
                    return;
                }

                if (i == -1) {
                    Thread.Sleep(1000);  
                    continue;
                }
                _Global.log(Thread.CurrentThread.ManagedThreadId.ToString() + " check server nr " + i);
                        

                ProxyServer server = _Global.ProxyServers[i];

                string lastStatus = server.Status;
                lock (_Global.ProxyServers)
                {
                    server.Status = "Checking";
                }
                
                _Global.log("Trying to connect to " + server.Ip + ":" + server.Port);

                string anonymity = "";
                string status = "Ok";

                try
                {
                    ProxyJudge pj = new ProxyJudge(_Form, _Global);
                    WebProxy proxy = new WebProxy(server.Ip, server.Port);

#if USE_RESTSHARP
                    var client = new RestClient(Properties.Settings.Default.ProxyJudge);
                    client.Proxy = proxy;
                 

                    var request = new RestRequest("", Method.GET);

                    // execute the request
                    IRestResponse response = client.Execute(request);
                    
                    var result = response.Content; // raw content as string
                    
                    _Global.log("result (" + server.Ip + ":" + server.Port + "): " + result);
                    _Global.log("StatusCode: " + response.StatusCode);
                    _Global.log("StatusDescription: " + response.StatusDescription);

                    if (response.ErrorException != null)
                    {
                        throw new Exception(response.ErrorException.Message);
                    }

#else
                    
                    ProxyJudge pj = new ProxyJudge(_Form, _Global);
                    WebProxy proxy = new WebProxy(server.Ip, server.Port);

                    WebRequest web = WebRequest.Create(Properties.Settings.Default.ProxyJudge);
                    web.Timeout = Properties.Settings.Default.ProxyTimeOut * 1000;
                    web.Proxy = proxy;
                    HttpWebResponse response = (HttpWebResponse)web.GetResponse();
                    Stream dataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(dataStream);
                    string result = reader.ReadToEnd();
#endif

                    Dictionary<string, string> values = pj.parse(result);

                    // Test to se if our ip adress exist in the result
                    string ip = _Global.OwnIp;

                    if (result == "")
                    {
                        throw new Exception("Emty response");
                    }
                    else if (result.IndexOf("REQUEST_URI") == -1)
                    {
                        throw new Exception("Did not find header info. The proxy may thamber with the response");
                    }
                    else if (result.IndexOf(ip) != -1) {
                        _Global.log(server.Ip + ": Found ip in results");
                        anonymity = "None";
                    }
                    else
                    {
                        // Will go troght black and whitlist to see what level of anonymity this server provides
                        bool found = false;
                        foreach (KeyValuePair<string, string> value in values)
                        {
                            bool revealing;
                            if (revealingheader.TryGetValue(value.Key, out revealing)) // Returns true.
                            {
                                if (revealing)
                                {
                                    anonymity = "Low";
                                    found = true;
                                    _Global.log("Found revealingheader " + value.Key + " : " + value.Value);
                                }
                            }
                            else {
                                anonymity = "Low";
                                found = true;
                                _Global.log("Have unknown header '" + value.Key + " : " + value.Value);
                            }
                        }

                        // If we have not 
                        if (found == false) {
                            anonymity = "High";
                        }
                    }
                    
                    

                    _Global.log(server.Ip + " ok");                    
                      
                }
                catch (Exception ex)
                {
                    _Global.log(server.Ip +" error: '" + ex.Message + "'");
                    status = "Error: " + ex.Message;
                }

                
                // Update the global object
                lock (_Global.ProxyServers)
                { 
                    server.Anonymity = anonymity;
                    server.Checked = DateTime.Now;
                    server.Status = status;
                }
                
                // Update the owervive, do no count twice.
                if (server.Status != lastStatus)
                {
                    ProxySource source = _Global.ProxySources.Single(s => s.Url == server.Source);

                    lock (_Global.ProxySources)
                    {
                        if (status == "Ok")
                        {
                            source.Working += 1;
                        }
                        else {
                            source.Bad += 1;
                        }
                    }

                }
                 


            }

            
           
            _Global.log("T exeting");
        }
    }
}
