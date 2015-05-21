using System;
using System.Collections;           // Some libraries needed for some utilities we are using
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace TopTravel
{
    public class FlightEN
    {
        public FlightEN()   //Constructor of the class
        {
        }

        // Adds a new entitie of class Flight by calling its respective CAD
        public DataSet add_Flight()
        {
            FlightCAD c = new FlightCAD();
            DataSet ds = c.addFlight(this);
            return ds;
        }

        // Removes an existing entitie of class Flight by calling its respective CAD
        public DataSet delete_Flight(int i)
        {
            FlightCAD c = new FlightCAD();
            DataSet ds = c.deleteFlight(this, i);
            return ds;
        }

        // Updates the information of an existing entitie of class Flight by calling its respective CAD
        public DataSet update_Flight(int i)
        {
            FlightCAD c = new FlightCAD();
            DataSet ds = c.updateFlight(this, i);
            return ds;
        }

        // It shows all the information about the flights which concern the two cities passed by parameter
        public DataSet searchAllFlights(String city1, String city2)
        {
            FlightCAD c = new FlightCAD();
            DataSet ds = c.searchFlights(city1, city2);
            return ds;
        }

        // Searches for a single flight given its id
        public DataSet searchIDFlights(String idF)
        {
            FlightCAD c = new FlightCAD();
            DataSet ds = c.searchIDFlights(idF);
            return ds;
        }

        // Gives all the information about all the flights hosted in the data base
        public DataSet showAllFlights()
        {
            FlightCAD c = new FlightCAD();
            DataSet ds = c.showFlights(this);
            return ds;
        }


        // PROPERTIES
        private int Id;                 //Its id, works as PK in the DB
        private string departureTime;   //Its departure time
        private string arrivalTime;     //Its arrival time
        private string departureCity;   //The city from where the flight departures
        private string destinationCity; //The city where the flight is supposed to arrive
        private string ClassFlight;     //It determines the class of the flght (first class, tourist...)
        private int price;              //The cost of the flight
        private int company;            //The company that offers the flight
        private int extras;             //Possible extras the flight could have
        private string image;           //A representative image of the flight

        //Data
        //getters and setters

        public int id                   //Privides the tools for setting and getting the values of the id
        {
            get { return Id; }
            set { Id = value; }
        }

        public string DepartureTime     //Privides the tools for setting and getting the values of the id
        {
            get { return departureTime; }
            set { departureTime = value; }
        }

        public string ArrivalTime       //Privides the tools for setting and getting the values of the id
        {
            get { return arrivalTime; }
            set { arrivalTime = value; }
        }

        public string DepartureCity     //Privides the tools for setting and getting the values of the id
        {
            get { return departureCity; }
            set { departureCity = value; }
        }

        public string DestinationCity   //Privides the tools for setting and getting the values of the id
        {
            get { return destinationCity; }
            set { destinationCity = value; }
        }

        public string classFlight       //Privides the tools for setting and getting the values of the id
        {
            get { return ClassFlight; }
            set { ClassFlight = value; }
        }

        public int Price                //Privides the tools for setting and getting the values of the id
        {
            get { return price; }
            set { price = value; }
        }

        public int Company              //Privides the tools for setting and getting the values of the id
        {
            get { return company; }
            set { company = value; }
        }

        public int Extras               //Privides the tools for setting and getting the values of the id
        {
            get { return extras; }
            set { extras = value; }
        }

        public string Image             //Privides the tools for setting and getting the values of the id
        {
            get { return image; }
            set { image = value; }
        }
    }
}