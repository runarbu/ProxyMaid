using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;

namespace ProxyMaid
{
    public class ProxySource : INotifyPropertyChanged
    {

        private Form _Form1;
        string _Url;
        string _Prepattern;
        string _Prereplacement;
        int _Interval;
        int _Proxies;
        int _Working;
        int _Bad;
        DateTime _Shudled;
        bool _Use;


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

        public ProxySource(Form Form1, string i_url, string i_prepattern, string i_prereplacement, int i_interval, int i_proxies)
        {
            _Form1 = Form1;
            _Url = i_url;
            _Prepattern = i_prepattern;
            _Prereplacement = i_prereplacement;
            _Interval = i_interval;
            _Shudled = default(DateTime);
            _Proxies = i_proxies;
            _Working = 0;
            _Bad = 0;
            _Use = true;

        }

        public string Url
        {
            get { return _Url; }
            set
            {
                _Url = value;
                this.NotifyPropertyChanged("Url");
            }
        }

        public string Prepattern
        {
            get { return _Prepattern; }
            set
            {
                _Prepattern = value;
                this.NotifyPropertyChanged("Prepattern");
            }
        }

        public string Prereplacement
        {
            get { return _Prereplacement; }
            set
            {
                _Prereplacement = value;
                this.NotifyPropertyChanged("Prereplacement");
            }
        }

        public int Interval
        {
            get { return _Interval; }
            set
            {
                _Interval = value;
                this.NotifyPropertyChanged("Interval");
            }
        }

        public DateTime Shudled
        {
            get { return _Shudled; }
            set
            {
                _Shudled = value;
                this.NotifyPropertyChanged("Shudled");
            }
        }

        public int Proxies
        {
            get { return _Proxies; }
            set
            {
                _Proxies = value;
                this.NotifyPropertyChanged("Proxies");
            }
        }

        public int Working
        {
            get { return _Working; }
            set
            {
                _Working = value;
                this.NotifyPropertyChanged("Working");
            }
        }

        public int Bad
        {
            get { return _Bad; }
            set
            {
                _Bad = value;
                this.NotifyPropertyChanged("Bad");
            }
        }

        public bool Use
        {
            get { return _Use; }
            set
            {
                _Use = value;
                this.NotifyPropertyChanged("Use");
            }
        }
    }
}
