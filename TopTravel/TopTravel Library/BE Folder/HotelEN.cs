using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TopTravel
{
    public class HotelEN
    {

        public HotelEN(int ID=-1, string na="", string ci="", int dy=0, int number=0, string ad="", string e="", int s=0, string b="", string d="")
        {
            id = ID;
            name = na;
            city = ci;
            days = dy;
            phone = number;
            address = ad;
            email = e;
            stars = s;
            bedrooms = b;
            date = d;
        }

       public void add_hotel()
       {
           HotelCAD c = new HotelCAD();
           c.addHotel(this);
       }

       public void delete_hotel()
       {
           HotelCAD c = new HotelCAD();
           c.deleteHotel(this);
       }

       public void update_hotel()
       {
           HotelCAD c = new HotelCAD();
           c.updateHotel(this);
       }

       public ArrayList search_hotel()
       {
           ArrayList a = new ArrayList();
           HotelCAD c = new HotelCAD();
           a = c.searchHotel(this);

           return a;
       }

       public ArrayList showAllHotels()
       {
           ArrayList a = new ArrayList();
           HotelCAD c = new HotelCAD();
           a = c.showHotels();

           return a;
       }

        // PROPERTIES
        private int id;
        private string name;
        private string city;
        private int days;
        private int phone;
        private string address;
        private string email;
        private int stars;
        private string bedrooms;
        private string date;

        //Data
        private HotelCAD m_cc;

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

        public int Days
        {
            get { return days; }
            set { days = value; }
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

        public string Date
        {
            get { return date; }
            set { date = value; }
        }
    }
}