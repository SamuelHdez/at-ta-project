using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TopTravel
{
    public class AdminEN
    {

        public AdminEN(int ID, string UN, string PW)
        {
            AdminId = ID;
            AdminUsername = UN;
            AdminPassword = PW;
        }

       public void register_Admin()
       {
           m_cc = new AdminCAD();
           m_cc.register_admin(this);
       }

       public void delete_Admin()
       {
           m_cc = new AdminCAD();
           m_cc.delete_admin(this);
       }

       public void update_Admin()
       {
           m_cc = new AdminCAD();
           m_cc.update_admin(this);
       }

       public void login_Admin()
       {
           m_cc = new AdminCAD();
           m_cc.login_admin(this);
       }

        // PROPERTIES
        public int AdminId { get; set; }
        public string AdminUsername { get; set; }
        public string AdminPassword { get; set; }
        //Data
        private AdminCAD m_cc;
    }
}