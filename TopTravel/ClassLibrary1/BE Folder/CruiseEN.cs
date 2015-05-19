using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace TopTravel
{
    public class CruiseEN
    {
        public CruiseEN()
        {
        }

        public DataSet add_Cruise()
        {
            CruiseCAD c = new CruiseCAD();
            DataSet ds = c.addCruise(this);
            return ds;
        }

        public DataSet delete_Cruise(int i)
        {
            CruiseCAD c = new CruiseCAD();
            DataSet ds = c.deleteCruise(this, i);
            return ds;
        }

        public DataSet update_Cruise(int i)
        {
            CruiseCAD c = new CruiseCAD();
            DataSet ds = c.updateCruise(this, i);
            return ds;
        }

        public DataSet searchAllCruises(String region, String city)
        {
            CruiseCAD c = new CruiseCAD();
            DataSet ds = c.searchCruises(region, city);
            return ds;
        }

        public DataSet searchIDCruises(String idc)
        {
            CruiseCAD c = new CruiseCAD();
            DataSet ds = c.searchIDCruises(idc);
            return ds;
        }

        public DataSet showAllCruises()
        {
            CruiseCAD c = new CruiseCAD();
            DataSet ds = c.showCruises(this);
            return ds;
        }

        // PROPERTIES
        private int Id;
        private string departureTime;
        private string arrivalTime;
        private string City;
        private string Route;
        private int price;
        private int company;
        private int extras;
        private string image;

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

        public string city
        {
            get { return City; }
            set { City = value; }
        }

        public string route
        {
            get { return Route; }
            set { Route = value; }
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

        public string Image
        {
            get { return image; }
            set { image = value; }
        } 

    }
}