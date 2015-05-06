using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HadaProject.Models
{
    public class CompanyEN
    {

        public CompanyEN (string n, string t, string a) {
			name = n;
			type = t; //Private or public company
			address = a;
		}

        public void add_Company()
        {
            m_cc = new CompanyCAD();
            m_cc.add_Company(this);
        }

        public void delete_Company()
        {
            m_cc = new CompanyCAD();
            m_cc.delete_Company(this);
        }


        // PROPERTIES
        public string name { get; set; }
        public string type { get; set; }
        public string address { get; set; }

        //Data
        private CompanyCAD m_cc;


    }
}