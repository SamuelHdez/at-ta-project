using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TopTravel
{
    // o PackageTour o Packageholiday o VacationPackage ...
    public class PackagesEN
    {
        public PackagesEN(int id, string dt, int p, string dp, DateTime d, int nd)
        {
            ID = id;
            Destination = dt;
            Price = p;
            Description = dp;
            Date = d;
            NumDays = nd;
        }

        public void add_pack()
        {
            m_cc = new PackagesCAD();
            m_cc.add_pack(this);
        }

        public void delete_pack()
        {
            m_cc = new PackagesCAD();
            m_cc.add_pack(this);
        }

        // PROPERTIES
        public int ID { get; set; }

        // pricipales caracteristicas
        public string Destination { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int NumDays { get; set; }

        // claves ajenas a hoteles y transporte que tenga
        public virtual HotelEN Hotel { get; set; } //---------> crear entidad HotelEN
        public virtual FlightEN Flight { get; set; } //-------> crear entidad FlightEN
        public virtual TrainEN Train { get; set; }
        public virtual CruiseEN Cruise { get; set; } //-------> crear entidad FlightEN
        public virtual BusEN Bus { get; set; } //-------------> crear entidad BusEN

        // DATA
        private PackagesCAD m_cc;
    }
}