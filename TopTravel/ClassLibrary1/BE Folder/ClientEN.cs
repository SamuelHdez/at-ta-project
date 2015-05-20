using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace TopTravel
{
    public class ClientEN
    {

        public ClientEN()
        {
        }

        public DataSet add_Client()
        {
            ClientCAD c = new ClientCAD();
            DataSet ds = c.addClient(this);
            return ds;
        }

        public DataSet delete_Client(int i)
        {
            ClientCAD c = new ClientCAD();
            DataSet ds = c.deleteClient(this, i);
            return ds;
        }

        public DataSet update_Client(int i)
        {
            ClientCAD c = new ClientCAD();
            DataSet ds = c.updateClient(this, i);
            return ds;
        }

        public void update_Client2(String ID, String pass)
        {
            ClientCAD c = new ClientCAD();
            c.updateClient2(this, ID, pass);
            
        }

        public DataSet searchDNIClient(String dni, string pass)
        {
            ClientCAD c = new ClientCAD();
            DataSet ds = c.searchClients(dni, pass);
            return ds;
        }

        public DataSet showAllClient()
        {
            ClientCAD c = new ClientCAD();
            DataSet ds = c.showClient(this);
            return ds;
        }

        public DataSet showClientData(string ID)
        {
            ClientCAD c = new ClientCAD();
            DataSet ds = c.showClientInfo(ID);
            return ds;
        }

        // PROPERTIES
        private string dni;
        private string name;
        private string surname;
        private string phone;
        private string address;
        private string gender;
        private int creditCard;
        private int admin;
        private string password;
        private string avatar;

        //getters and setters

        public string Dni
        {
            get { return dni; }
            set { dni = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        public int CreditCard
        {
            get { return creditCard; }
            set { creditCard = value; }
        }

        public int Admin
        {
            get { return admin; }
            set { admin = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string Avatar
        {
            get { return avatar; }
            set { avatar = value; }
        } 
    }
}