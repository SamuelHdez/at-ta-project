using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HadaProject.Models
{
    public class TrainEN
    {
        
       public TrainEN(int ID, int maxP, int p, string dt, string dc, string at, string d)
        {
            trainID = ID;
            maxpassengers = maxP;
            price = p;
            departureTime = dt;
            departureCity = dc;
            arrivalTime = at;
            destination = d;
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

        public void show_timetable()
        {
            m_cc = new TrainCAD();
            m_cc.show_timetable(this);
        }


        // PROPERTIES
        public int trainID { get; set; }
        public string departureTime { get; set; }
        public string departureCity { get; set; }
        public string arrivalTime { get; set; }
        public string destination { get; set; }
        public int maxpassengers { get; set; }
        public int price { get; set; }

        //Data
        private TrainCAD m_cc;
    }
}