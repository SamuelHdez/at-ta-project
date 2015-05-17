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
        public int Id { get; set; }
        public string name { get; set; }
        public string dni { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
}