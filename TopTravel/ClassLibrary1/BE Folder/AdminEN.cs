using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace TopTravel
{
    //This clsass represents the entity ADdmin
    public class AdminEN
    {
        public AdminEN() //constructor
        {
        }

        public DataSet searchAdmin(String ad) //search the admin in the db
        {
            AdminCAD c = new AdminCAD();
            DataSet ds = c.searchAdmin(ad);
            return ds;
        }

        // PROPERTIES
        private int id;

        //getter and setter
        public int Id                   //Privides the tools for setting and getting the values of the 
        {
            get { return id; }
            set { id = value; }
        }

    }
}