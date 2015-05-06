using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HadaProject.Models
{
    public class FlightEN
    {

        public FlightEN(int ID, int maxP, int p, string dt, string dc, string at, string d)
        {
            flightID = ID;
            maxpassengers = maxP;
            price = p;
            departureTime = dt;
            departureCity = dc;
            arrivalTime = at;
            destination = d;
        }

        public void add_flight()
        {
            m_cc = new FlightCAD();
            m_cc.add_flight(this);
        }

        public void delete_flight()
        {
            m_cc = new FlightCAD();
            m_cc.delete_flight(this);
        }

        public void update_flight()
        {
            m_cc = new FlightCAD();
            m_cc.update_flight(this);
        }

        public void search_flight()
        {
            m_cc = new FlightCAD();
            m_cc.search_flight(this);
        }

        public void show_timetable()
        {
            m_cc = new FlightCAD();
            m_cc.show_timetable(this);
        }


        // PROPERTIES
        public int flightID { get; set; }
        public string departureTime { get; set; }
        public string departureCity { get; set; }
        public string arrivalTime { get; set; }
        public string destination { get; set; }
        public int maxpassengers { get; set; }
        public int price { get; set; }

        //Data
        private FlightCAD m_cc;
    }
}