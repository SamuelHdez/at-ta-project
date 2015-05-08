using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopTravel
{
    class ExtrasEN
    {
        public ExtrasEN(int ID=-1, string w="", string f="", int d=-1)
        {
            id = ID;
            wifi = w;
            food = f;
            discount = d;
        }

       public void add_extra()
       {
           ExtrasCAD c = new ExtrasCAD();
           c.addExtra(this);
       }

       public void delete_extra()
       {
           ExtrasCAD c = new ExtrasCAD();
           c.deleteExtra(this);
       }

       public void update_extra()
       {
           ExtrasCAD c = new ExtrasCAD();
           c.updateExtra(this);
       }


       public ArrayList showAllExtras()
       {
           ArrayList a = new ArrayList();
           ExtrasCAD c = new ExtrasCAD();
           a = c.showExtras();

           return a;
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
