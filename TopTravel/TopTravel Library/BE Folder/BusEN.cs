using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TopTravel
{
    public class BusEN
    {

        public BusEN(int ID=-1, string b="", string dt="", string dc="", string at="", string dtc="")
        {
            id = ID;
            Bonus = b;
            departureDate = dt;
            departureCity = dc;
            arrivalDate = at;
            destinationCity = dtc;

        }

        public void add_Bus()
        {
            BusCAD c = new BusCAD();
            c.addBus(this);
        }

        public void delete_Bus()
        {
            BusCAD c = new BusCAD();
            c.deleteBus(this);
        }

        public void update_Bus()
        {
            BusCAD c = new BusCAD();
            c.updateBus(this);
        }

        public ArrayList search_Bus()
        {
            ArrayList a = new ArrayList();
            BusCAD c = new BusCAD();
            a = c.searchBus(this);

            return a;
        }

        public ArrayList showBuses()
        {
            ArrayList a = new ArrayList();
            BusCAD c = new BusCAD();
            a = c.showBuses();

            return a;
        }

        // PROPERTIES
        public int id;
        public string departureDate;
        public string departureCity;
        public string arrivalDate;
        public string destinationCity;
        public string bonus;

        //Data
        private BusCAD m_cc;

        //getters and setters

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string DepartureDate
        {
            get { return departureDate; }
            set { departureDate = value; }
        }

        public string ArrivalDate
        {
            get { return arrivalDate; }
            set { arrivalDate = value; }
        }

        public string DepartureCity
        {
            get { return departureCity; }
            set { departureCity = value; }
        }

        public string DestinationCity
        {
            get { return destinationCity; }
            set { destinationCity = value; }
        }

        public string Bonus
        {
            get { return bonus; }
            set { bonus = value; }
        }

    }
}