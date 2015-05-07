using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TopTravel
{
    public class CruiseEN
    {
        public CruiseEN(int id, string dT, string dD, string tR, string aT, string aD, int mP, int p)
        {
            cruiseID = id;
            departureTime = dT;
            departureDay = dD;
            travelRoute = tR;
            arrivalTime = aT;
            arrivalDate = aD;
            maxPassengers = mP;
            int price = p;
        }

        public void add_Cruise()
        {
            m_cc = new CruiseCAD();
            m_cc.add_Cruise(this);
        }

        public void delete_Cruise()
        {
            m_cc = new CruiseCAD();
            m_cc.delete_Cruise(this);
        }

        public void update_Cruise()
        {
            m_cc = new CruiseCAD();
            m_cc.update_Cruise(this);
        }

        public void search_Cruise()
        {
            m_cc = new CruiseCAD();
            m_cc.search_Cruise(this);
        }

        // PROPERTIES
        public int cruiseID { get; set; }
        public string departureTime { get; set; }
        public string departureDay { get; set; }
        public string travelRoute { get; set; }
        public string arrivalTime { get; set; }
        public string arrivalDate { get; set; }
        public int maxPassengers { get; set; }
        public int price { get; set; }

        //Data
        private CruiseCAD m_cc;

    }
}