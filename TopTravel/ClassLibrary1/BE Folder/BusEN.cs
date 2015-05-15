using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TopTravel
{
    public class BusEN
    {
        // hay que inicializar las variables? en la base de datos no admitimos nulos porque tiene que estar rellenado.
        // podria haber varios buses on id -1. tenemos que hacer codigo para cuando la id sea -1 no hacer nada en la
        // base de datos
        public BusEN(int ID=-1, string b="", string dt="", string dc="", string at="", string dtc="")
        {
            Id = ID;
            bonus = b;
            departureDate = dt;
            departureCity = dc;
            arrivalDate = at;
            destinationCity = dtc;

        }

        public void add_Bus()
        {
            BusCAD c = new BusCAD();
            c.addBus(this);
        }

        public void delete_Bus()
        {
            BusCAD c = new BusCAD();
            c.deleteBus(this);
        }

        public void update_Bus()
        {
            BusCAD c = new BusCAD();
            c.updateBus(this);
        }

        public ArrayList search_Bus()
        {
            ArrayList a = new ArrayList();
            BusCAD c = new BusCAD();
            a = c.searchBus(this);
            return a;
        }

        public ArrayList showBuses()
        {
            ArrayList a = new ArrayList();
            BusCAD c = new BusCAD();
            a = c.showBuses();
            return a;
        }

        // PROPERTIES
        public int Id { get; set; }
        public string departureDate { get; set; }    
        public string arrivalDate { get; set; }
        public string departureCity { get; set; }
        public string destinationCity { get; set; }
        public string bonus { get; set; }

/* ¿esto sobra no? Lo que esta arriba es azucar sintactico para lo que hay abajo.
    una vez miremos las restricciones de los atributos implementaremos lo que
    necesiten individualmente
        //getters and setters

        public int Id
        {
            get { return id; }
            set { id = value; }
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

        public string DestinationCity
        {
            get { return destinationCity; }
            set { destinationCity = value; }
        }

        public string Bonus
        {
            get { return bonus; }
            set { bonus = value; }
        } */

    }
}