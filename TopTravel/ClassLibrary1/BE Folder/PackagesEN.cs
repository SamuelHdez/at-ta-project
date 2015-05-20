using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace TopTravel
{
    public class PackagesEN
    {
        public PackagesEN()
        {
        }

        public DataSet add_Packages()
        {
            PackagesCAD c = new PackagesCAD();
            DataSet ds = c.addPackages(this);
            return ds;
        }

        public DataSet delete_Packages(int i)
        {
            PackagesCAD c = new PackagesCAD();
            DataSet ds = c.deletePackages(this, i);
            return ds;
        }

        public DataSet update_Packages(int i)
        {
            PackagesCAD c = new PackagesCAD();
            DataSet ds = c.updatePackages(this, i);
            return ds;
        }

        public DataSet searchAllPackages(String city1, String city2)
        {
            PackagesCAD c = new PackagesCAD();
            DataSet ds = c.searchPackages(city1, city2);
            return ds;
        }

        public DataSet searchIDPackages(String idF)
        {
            PackagesCAD c = new PackagesCAD();
            DataSet ds = c.searchIDPackages(idF);
            return ds;
        }

        public DataSet showAllPackages()
        {
            PackagesCAD c = new PackagesCAD();
            DataSet ds = c.showPackages(this);
            return ds;
        }

        // PROPERTIES
        private int Id;
        private string name;
        private int transport; // Flight
        private int hotel;
        private string image;
        private int price;

        public int id
        {
            get { return Id;}
            set { Id = value; }
        }

        public string Name
        {
            get { return name;}
            set { name = value; }
        }

        public int Transport
        {
            get { return transport;}
            set { transport = value; }
        }

        public int Hotel
        {
            get { return hotel;}
            set { hotel = value; }
        }

        public string Image
        {
            get { return image;}
            set { image = value; }
        }

        public int Price
        {
            get { return price;}
            set { price = value; }
        }
        /*
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
        private int Id;
        private string Name;
        private int Transport; // Flight
        private int Hotel;
        private string image;
        private int price;

        public int Price
        {
            get { return price; }
            set { price = value; }
        }

        public string Image
        {
            get { return image; }
            set { image = value; }
        } 

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