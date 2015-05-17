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
        
        public HotelEN()
        {
        }
        
       public DataSet add_hotel()
       {
           HotelCAD c = new HotelCAD();
           DataSet ds = c.addHotel(this);
           return ds;
       }

       public DataSet delete_hotel(int i)
       {
           HotelCAD c = new HotelCAD();
           DataSet ds = c.deleteHotel(this, i);
           return ds;
       }

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

       public DataSet searchAllHotels(String city)
       {
           HotelCAD c = new HotelCAD();
           DataSet ds = c.searchHotels(city);
           return ds;
       }

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
        private int id;
        private string name;
        private string city;
        private int phone;
        private string address;
        private string email;
        private int stars;
        private string bedrooms;
        private int price;
        private int company;
        private int extras;

        //Getters and setters
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string City
        {
            get { return city; }
            set { city = value; }
        }

        public int Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public int Stars
        {
            get { return stars; }
            set { stars = value; }
        }

        public string Bedrooms
        {
            get { return bedrooms; }
            set { bedrooms = value; }
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