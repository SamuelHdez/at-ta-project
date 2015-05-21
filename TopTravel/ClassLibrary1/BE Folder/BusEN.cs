using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace TopTravel
{
    //This clsass represents the entity Bus
    public class BusEN
    {
        //Constructor of the class
        public BusEN()
        {
        }
        //Adds a new bus tho the DB
        public DataSet add_Bus()
        {
            BusCAD c = new BusCAD();
            DataSet ds = c.addBus(this);
            return ds;
        }
        //Removes an existent bus from the DB
        public DataSet delete_Bus(int i)
        {
            BusCAD c = new BusCAD();
            DataSet ds = c.deleteBus(this, i);
            return ds;
        }
        //Updates the information stored about a bus
        public DataSet update_Bus(int i)
        {
            BusCAD c = new BusCAD();
            DataSet ds = c.updateBus(this, i);
            return ds;
        }
        //Looks for all the hotels from an especifc city
        public DataSet searchAllBuses(String city1, String city2)
        {
            BusCAD c = new BusCAD();
            DataSet ds = c.searchBuses(city1, city2);
            return ds;
        }
        //Shearches the information of the bus of the provided id
        public DataSet searchIDBuses(String IDB)
        {
            BusCAD c = new BusCAD();
            DataSet ds = c.searchIDBuses(IDB);
            return ds;
        }
        //Shows all the information about all the buses from the DB
        public DataSet showAllBuses()
        {
            BusCAD c = new BusCAD();
            DataSet ds = c.showBuses(this);
            return ds;
        }

        // PROPERTIES
        private int Id;                 //Is unique id
        private string departureTime;   //The time when it departures
        private string arrivaldTime;    //The time when it arrives
        private string departureCity;   //The city from where it departures
        private string destinationCity; //The city it arrives
        private int price;              //the cost of the travel
        private int company;            //The company that owns the bus
        private int extras;             //The extras the bus might contain
        private string image;           //A representative image of the bus travel

        //Data
        //getters and setters

        public int id                   //Privides the tools for setting and getting the values of the 
        {
            get { return Id; }
            set { Id = value; }
        }

        public string DepartureTime     //Privides the tools for setting and getting the values of the 
        {
            get { return departureTime; }
            set { departureTime = value; }
        }

        public string ArrivaldTime      //Privides the tools for setting and getting the values of the 
        {
            get { return arrivaldTime; }
            set { arrivaldTime = value; }
        }

        public string DepartureCity     //Privides the tools for setting and getting the values of the 
        {
            get { return departureCity; }
            set { departureCity = value; }
        }

        public string DestinationCity   //Privides the tools for setting and getting the values of the 
        {
            get { return destinationCity; }
            set { destinationCity = value; }
        }

        public int Price                //Privides the tools for setting and getting the values of the 
        {
            get { return price; }
            set { price = value; }
        }

        public int Company              //Privides the tools for setting and getting the values of the 
        {
            get { return company; }
            set { company = value; }
        }

        public int Extras               //Privides the tools for setting and getting the values of the 
        {
            get { return extras; }
            set { extras = value; }
        }

        public string Image             //Privides the tools for setting and getting the values of the 
        {
            get { return image; }
            set { image = value; }
        }

    }
}