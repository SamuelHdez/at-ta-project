using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HadaProject.Models
{
    public class BusEN
    {

        public BusEN(int ID, int maxP, int p, string dt, string dc, string at, string d)
        {
            BusID = ID;
            maxpassengers = maxP;
            price = p;
            departureTime = dt;
            departureCity = dc;
            arrivalTime = at;
            destination = d;
        }

        public void add_Bus()
        {
            m_cc = new BusCAD();
            m_cc.add_Bus(this);
        }

        public void delete_Bus()
        {
            m_cc = new BusCAD();
            m_cc.delete_Bus(this);
        }

        public void update_Bus()
        {
            m_cc = new BusCAD();
            m_cc.update_Bus(this);
        }

        public void search_Bus()
        {
            m_cc = new BusCAD();
            m_cc.search_Bus(this);
        }

        public void show_timetable()
        {
            m_cc = new BusCAD();
            m_cc.show_timetable(this);
        }


        // PROPERTIES
        public int BusID { get; set; }
        public string departureTime { get; set; }
        public string departureCity { get; set; }
        public string arrivalTime { get; set; }
        public string destination { get; set; }
        public int maxpassengers { get; set; }
        public int price { get; set; }

        //Data
        private BusCAD m_cc;

    }
}