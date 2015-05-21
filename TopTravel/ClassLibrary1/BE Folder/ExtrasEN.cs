using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace TopTravel
{
    //This clsass represents the entity Extras
    public class ExtrasEN
    {
        public ExtrasEN() //constructor
        {
        }

       public void add_extra() //new extra
       {
           ExtrasCAD c = new ExtrasCAD();
           c.addExtra(this);
       }

       public void delete_extra() //delete extra
       {
           ExtrasCAD c = new ExtrasCAD();
           c.deleteExtra(this);
       }

       public void update_extra() //update extra
       {
           ExtrasCAD c = new ExtrasCAD();
           c.updateExtra(this);
       }


       public ArrayList showAllExtras() //show all extras
       {
           ArrayList a = new ArrayList();
           ExtrasCAD c = new ExtrasCAD();
           a = c.showExtras();
           return a;
       }

       public DataSet searchExtrasID(string idx) //search extra by id
       {
           ExtrasCAD c = new ExtrasCAD();
           DataSet ds = c.searchExtrasID(idx);
           return ds;
       } 

        //propierties
        private int id;         //Its unique id
        private string wifi;    //Indicates wheter it has WiFi
        private string food;    //The type of food it offers
        private int discount;   //The discount at the price

        //getters and setters

        public int Id           //Privides the tools for setting and getting the values of the id
        {
            get { return id; }
            set { id = value; }
        }

        public string WiFi      //Privides the tools for setting and getting the values of the WiFi
        {
            get { return wifi; }
            set { wifi = value; }
        }

        public string Food      //Privides the tools for setting and getting the values of the food
        {
            get { return food; }
            set { food = value; }
        }

        public int Discount     //Privides the tools for setting and getting the values of the discount
        {
            get { return discount; }
            set { discount = value; }
        } 
    }
}
