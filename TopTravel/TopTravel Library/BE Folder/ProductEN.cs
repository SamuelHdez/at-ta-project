using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace TopTravel
{
    class ProductEN
    {
        public ProductEN(int id, string p, int c, int e)
        {
            Id = id;
            Price = p;
            Company = c;
            Extras = e;      
        }


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


        public ArrayList showAllProducts()
        {
            ArrayList a = new ArrayList();
            ProductCAD c = new ProductCAD();
            a = c.showProduct();
            return a;
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
    }
}
