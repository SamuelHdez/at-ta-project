using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HadaProject.Models
{
    public class HelpEN
    {

        public HelpEN(int ID, int p, string t, string n, string ln, string e, string m, string g)
        {
            queryID = ID;
            phone = p;
            title = t;
            name = n;
            lastname = ln;
            email = e;
            message = m;
            gender = g;
        }

        public void send_query()
        {
            m_cc = new HelpCAD();
            m_cc.send_query(this);
        }


        // PROPERTIES
        public int queryID { get; set; }
        public string title { get; set; }
        public string name { get; set; }
        public string lastname { get; set; }
        public int phone { get; set; }
        public string email { get; set; }
        public string message { get; set; }
        public string gender { get; set; }

        //Data
        private HelpCAD m_cc;
    }
}