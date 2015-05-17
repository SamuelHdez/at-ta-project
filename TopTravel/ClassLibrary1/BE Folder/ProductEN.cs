using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;

namespace TopTravel
{
    public class ProductEN
    {
        public ProductEN()
        {
    
        }

        public void add_product()
        {
            ProductCAD c = new ProductCAD();
            c.addProduct(this);
        }

        public DataSet delete_product(int i)
        {
            ProductCAD c = new ProductCAD();
            DataSet ds = c.deleteProduct(this, i);
            return ds;
        }

        public DataSet update_product(int i)
        {
            ProductCAD c = new ProductCAD();
            DataSet ds = c.updateProduct(this, i);
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

        public DataSet searchAllProducts(String ty)
        {
            ProductCAD c = new ProductCAD();
            DataSet ds = c.searchProducts(ty);
            return ds;
        }

        public DataSet showAllProducts()
        {
            ProductCAD c = new ProductCAD();
            DataSet ds = c.showProducts(this);
            return ds;
        }

        private int id;
        private int company;
        private int extras;

        public int Id
        {
            get { return id; }
            set { id = value; }
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
        /*
        public void add_Product()
        {
            ProductCAD c = new ProductCAD();
            c.addProduct(this);
        }

        public void delete_Product()
        {
            ProductCAD c = new ProductCAD();
            c.deleteProduct(this);
        }

        public void update_Product()
        {
            ProductCAD c = new ProductCAD();
            c.updateProduct(this);
        }

        public DataSet showAllProducts()
        {
            ProductCAD c = new ProductCAD();
            DataSet ds = c.showProduct(this);
            return ds;
        }

        public ArrayList searchProduct()
        {
            ArrayList a = new ArrayList();
            ProductCAD c = new ProductCAD();
            a = c.searchProduct(this);
            return a;
        }

        // PROPERTIES
        public int Id { get; set; }
        public string Price  { get; set; }
        public int Company { get; set; }
        public int Extras { get; set; }
         */ 
    }
}
