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
        private int id;
        private string wifi;
        private string food;
        private int discount;

        //getters and setters

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string WiFi
        {
            get { return wifi; }
            set { wifi = value; }
        }

        public string Food
        {
            get { return food; }
            set { food = value; }
        }

        public int Discount
        {
            get { return discount; }
            set { discount = value; }
        } 
    }
}
