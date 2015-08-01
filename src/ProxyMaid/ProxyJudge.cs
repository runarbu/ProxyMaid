using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ProxyMaid
{
    class ProxyJudge
    {

        private volatile Globals _Global;
        private volatile Form _Form;

        public ProxyJudge(Form myForm, Globals Global)
        {
            _Form = myForm;
            _Global = Global;
        }


        
        public Dictionary<string, string> parse(string result)
        { 

            Dictionary<string, string> values = new Dictionary<string, string>();

            
            foreach (Match match in Regex.Matches(result, @"[A-Z_]+ = [^\n]+"))
            {
                string[] info = Regex.Split(match.Value, " = ");
                values.Add(info[0], info[1]);
            }


            return values;

        }
    }
}
