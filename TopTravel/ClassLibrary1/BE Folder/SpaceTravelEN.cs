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
        private int Id;                     //Its unique id
        private string departureDate;       //the departure time
        private string arrivalDate;         //The arrival time
        private string departureCity;       //Where it will departure
        private string PreparationCenter;   //Its associated preparation center
        private int price;                  //Its price
        private int company;                //Its company
        private int extras;                 //The extras it might have
        private string images;              //The images associated


        //getters and setters
        public int id                   //Privides the tools for setting and getting the values of the 
        {
            get { return Id; }
            set { Id = value; }
        }

        public string DepartureDate     //Privides the tools for setting and getting the values of the 
        {
            get { return departureDate; }
            set { departureDate = value; }
        }

        public string ArrivalDate       //Privides the tools for setting and getting the values of the 
        {
            get { return arrivalDate; }
            set { arrivalDate = value; }
        }

        public string DepartureCity     //Privides the tools for setting and getting the values of the 
        {
            get { return departureCity; }
            set { departureCity = value; }
        }

        public string preparationCenter //Privides the tools for setting and getting the values of the 
        {
            get { return PreparationCenter; }
            set { PreparationCenter = value; }
        }

        public int Price                //Privides the tools for setting and getting the values of the 
        {
            get { return price; }
            set { price = value; }
        }

        public int Company              //Privides the tools for setting and getting the values of the 
        {
            get { return company; }
            set { company = value; }
        }

        public int Extras               //Privides the tools for setting and getting the values of the 
        {
            get { return extras; }
            set { extras = value; }
        }

        public string Images            //Privides the tools for setting and getting the values of the 
        {
            get { return images; }
            set { images = value; }
        } 
    }
}
