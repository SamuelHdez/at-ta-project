using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TopTravel
{
    public class PackagesEN
    {
        public PackagesEN(int id, string n, int t, int h)
        {
            Id = id;
            Name = n;
            Transport = t;
            Hotel = h;
        }

        public void add_pack()
        {
            PackagesCAD c = new PackagesCAD();
            c.add_pack(this);
        }

        public void delete_pack()
        {
            PackagesCAD c = new PackagesCAD();
            c.delete_pack(this);
        }

        // PROPERTIES
        public int Id { get; set; }
        public string Name { get; set; }
        public int Transport { get; set; } // Flight
        public int Hotel { get; set; }

/*
        // claves ajenas a hoteles y transporte que tenga
        public virtual HotelEN Hotel { get; set; } //---------> crear entidad HotelEN
        public virtual FlightEN Flight { get; set; } //-------> crear entidad FlightEN
        public virtual TrainEN Train { get; set; }
        public virtual CruiseEN Cruise { get; set; } //-------> crear entidad FlightEN
        public virtual BusEN Bus { get; set; } //-------------> crear entidad BusEN
*/
    }
}