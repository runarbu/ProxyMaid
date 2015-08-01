using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;

namespace ProxyMaid
{

    public class ProxyServer : INotifyPropertyChanged
    {
        private Form _Form1;
        private string _ip;
        private int _port;
        private string _source;
        private DateTime _checked;
        private DateTime _shudled;
        private string _status;
        private string _anonymity;

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                //if (_Form1.InvokeRequired)
                //{
                    _Form1.Invoke((MethodInvoker)delegate
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                    });
                //}
                //else
                //{
                //    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                //}
            }
        }

        public ProxyServer(Form Form1, string ip, int port, string source)
        {
            _Form1 = Form1;
            _ip = ip; ;
            _port = port;
            _source = source;
            _checked = default(DateTime);
            _shudled = default(DateTime);
            _status = "Pending";
            _anonymity = "";
        }


        public string Ip
        {
            get { return _ip; }
            set
            {
                _ip = value;
                this.NotifyPropertyChanged("Ip");
            }
        }

        public int Port
        {
            get { return _port; }
            set
            {
                _port = value;
                this.NotifyPropertyChanged("Port");
            }
        }

        public DateTime Checked
        {
            get { return _checked; }
            set
            {
                _checked = value;
                this.NotifyPropertyChanged("Checked");
            }
        }


        public DateTime Shudled
        {
            get { return _shudled; }
            set
            {
                _shudled = value;
                this.NotifyPropertyChanged("Shudled");
            }
        }

        public string Status
        {
            get { return _status; }
            set
            {
                _status = value;
                this.NotifyPropertyChanged("Status");
            }
        }

        public string Anonymity
        {
            get { return _anonymity; }
            set
            {
                _anonymity = value;
                this.NotifyPropertyChanged("Anonymity");
            }
        }

        public string Source
        {
            get { return _source; }
            set
            {
                _source = value;
                this.NotifyPropertyChanged("Source");
            }
        }

    }

}
