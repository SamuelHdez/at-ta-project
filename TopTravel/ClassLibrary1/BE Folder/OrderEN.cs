using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;



namespace TopTravel
{
    //This clsass represents the entity Order
    public class OrderEN
    {
        public OrderEN() //constructor
        {
        }

        public DataSet add_Order() //insert new order
        {
            OrderCAD c = new OrderCAD();
            DataSet ds = c.addOrder(this);
            return ds;
        }

        public DataSet delete_Order(int i) //delete an existing order
        {
            OrderCAD c = new OrderCAD();
            DataSet ds = c.deleteOrder(this, i);
            return ds;
        }

        public DataSet update_Order(int i) //update an existing order
        {
            OrderCAD c = new OrderCAD();
            DataSet ds = c.updateOrder(this, i);
            return ds;
        }

        public void buy_Order(int i) //from the shopping cart to the history
        {
            OrderCAD c = new OrderCAD();
            c.buyOrder(this, i);
        }

        public DataSet searchOrders(String user) //search orders filter by users
        {
            OrderCAD c = new OrderCAD();
            DataSet ds = c.searchUserOrders(user);
            return ds;
        }

        public DataSet searchHistory(String user) //search history cart filter by users
        {
            OrderCAD c = new OrderCAD();
            DataSet ds = c.searchUserHistory(user);
            return ds;
        }

        public DataSet showAllOrders() //show all the orders
        {
            OrderCAD c = new OrderCAD();
            DataSet ds = c.showOrders(this);
            return ds;
        }

        public DataSet countOrders() //for create the id
        {
            OrderCAD c = new OrderCAD();
            DataSet ds = c.countOrders();
            return ds;
        }

        // PROPERTIES
        private int Id;             //Its unique id
        private int Product;        //Its associated product
        private string ProductName; //Its product name
        private int Price;          //Its Price
        private string UserN;       //The user that bought it
        private int Adults;         //Number of adults
        private int Children;       //Number of children
        private int Buy;            //Indicates wheter i is in the shopping chart or in the history
        private int TotalPrice;     //The price once applied the discount

        //getters and setters

        public int id                       //Privides the tools for setting and getting the values of the id
        {
            get { return Id; }
            set { Id = value; }
        }

        public int product                  //Privides the tools for setting and getting the values of the product
        {
            get { return Product; }
            set { Product = value; }
        }

        public string productName           //Privides the tools for setting and getting the values of the product name
        {
            get { return ProductName; }
            set { ProductName = value; }
        }

        public int price                    //Privides the tools for setting and getting the values of the price
        {
            get { return Price; }
            set { Price = value; }
        }

        public string userN                 //Privides the tools for setting and getting the values of the user name
        {
            get { return UserN; }
            set { UserN = value; }
        }

        public int adults                   //Privides the tools for setting and getting the values of the number of adults
        {
            get { return Adults; }
            set { Adults = value; }
        }

        public int children                 //Privides the tools for setting and getting the values of the number of children
        {
            get { return Children; }
            set { Children = value; }
        }

        public int buy                      //Privides the tools for setting and getting the values of the variable buy
        {
            get { return Buy; }
            set { Buy = value; }
        }

        public int totalPrice               //Privides the tools for setting and getting the values of the total price
        {
            get { return TotalPrice; }
            set { TotalPrice = value; }
        }
    }
}
