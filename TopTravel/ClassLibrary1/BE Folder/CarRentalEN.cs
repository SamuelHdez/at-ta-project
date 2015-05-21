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
        //Constructor of the class
        public CarRentalEN()
        {
        }
        //Adds a new car to the DB
        public DataSet add_CarRental()
        {
            CarRentalCAD c = new CarRentalCAD();
            DataSet ds = c.addCarRental(this);
            return ds;
        }
        //Removes an existent car from the DB
        public DataSet delete_CarRental(int i)
        {
            CarRentalCAD c = new CarRentalCAD();
            DataSet ds = c.deleteCarRental(this, i);
            return ds;
        }
        //Updates the information stored about a car
        public DataSet update_CarRental(int i)
        {
            CarRentalCAD c = new CarRentalCAD();
            DataSet ds = c.updateCarRental(this, i);
            return ds;
        }
        //Shearches the cars given the city and the brand
        public DataSet searchAllCarRental(String city, String brand)
        {
            CarRentalCAD c = new CarRentalCAD();
            DataSet ds = c.searchCarRental(city, brand);
            return ds;
        }
        //Shearch by id
        public DataSet searchIDCarRental(String idF)
        {
            CarRentalCAD c = new CarRentalCAD();
            DataSet ds = c.searchIDCarRental(idF);
            return ds;
        }
        //Show all information about all cars
        public DataSet showAllCarRental()
        {
            CarRentalCAD c = new CarRentalCAD();
            DataSet ds = c.showCarRental(this);
            return ds;
        }


        // PROPERTIES
        private int Id;         //Its unique id
        private string City;    //Its city where it is located
        private string Brand;   //Its brand
        private string Model;   //Its model
        private int Days;       //The number of days rented
        private int price;      //Its price
        private int company;    //The company that owns the car
        private int extras;     //The extras the car might have
        private string image;   //A representative image of the car

        //Data
        //getters and setters

        public int id           //Privides the tools for setting and getting the values of the id
        {
            get { return Id; }
            set { Id = value; }
        }

        public string city      //Privides the tools for setting and getting the values of the city
        {
            get { return City; }
            set { City = value; }
        }

        public string brand     //Privides the tools for setting and getting the values of the brand
        {
            get { return Brand; }
            set { Brand = value; }
        }

        public string model     //Privides the tools for setting and getting the values of the model
        {
            get { return Model; }
            set { Model = value; }
        }

        public int days         //Privides the tools for setting and getting the values of the days
        {
            get { return Days; }
            set { Days = value; }
        }

        public int Price        //Privides the tools for setting and getting the values of the price
        {
            get { return price; }
            set { price = value; }
        }

        public int Company      //Privides the tools for setting and getting the values of the company
        {
            get { return company; }
            set { company = value; }
        }

        public int Extras       //Privides the tools for setting and getting the values of the extras
        {
            get { return extras; }
            set { extras = value; }
        }

        public string Image     //Privides the tools for setting and getting the values of the image
        {
            get { return image; }
            set { image = value; }
        }
    }
}