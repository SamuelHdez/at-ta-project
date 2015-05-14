using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace TopTravel
{
    public class CompanyEN
    {
        public CompanyEN (int id=-1, string n="", string t="", string e="", string c="", string url="", string d="", int number=0) {
            ID = id;
            Name = n;
			Type = t; //Flight, Train, Bus, Space, Hotel, Car, Cruise
			Email = e;
            Country = c;
            Website = url;
            Description = d;
            Phone = number;
		}

        public void add_Company()
        {
            CompanyCAD c = new CompanyCAD();
            c.addCompany(this);
        }

        public void delete_Company()
        {
            CompanyCAD c = new CompanyCAD();
            c.deleteCompany(this);
        }

        public void update_Company()
        {
            CompanyCAD c = new CompanyCAD();
            c.updateCompany(this);
        }

        public ArrayList showCompanies()
        {
            ArrayList a = new ArrayList();
            CompanyCAD c = new CompanyCAD();
            a = c.showCompanies();
            return a;
        }

        // PROPERTIES
        public int ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string Website { get; set; }
        public string Description { get; set; }

        /* Esto sobra pero no lo borro por si acaso.
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
         }*/
    }
}