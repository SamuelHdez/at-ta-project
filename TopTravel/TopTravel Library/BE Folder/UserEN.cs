using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HadaProject.Models
{
    public class UserEN
    {

        public UserEN(int ID, int dni, string name, int phone, string address, string gender)
        {
            UserId = ID;
            UserIDDocument = dni;
            UserName = name;
            UserPhone = phone;
            UserAddress = address;
            UserGender = gender;
        }

       public void register_user()
       {
           m_cc = new UserCAD();
           m_cc.add_user(this);
       }

       public void delete_user()
       {
           m_cc = new UserCAD();
           m_cc.delete_user(this);
       }

       public void update_user()
       {
           m_cc = new UserCAD();
           m_cc.update_user(this);
       }

       public void login_user()
       {
           m_cc = new UserCAD();
           m_cc.search_user(this);
       }

        // PROPERTIES
        public int UserId { get; set; }
        public int UserIDDocument { get; set; }
        public string UserName { get; set; }
        public int UserPhone { get; set; }
        public string UserAddress { get; set; }
        public string UserGender { get; set; }

        //Data
        private UserCAD m_cc;
    }
}