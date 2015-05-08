using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace TopTravel
{
    class OrderEN
    {
        public OrderEN(int id, int pro, int pri, int u,int q, string d)
        {
            Id = id;
            Product = pro;
            Price = pri;
            User = u;
            Quantity = q;
            Date = d;
        }

        public void add_Order()
        {
            OrderCAD c = new OrderCAD();
            c.addOrder(this);
        }

        public void delete_Order()
        {
            OrderCAD c = new OrderCAD();
            c.deleteOrder(this);
        }

        public void update_Order()
        {
            OrderCAD c = new OrderCAD();
            c.updateOrder(this);
        }


        public ArrayList showAllProducts()
        {
            ArrayList a = new ArrayList();
            OrderCAD c = new OrderCAD();
            a = c.showOrder();
            return a;
        }

        public ArrayList searchProduct()
        {
            ArrayList a = new ArrayList();
            OrderCAD c = new OrderCAD();
            a = c.searchOrder(this);
            return a;
        }

        // PROPERTIES
        public int Id { get; set; }
        public int Product { get; set; }
        public int Price { get; set; }
        public int User { get; set; }
        public int Quantity { get; set; }
        public string Date { get; set; }
    }
}
