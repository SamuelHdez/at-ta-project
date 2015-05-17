﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace TopTravel
{
    public class BusEN
    {
        public BusEN()
        {
        }

        public void add_Bus()
        {
            BusCAD c = new BusCAD();
            c.addBus(this);
        }

        public DataSet delete_Bus(int i)
        {
            BusCAD c = new BusCAD();
            DataSet ds = c.deleteBus(this, i);
            return ds;
        }

        public DataSet update_Bus(int i)
        {
            BusCAD c = new BusCAD();
            DataSet ds = c.updateBus(this, i);
            return ds;
        }

        public DataSet searchAllBuses(String city1, String city2)
        {
            BusCAD c = new BusCAD();
            DataSet ds = c.searchBuses(city1, city2);
            return ds;
        }

        public DataSet showAllBuses()
        {
            BusCAD c = new BusCAD();
            DataSet ds = c.showBuses(this);
            return ds;
        }

        // PROPERTIES
        private int Id;
        private string departureTime;
        private string arrivalTime;
        private string departureCity;
        private string destinationCity;
        private string bonus;
        private int company;
        private int extras;

        //Data
        //getters and setters

        public int id
        {
            get { return Id; }
            set { Id = value; }
        }

        public string DepartureTime
        {
            get { return departureTime; }
            set { departureTime = value; }
        }

        public string ArrivalTime
        {
            get { return arrivalTime; }
            set { arrivalTime = value; }
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
            get { return Bonus; }
            set { Bonus = value; }
        }

        public int Company
        {
            get { return company; }
            set { company = value; }
        }

        public int Extras
        {
            get { return extras; }
            set { extras = value; }
        } 

    }
}