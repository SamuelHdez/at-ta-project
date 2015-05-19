using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TopTravel
{
    public class CarRentalEN
    {
        public CarRentalEN(int ID, string c, string b, string m, int d, string D)
        {
            Id = ID;
            City = c;
            Brand = b;
            Model = m;
            Days = d;
            Date = D;
        }

        public void add_CarRental()
		{
			CarRentalCAD c = new CarRentalCAD();
			c.add_CarRental(this);
		}

        public void update_CarRental()
		{
            CarRentalCAD c = new CarRentalCAD();
			c.update_CarRental(this);
		}

        public void delete_CarRental()
		{
            CarRentalCAD c = new CarRentalCAD();
			c.delete_CarRental(this);
		}

        public ArrayList showAllCarRental()
        {
            ArrayList a = new ArrayList();
            CarRentalCAD c = new CarRentalCAD();
            a = c.showCarRental();
            return a;
        }

        public ArrayList searchCarRental()
		{
            ArrayList a = new ArrayList();
            CarRentalCAD c = new CarRentalCAD();
            a = c.search_CarRental(this);
            return a;
		}

        // PROPERTIES
        private int Id;
        private string City;
        private string Brand;
        private string Model;
        private int Days;
        private string Date;
        private int price;
        private int company;
        private int extras;
        private string image;

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
