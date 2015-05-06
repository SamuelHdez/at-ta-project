using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TopTravel
{
    public class ClientEN
    {

        public ClientEN(int ID, int dni, string name, int phone, string address, string gender)
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
           m_cc = new ClientCAD();
           m_cc.register_user(this);
       }

       public void delete_user()
       {
           m_cc = new ClientCAD();
           m_cc.delete_user(this);
       }

       public void update_user()
       {
           m_cc = new ClientCAD();
           m_cc.update_user(this);
       }

       public void login_user()
       {
           m_cc = new ClientCAD();
           m_cc.login_user(this);
       }

        // PROPERTIES
        public int UserId { get; set; }
        public int UserIDDocument { get; set; }
        public string UserName { get; set; }
        public int UserPhone { get; set; }
        public string UserAddress { get; set; }
        public string UserGender { get; set; }

        //Data
        private ClientCAD m_cc;
    }
}