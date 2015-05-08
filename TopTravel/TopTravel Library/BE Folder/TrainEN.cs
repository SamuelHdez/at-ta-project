﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TopTravel
{
    public class TrainEN
    {

        public TrainEN(int ID = -1, string b = "", string dt = "", string dc = "", string at = "", string dtc = "")
        {
            id = ID;
            Bonus = b;
            departureDay = dt;
            departureCity = dc;
            arrivalDay = at;
            destinationCity = dtc;

        }

        public void add_Train()
        {
            TrainCAD c = new TrainCAD();
            c.addTrain(this);
        }

        public void delete_Train()
        {
            TrainCAD c = new TrainCAD();
            c.deleteTrain(this);
        }

        public void update_Train()
        {
            TrainCAD c = new TrainCAD();
            c.updateTrain(this);
        }

        public ArrayList search_Train()
        {
            ArrayList a = new ArrayList();
            TrainCAD c = new TrainCAD();
            a = c.searchTrain(this);

            return a;
        }

        public ArrayList showTrains()
        {
            ArrayList a = new ArrayList();
            TrainCAD c = new TrainCAD();
            a = c.showTrains();

            return a;
        }

        // PROPERTIES
        public int id;
        public string departureDay;
        public string departureCity;
        public string arrivalDay;
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

        public string DepartureDay
        {
            get { return departureDay; }
            set { departureDay = value; }
        }

        public string ArrivalDay
        {
            get { return arrivalDay; }
            set { arrivalDay = value; }
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