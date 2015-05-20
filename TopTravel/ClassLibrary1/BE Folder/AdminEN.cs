using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace TopTravel
{
    public class AdminEN
    {
        public AdminEN()
        {
        }

        public DataSet searchAdmin(String ad)
        {
            AdminCAD c = new AdminCAD();
            DataSet ds = c.searchAdmin(ad);
            return ds;
        }

        // PROPERTIES
        private int Id;
        private string name;
        private string dni;
        private string email;

        public int id
        {
            get { return Id; }
            set { Id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Dni
        {
            get { return dni; }
            set { dni = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
    }
}