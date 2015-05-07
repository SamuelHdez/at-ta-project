using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TopTravel
{
    public class BusEN
    {

        public BusEN(int ID, string b, string dt, string dc, string at, string dtc)
        {
            BusID = ID;
            Bonus = b;
            departureTime = dt;
            departureCity = dc;
            arrivalTime = at;
            destinationCity = dtc;

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

        // PROPERTIES
        public int BusID { get; set; }
        public string departureTime { get; set; }
        public string departureCity { get; set; }
        public string arrivalTime { get; set; }
        public string destinationCity { get; set; }
        public string Bonus { get; set; }

        //Data
        private BusCAD m_cc;

    }
}