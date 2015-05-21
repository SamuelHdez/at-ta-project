using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace TopTravel
{
    //This clsass represents the entity Space Travel
    public class SpaceTravelEN
    {
        public SpaceTravelEN() //constructor
        {
        }

        public DataSet add_SpaceTravels() //insert a new space travel
       {
           SpaceTravelCAD c = new SpaceTravelCAD();
           DataSet ds = c.addSpaceTravel(this);
           return ds;
       }

       public DataSet delete_SpaceTravels(int i) //delete an existing space travel
       {
           SpaceTravelCAD c = new SpaceTravelCAD();
           DataSet ds = c.deleteSpaceTravel(this, i);
           return ds;
       }

       public DataSet update_SpaceTravels(int i) //update an existing space travel
       {
           SpaceTravelCAD c = new SpaceTravelCAD();
           DataSet ds = c.updateSpaceTravel(this, i);
           return ds;
       }

       public DataSet searchAllSpaceTravels(String city) //search space travels filter by city
       {
           SpaceTravelCAD c = new SpaceTravelCAD();
           DataSet ds = c.searchSpaceTravels(city);
           return ds;
       }

       public DataSet searchIDSpaceTravels(String idH) //search space travels filter by id
       {
           SpaceTravelCAD c = new SpaceTravelCAD();
           DataSet ds = c.searchIDSpaceTravels(idH);
           return ds;
       }

       public DataSet showAllSpaceTravels() //show all the space travels
       {
           SpaceTravelCAD c = new SpaceTravelCAD();
           DataSet ds = c.showSpaceTravels(this);
           return ds;
       }
  
        // PROPERTIES
        private int Id;
        private string departureDate;
        private string arrivalDate;
        private string departureCity;
        private string PreparationCenter;
        private int price;
        private int company;
        private int extras;
        private string images;


        //getters and setters
        public int id
        {
            get { return Id; }
            set { Id = value; }
        }

        public string DepartureDate
        {
            get { return departureDate; }
            set { departureDate = value; }
        }

        public string ArrivalDate
        {
            get { return arrivalDate; }
            set { arrivalDate = value; }
        }

        public string DepartureCity
        {
            get { return departureCity; }
            set { departureCity = value; }
        }

        public string preparationCenter
        {
            get { return PreparationCenter; }
            set { PreparationCenter = value; }
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

        public string Images
        {
            get { return images; }
            set { images = value; }
        } 
    }
}
