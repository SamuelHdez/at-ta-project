using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace TopTravel
{
    //This clsass represents the entity Cruise
    public class CruiseEN
    {
        public CruiseEN() //constructor
        {
        }
        //Adds a new Cruise to the DB
        public DataSet add_Cruise()
        {
            CruiseCAD c = new CruiseCAD();
            DataSet ds = c.addCruise(this);
            return ds;
        }
        //Removes a cruise from the DB given its id
        public DataSet delete_Cruise(int i)
        {
            CruiseCAD c = new CruiseCAD();
            DataSet ds = c.deleteCruise(this, i);
            return ds;
        }
        //Updates the information about a cruise from the DB provided its id
        public DataSet update_Cruise(int i)
        {
            CruiseCAD c = new CruiseCAD();
            DataSet ds = c.updateCruise(this, i);
            return ds;
        }
        //Show the information about the crouises that match with the region and city provided
        public DataSet searchAllCruises(String region, String city)
        {
            CruiseCAD c = new CruiseCAD();
            DataSet ds = c.searchCruises(region, city);
            return ds;
        }
        //Shearch information about a cruise given its id
        public DataSet searchIDCruises(String idc)
        {
            CruiseCAD c = new CruiseCAD();
            DataSet ds = c.searchIDCruises(idc);
            return ds;
        }
        //Shows all the information about all the cruises from the DB
        public DataSet showAllCruises() //show all cruises
        {
            CruiseCAD c = new CruiseCAD();
            DataSet ds = c.showCruises(this);
            return ds;
        }

        // PROPERTIES
        private int Id;                 //Its unique id
        private string departureTime;   //The time the cruise departures
        private string arrivalTime;     //The rime the crouse arrives
        private string City;            //The city where it departures and arrives after doing its route
        private string Route;           //The route the crouise is going to do
        private int price;              //Its price for the clients
        private int company;            //The company tha t provides the cruise
        private int extras;             //THe extras the cruise might have
        private string image;           //A representative image about the cruise

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

        public string city              //Privides the tools for setting and getting the values of the city
        {
            get { return City; }
            set { City = value; }
        }

        public string route             //Privides the tools for setting and getting the values of the route
        {
            get { return Route; }
            set { Route = value; }
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

        public string Image             //Privides the tools for setting and getting the values of the image
        {
            get { return image; }
            set { image = value; }
        } 

    }
}