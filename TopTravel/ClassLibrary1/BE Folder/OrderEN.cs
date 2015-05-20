using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;



namespace TopTravel
{
    public class OrderEN
    {
        public OrderEN()
        {
        }

        public DataSet add_Order()
        {
            OrderCAD c = new OrderCAD();
            DataSet ds = c.addOrder(this);
            return ds;
        }

        public DataSet delete_Order(int i)
        {
            OrderCAD c = new OrderCAD();
            DataSet ds = c.deleteOrder(this, i);
            return ds;
        }

        public DataSet update_Order(int i)
        {
            OrderCAD c = new OrderCAD();
            DataSet ds = c.updateOrder(this, i);
            return ds;
        }

        public void buy_Order(int i)
        {
            OrderCAD c = new OrderCAD();
            c.buyOrder(this, i);
        }

        public DataSet searchOrders(String user)
        {
            OrderCAD c = new OrderCAD();
            DataSet ds = c.searchUserOrders(user);
            return ds;
        }

        public DataSet searchHistory(String user)
        {
            OrderCAD c = new OrderCAD();
            DataSet ds = c.searchUserHistory(user);
            return ds;
        }

        public DataSet showAllOrders()
        {
            OrderCAD c = new OrderCAD();
            DataSet ds = c.showOrders(this);
            return ds;
        }

        public DataSet countOrders()
        {
            OrderCAD c = new OrderCAD();
            DataSet ds = c.countOrders();
            return ds;
        }

        // PROPERTIES
        private int Id;
        private int Product;
        private string ProductName;
        private int Price;
        private string UserN;
        private int Adults;
        private int Children;
        private int Buy;
        private int TotalPrice;

        //getters and setters

        public int id
        {
            get { return Id; }
            set { Id = value; }
        }

        public int product
        {
            get { return Product; }
            set { Product = value; }
        }

        public string productName
        {
            get { return ProductName; }
            set { ProductName = value; }
        }

        public int price
        {
            get { return Price; }
            set { Price = value; }
        }

        public string userN
        {
            get { return UserN; }
            set { UserN = value; }
        }

        public int adults
        {
            get { return Adults; }
            set { Adults = value; }
        }

        public int children
        {
            get { return Children; }
            set { Children = value; }
        }

        public int buy
        {
            get { return Buy; }
            set { Buy = value; }
        }

        public int totalPrice
        {
            get { return TotalPrice; }
            set { TotalPrice = value; }
        }
    }
}
