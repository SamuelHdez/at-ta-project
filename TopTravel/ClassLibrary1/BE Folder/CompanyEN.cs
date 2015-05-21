﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace TopTravel
{
    //This clsass represents the entity Company
    public class CompanyEN
    {        
        
        public CompanyEN() //constructor
        {
        }

        public void add_Company() //new company
        {
            CompanyCAD c = new CompanyCAD();
            c.addCompany(this);
        }

        public DataSet delete_Company(int i) //delete company
        {
            CompanyCAD c = new CompanyCAD();
            DataSet ds = c.deleteCompany(this, i);
            return ds;
        }

        public DataSet update_Company(int i) //update company
        {
            CompanyCAD c = new CompanyCAD();
            DataSet ds = c.updateCompany(this, i);
            return ds;
        }

        public DataSet searchAllCompanies(String ty) //search company  by type
        {
            CompanyCAD c = new CompanyCAD();
            DataSet ds = c.searchCompanies(ty);
            return ds;
        }

        public DataSet searchCompanyID(string idC) //search company by id
        {
            CompanyCAD c = new CompanyCAD();
            DataSet ds = c.searchCompanyID(idC);
            return ds;
        }

        public DataSet showAllCompanies() //show all the companies
        {
            CompanyCAD c = new CompanyCAD();
            DataSet ds = c.showCompanies(this);
            return ds;
        }

        // PROPERTIES
        private int ID;
        private string Name;
        private string Type;
        private int Phone;
        private string Email;
        private string Country;
        private string Website;
        private string Description;


        //Getters and setters
        public int Id
        {
            get { return ID; }
            set { ID = value; }
        }

        public string name
        {
            get { return Name; }
            set { Name = value; }
        }

        public string type
        {
            get { return Type; }
            set { Type = value; }
        }

         public int phone
        {
            get { return Phone; }
            set { Phone = value; }
        }

         public string email
        {
            get { return Email; }
            set { Email = value; }
        }

         public string country
         {
             get { return Country; }
             set { Country = value; }
         }

         public string website
         {
             get { return Website; }
             set { Website = value; }
         }

         public string description
         {
             get { return Description; }
             set { Description = value; }
         }
    }
}