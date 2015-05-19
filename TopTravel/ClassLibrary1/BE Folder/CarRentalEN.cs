using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace TopTravel
{
    public class CarRentalEN
    {
        public CarRentalEN()
        {
        }

        public DataSet add_CarRental()
        {
            CarRentalCAD c = new CarRentalCAD();
            DataSet ds = c.addCarRental(this);
            return ds;
        }

        public DataSet delete_CarRental(int i)
        {
            CarRentalCAD c = new CarRentalCAD();
            DataSet ds = c.deleteCarRental(this, i);
            return ds;
        }

        public DataSet update_CarRental(int i)
        {
            CarRentalCAD c = new CarRentalCAD();
            DataSet ds = c.updateCarRental(this, i);
            return ds;
        }

        public DataSet searchAllCarRental(String city1, String city2)
        {
            CarRentalCAD c = new CarRentalCAD();
            DataSet ds = c.searchCarRental(city1, city2);
            return ds;
        }

        public DataSet searchIDCarRental(String idF)
        {
            CarRentalCAD c = new CarRentalCAD();
            DataSet ds = c.searchIDCarRental(idF);
            return ds;
        }

        public DataSet showAllCarRental()
        {
            CarRentalCAD c = new CarRentalCAD();
            DataSet ds = c.showCarRental(this);
            return ds;
        }


        // PROPERTIES
        private int Id;
        private string City;
        private string Brand;
        private string Model;
        private int Days;
        private int price;
        private int company;
        private int extras;
        private string image;

        //Data
        //getters and setters

        public int id
        {
            get { return Id; }
            set { Id = value; }
        }

        public string city
        {
            get { return City; }
            set { City = value; }
        }

        public string brand
        {
            get { return Brand; }
            set { Brand = value; }
        }

        public string model
        {
            get { return Model; }
            set { Model = value; }
        }

        public int days
        {
            get { return Days; }
            set { Days = value; }
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