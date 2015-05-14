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
    }
}
