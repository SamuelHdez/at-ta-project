using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace TopTravel
{
    //This clsass represents the entity Train
    public class TrainEN
    {
        public TrainEN() //constructor
        {
        }

        public DataSet add_Train() //insert a new train
        {
            TrainCAD c = new TrainCAD();
            DataSet ds = c.addTrain(this);
            return ds;
        }

        public DataSet delete_train(int i) //delete an existing train
        {
            TrainCAD c = new TrainCAD();
            DataSet ds = c.deleteTrain(this, i);
            return ds;
        }

        public DataSet update_train(int i) //update an existing train
        {
            TrainCAD c = new TrainCAD();
            DataSet ds = c.updateTrain(this, i);
            return ds;
        }

        public DataSet searchAllTrains(String city1, String city2) //search trains filter by origin and destination
        {
            TrainCAD c = new TrainCAD();
            DataSet ds = c.searchTrains(city1, city2);
            return ds;
        }

        public DataSet searchIDTrains(String IDT) //search trains filter by id
        {
            TrainCAD c = new TrainCAD();
            DataSet ds = c.searchIDTrains(IDT);
            return ds;
        }

        public DataSet showAllTrains() //show all the trains
        {
            TrainCAD c = new TrainCAD();
            DataSet ds = c.showTrains(this);
            return ds;
        }

        // PROPERTIES
        private int Id;                 //Its unique id
        private string departureTime;   //The departure time
        private string arrivalTime;     //The arrival time
        private string departureCity;   //The departure city
        private string destinationCity; //The arrival city
        private int price;              //Its price
        private int company;            //Its company
        private int extras;             //The extras it might have
        private string images;          //A bunch of representative images of the train

        //getters and setters

        public int id                   //Privides the tools for setting and getting the values of the id
        {
            get { return Id; }
            set { Id = value; }
        }

        public string DepartureTime     //Privides the tools for setting and getting the values of the departure time
        {
            get { return departureTime; }
            set { departureTime = value; }
        }

        public string ArrivalTime       //Privides the tools for setting and getting the values of the arrival time
        {
            get { return arrivalTime; }
            set { arrivalTime = value; }
        }

        public string DepartureCity     //Privides the tools for setting and getting the values of the departure city
        {
            get { return departureCity; }
            set { departureCity = value; }
        }

        public string DestinationCity   //Privides the tools for setting and getting the values of the destination city
        {
            get { return destinationCity; }
            set { destinationCity = value; }
        }

        public int Price                //Privides the tools for setting and getting the values of the price
        {
            get { return price; }
            set { price = value; }
        }

        public int Company              //Privides the tools for setting and getting the values of the company
        {
            get { return company; }
            set { company = value; }
        }

        public int Extras               //Privides the tools for setting and getting the values of the extras
        {
            get { return extras; }
            set { extras = value; }
        }

        public string Images            //Privides the tools for setting and getting the values of the images
        {
            get { return images; }
            set { images = value; }
        } 

    }
}