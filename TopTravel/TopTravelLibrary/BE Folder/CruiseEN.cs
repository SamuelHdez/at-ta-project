using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace TopTravel
{
    public class CruiseEN
    {
        public CruiseEN(int id, string dT, string r, string aT, string c)
        {
            Id = id;
            departureDate = dT;
            Route = r;
            arrivalDate = aT;
            City = c;
        }

        public void add_Cruise()
        {
            CruiseCAD c = new CruiseCAD();
            c.add_Cruise(this);
        }

        public void delete_Cruise()
        {
            CruiseCAD c = new CruiseCAD();
            c.delete_Cruise(this);
        }

        public void update_Cruise()
        {
            CruiseCAD c = new CruiseCAD();
            c.update_Cruise(this);
        }

        public ArrayList show_All()
        {
            ArrayList a= new ArrayList();
            CruiseCAD c= new CruiseCAD();
            a = c.show_All_Cruises();
            return a;
        }

        public ArrayList search_Cruise()
        {
            ArrayList a = new ArrayList();
            CruiseCAD c = new CruiseCAD();
            a = c.searchCruises(this);
            return a;
        }

        // PROPERTIES
        public int Id { get; set; }
        public string departureDate { get; set; }
        public string Route { get; set; }
        public string City { get; set; }
        public string arrivalDate { get; set; }
    }
}