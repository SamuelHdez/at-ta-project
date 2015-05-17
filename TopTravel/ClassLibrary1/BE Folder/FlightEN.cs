using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace TopTravel
{
    public class FlightEN
    {
        public FlightEN()
        {
        }

        public DataSet add_Flight() 
        {
            FlightCAD c = new FlightCAD();
            DataSet ds = c.addFlight(this);
            return ds;
        }

        public DataSet delete_Flight(int i)
        {
            FlightCAD c = new FlightCAD();
            DataSet ds = c.deleteFlight(this, i);
            return ds;
        }

        public DataSet update_Flight(int i)
        {
            FlightCAD c = new FlightCAD();
            DataSet ds = c.updateFlight(this, i);
            return ds;
        }

        public DataSet searchAllFlights(String city1, String city2)
        {
            FlightCAD c = new FlightCAD();
            DataSet ds = c.searchFlights(city1, city2);
            return ds;
        }

        public DataSet showAllFlights()
        {
            FlightCAD c = new FlightCAD();
            DataSet ds = c.showFlights(this);
            return ds;
        }


        // PROPERTIES
        private int Id;
        private string departureTime;
        private string arrivalTime;
        private string departureCity;
        private string destinationCity;
        private string ClassFlight;
        private int price;
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

        public string classFlight
        {
            get { return ClassFlight; }
            set { ClassFlight = value; }
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
    }
}