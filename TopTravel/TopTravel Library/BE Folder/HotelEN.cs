using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TopTravel
{
    public class HotelEN
    {

        public HotelEN(int ID, string ci, string co, int number, string at, string dt, int r, int pr, int stars, string serv)
        {
            hotelID = ID;
            city = ci;
            country = co;
            phone = number;
            arrivalTime = at;
            departureTime = dt;
            rooms = r;
            price = pr;
            category = stars;
            services = serv;
        }

       public void add_hotel()
       {
           m_cc = new HotelCAD();
           m_cc.add_hotel(this);
       }

       public void delete_hotel()
       {
           m_cc = new HotelCAD();
           m_cc.delete_hotel(this);
       }

       public void update_hotel()
       {
           m_cc = new HotelCAD();
           m_cc.update_hotel(this);
       }

       public void search_hotel()
       {
           m_cc = new HotelCAD();
           m_cc.search_hotel(this);
       }

        // PROPERTIES
        public int hotelID { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public int phone { get; set; }
        public string arrivalTime { get; set; }
        public string departureTime { get; set; }
        public int rooms { get; set; }
        public int price { get; set; }
        public int category { get; set; } //stars
        public string services { get; set; }

        //Data
        private HotelCAD m_cc;

    }
}