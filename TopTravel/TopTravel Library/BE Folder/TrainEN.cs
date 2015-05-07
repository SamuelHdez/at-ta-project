using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TopTravel
{
    public class TrainEN
    {
        
       public TrainEN(int ID, string dt, string dc, string at, string dtc, string b)
        {
            trainID = ID;
            departureTime = dt;
            departureCity = dc;
            arrivalTime = at;
            destinationCity = dtc;
            Bonus = b;
        }

       public void add_train()
       {
           m_cc = new TrainCAD();
           m_cc.add_train(this);
       }

       public void delete_train()
       {
           m_cc = new TrainCAD();
           m_cc.delete_train(this);
       }

       public void update_train()
       {
           m_cc = new TrainCAD();
           m_cc.update_train(this);
       }

        public void search_train()
       {
           m_cc = new TrainCAD();
           m_cc.search_train(this);
       }


        // PROPERTIES
        public int trainID { get; set; }
        public string departureTime { get; set; }
        public string departureCity { get; set; }
        public string arrivalTime { get; set; }
        public string destinationCity { get; set; }
        public string Bonus { get; set; }

        //Data
        private TrainCAD m_cc;
    }
}