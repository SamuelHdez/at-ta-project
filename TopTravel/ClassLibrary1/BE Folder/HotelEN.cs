using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace TopTravel
{
    public class HotelEN
    {
        //Constructor of the class
        public HotelEN()
        {
        }
        //Adds a new hotel to the DB
        public DataSet add_hotel()
        {
            HotelCAD c = new HotelCAD();
            DataSet ds = c.addHotel(this);
            return ds;
        }
        //Removes an existent hotel from the DB
        public DataSet delete_hotel(int i)
        {
            HotelCAD c = new HotelCAD();
            DataSet ds = c.deleteHotel(this, i);
            return ds;
        }
        //Updates the information stored about a hotel
        public DataSet update_hotel(int i)
        {
            HotelCAD c = new HotelCAD();
            DataSet ds = c.updateHotel(this, i);
            return ds;
        }
        // TO-DO : Figure out how to implement this using disconnected db
        /*       public ArrayList search_hotel()  
               {
                   ArrayList a = new ArrayList();
                   HotelCAD c = new HotelCAD();
                   a = c.searchHotel(this);
                   return a;
               }*/
        //Looks for all the hotels from an especifc city
        public DataSet searchAllHotels(String city)
        {
            HotelCAD c = new HotelCAD();
            DataSet ds = c.searchHotels(city);
            return ds;
        }
        //Shearches the information of the hotel of the provided id
        public DataSet searchIDHotels(String idH)
        {
            HotelCAD c = new HotelCAD();
            DataSet ds = c.searchIDHotels(idH);
            return ds;
        }
        //Shows all the information about all the hotels from the DB
        public DataSet showAllHotels()
        {
            HotelCAD c = new HotelCAD();
            DataSet ds = c.showHotels(this);
            return ds;
        }
        /*
               // PROPERTIES
               public int Id;
               public string Name;
               public string City;
               public int Days;
               public int Phone;
               public string Address;
               public string Email;
               public int Stars;
               public string Bedrooms;
               public string Date;
        */
        // PROPERTIES
        private int id;             //Its unique id
        private string name;        //Its name
        private string city;        //Its city
        private int phone;          //Its phone number
        private string address;     //Its address
        private string email;       //Its email
        private int stars;          //The nomber of stars
        private string bedrooms;    //The number of bedrooms
        private int price;          //Its price
        private int company;        //The company that owns the hotel
        private int extras;         //The extras that the hotel might have
        private string image;       //A representative image of the hotel

        //Getters and setters
        public int Id               //Privides the tools for setting and getting the values of the id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name          //Privides the tools for setting and getting the values of the name
        {
            get { return name; }
            set { name = value; }
        }

        public string City          //Privides the tools for setting and getting the values of the city
        {
            get { return city; }
            set { city = value; }
        }

        public int Phone            //Privides the tools for setting and getting the values of the phone
        {
            get { return phone; }
            set { phone = value; }
        }

        public string Address       //Privides the tools for setting and getting the values of the address
        {
            get { return address; }
            set { address = value; }
        }

        public string Email         //Privides the tools for setting and getting the values of the email
        {
            get { return email; }
            set { email = value; }
        }

        public int Stars            //Privides the tools for setting and getting the values of the stars
        {
            get { return stars; }
            set { stars = value; }
        }

        public string Bedrooms      //Privides the tools for setting and getting the values of the bedrooms
        {
            get { return bedrooms; }
            set { bedrooms = value; }
        }

        public int Price            //Privides the tools for setting and getting the values of the price
        {
            get { return price; }
            set { price = value; }
        }

        public int Company          //Privides the tools for setting and getting the values of the company
        {
            get { return company; }
            set { company = value; }
        }

        public int Extras           //Privides the tools for setting and getting the values of the extras
        {
            get { return extras; }
            set { extras = value; }
        }

        public string Image         //Privides the tools for setting and getting the values of the image
        {
            get { return image; }
            set { image = value; }
        }

    }
}