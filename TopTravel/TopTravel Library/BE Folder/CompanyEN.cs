using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TopTravel
{
    public class CompanyEN
    {

        public CompanyEN (int id=-1, string n="", string t="", string e="", string c="", string url="", string d="", int number=0) {
            this.id = id;
            name = n;
			type = t; //Flight, Train, Bus, Space, Hotel, Car, Cruise
			email = e;
            country = c;
            website = url;
            description = d;
            phone = number;
		}

        public void add_Company()
        {
            CompanyCAD c = new CompanyCAD();
            c.addCompany(this);
        }

        public void delete_Company()
        {
            m_cc = new CompanyCAD();
            try
            {
                m_cc.delete_Company(this);
            }
            catch (Exception e)
            {
                e.ToString();
                Console.WriteLine("Error: Delete company");
            }
        }

        public void update_Company()
        {
            m_cc = new CompanyCAD();
            try
            {
                m_cc.update_Company(this);
            }
            catch (Exception e)
            {
                e.ToString();
                Console.WriteLine("Error: Update company");
            }
        }

        public ArrayList showCompanies()
        {
            ArrayList a = new ArrayList();
            CompanyCAD c = new CompanyCAD();
            a = c.showCompanies();

            return a;
        }

        // PROPERTIES
        private int id;
        private string name;
        private string type;
        private int phone;
        private string email;
        private string country;
        private string website;
        private string description;

        //Data
        private CompanyCAD m_cc;

        //Getters and setters
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

         public int Phone
        {
            get { return phone; }
            set { phone = value; }
        }

         public string Email
        {
            get { return email; }
            set { email = value; }
        }

         public string Country
         {
             get { return country; }
             set { country = value; }
         }

         public string Website
         {
             get { return website; }
             set { website = value; }
         }

         public string Description
         {
             get { return description; }
             set { description = value; }
         }
    }
}