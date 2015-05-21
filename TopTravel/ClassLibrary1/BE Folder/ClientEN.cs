using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace TopTravel
{
    //This clsass represents the entity Client
    public class ClientEN
    {

        public ClientEN() //constructor of the class
        {
        }
        //Adds a new Client to the DB
        public DataSet add_Client()
        {
            ClientCAD c = new ClientCAD();
            DataSet ds = c.addClient(this);
            return ds;
        }
        //Removes the client form the DB
        public DataSet delete_Client(int i)
        {
            ClientCAD c = new ClientCAD();
            DataSet ds = c.deleteClient(this, i);
            return ds;
        }
        //Updates the information about a client
        public DataSet update_Client(int i)
        {
            ClientCAD c = new ClientCAD();
            DataSet ds = c.updateClient(this, i);
            return ds;
        }
        //Updates the information about the client by id and password
        public void update_Client2(String ID, String pass)
        {
            ClientCAD c = new ClientCAD();
            c.updateClient2(this, ID, pass);
            
        }
        //Searches a client provided its dni and password
        public DataSet searchDNIClient(String dni, string pass)
        {
            ClientCAD c = new ClientCAD();
            DataSet ds = c.searchClients(dni, pass);
            return ds;
        }
        //Shows all the clients of the DB
        public DataSet showAllClient()
        {
            ClientCAD c = new ClientCAD();
            DataSet ds = c.showClient(this);
            return ds;
        }
        //Show the information of a client given its id
        public DataSet showClientData(string ID)
        {
            ClientCAD c = new ClientCAD();
            DataSet ds = c.showClientInfo(ID);
            return ds;
        }

        // PROPERTIES
        private string dni;         //Its unique dni
        private string name;        //Its name
        private string surname;     //Its surname
        private string phone;       //Its phone number
        private string address;     //Its address
        private string gender;      //Its gender
        private int creditCard;     //Its credit card
        private int admin;          //Indicates wheter it is an admin
        private string password;    //Its password
        private string avatar;      //Its avatar

        //getters and setters

        public string Dni           //Privides the tools for setting and getting the values of the dni
        {
            get { return dni; }
            set { dni = value; }
        }

        public string Name          //Privides the tools for setting and getting the values of the name
        {
            get { return name; }
            set { name = value; }
        }

        public string Surname       //Privides the tools for setting and getting the values of the surname
        {
            get { return surname; }
            set { surname = value; }
        }

        public string Phone         //Privides the tools for setting and getting the values of the phone number
        {
            get { return phone; }
            set { phone = value; }
        }

        public string Address       //Privides the tools for setting and getting the values of the address
        {
            get { return address; }
            set { address = value; }
        }

        public string Gender        //Privides the tools for setting and getting the values of the gender
        {
            get { return gender; }
            set { gender = value; }
        }

        public int CreditCard       //Privides the tools for setting and getting the values of the credit card
        {
            get { return creditCard; }
            set { creditCard = value; }
        }

        public int Admin            //Privides the tools for setting and getting the values of the admin
        {
            get { return admin; }
            set { admin = value; }
        }

        public string Password      //Privides the tools for setting and getting the values of the password
        {
            get { return password; }
            set { password = value; }
        }

        public string Avatar        //Privides the tools for setting and getting the values of the avatar
        {
            get { return avatar; }
            set { avatar = value; }
        } 
    }
}