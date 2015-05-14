using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace TopTravel
{
    public class AdminEN
    {
        public AdminEN(int i, string n, string d, string e, string p)
        {
            Id = i;
            name = n;
            dni = d;
            email = e;
            password = p;
        }

       public void register_Admin()
       {
           AdminCAD c = new AdminCAD();
           c.register_admin(this);
       }

       public void delete_Admin()
       {
           AdminCAD c = new AdminCAD();
           c.delete_admin(this);
       }

       public void update_Admin()
       {
           AdminCAD c = new AdminCAD();
           c.update_admin(this);
       }

       public ArrayList login_Admin()
       {
           ArrayList a = new ArrayList();
           AdminCAD c = new AdminCAD();
           a = c.login_admin(this);
           return a;
       }

        // PROPERTIES
        public int Id { get; set; }
        public string name { get; set; }
        public string dni { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
}