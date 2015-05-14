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
        public int Id { get; set; }
        public string City { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Days { get; set; }
        public string Date { get; set; }
    }
}
