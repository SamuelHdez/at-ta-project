﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace TopTravel
{
    public class TrainEN
    {
        public TrainEN()
        {
        }

        public DataSet add_Train()
        {
            TrainCAD c = new TrainCAD();
            DataSet ds = c.addTrain(this);
            return ds;
        }

        public DataSet delete_train(int i)
        {
            TrainCAD c = new TrainCAD();
            DataSet ds = c.deleteTrain(this, i);
            return ds;
        }

        public DataSet update_train(int i)
        {
            TrainCAD c = new TrainCAD();
            DataSet ds = c.updateTrain(this, i);
            return ds;
        }

        public DataSet searchAllTrains(String city1, String city2)
        {
            TrainCAD c = new TrainCAD();
            DataSet ds = c.searchTrains(city1, city2);
            return ds;
        }

        public DataSet searchIDTrains(String IDT)
        {
            TrainCAD c = new TrainCAD();
            DataSet ds = c.searchIDTrains(IDT);
            return ds;
        }

        public DataSet showAllTrains()
        {
            TrainCAD c = new TrainCAD();
            DataSet ds = c.showTrains(this);
            return ds;
        }

        // PROPERTIES
        private int Id;
        private string departureTime;
        private string arrivalTime;
        private string departureCity;
        private string destinationCity;
        private int price;
        private int company;
        private int extras;
        private string images;

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

        public int Price
        {
            get { return price; }
            set { price = value; }
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

        public string Images
        {
            get { return images; }
            set { images = value; }
        } 

    }
}