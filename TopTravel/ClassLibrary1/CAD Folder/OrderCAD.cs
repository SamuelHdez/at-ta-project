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
    class OrderCAD
    {

        public DataSet searchUserOrders(String name)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            DataSet virtdb = new DataSet();
            SqlConnection c = new SqlConnection(s);

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * from OrderList where UserN = '" + name + "' and Buy = '0'", c);
                da.Fill(virtdb, "order");

            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: show order");
            }
            finally
            {
                c.Close();
            }
            return virtdb;

        }

        public DataSet searchUserHistory(String name)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            DataSet virtdb = new DataSet();
            SqlConnection c = new SqlConnection(s);

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * from OrderList where UserN = '" + name + "' and Buy = '1'", c);
                da.Fill(virtdb, "order");

            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: show order");
            }
            finally
            {
                c.Close();
            }
            return virtdb;

        }

        public DataSet showOrders(OrderEN o)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            DataSet virtdb = new DataSet();
            SqlConnection c = new SqlConnection(s);

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from OrderList", c);
                da.Fill(virtdb, "order");

            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: show order");
            }
            finally
            {
                c.Close();
            }
            return virtdb;

        }

        public DataSet countOrders()
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            DataSet virtdb = new DataSet();
            SqlConnection c = new SqlConnection(s);

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select count(*)+1 from OrderList", c);
                da.Fill(virtdb, "order");

            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: show order");
            }
            finally
            {
                c.Close();
            }
            return virtdb;

        }

        public DataSet addOrder(OrderEN o)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            DataSet virtdb = new DataSet();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from OrderList", c);
                da.Fill(virtdb, "order");
                DataTable dt = new DataTable();
                dt = virtdb.Tables["order"];
                DataRow newRow = dt.NewRow();
                newRow[0] = o.id;
                newRow[1] = o.product;
                newRow[2] = o.productName;
                newRow[3] = o.price;
                newRow[4] = o.userN;
                newRow[5] = o.adults;
                newRow[6] = o.children;
                newRow[7] = o.buy;
                newRow[8] = o.totalPrice;
                dt.Rows.Add(newRow);
                SqlCommandBuilder cbuilder = new SqlCommandBuilder(da);
                da.Update(virtdb, "order");
            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: Add order");
            }
            finally
            {
                c.Close();
            }

            return virtdb;
        }


        public DataSet deleteOrder(OrderEN o, int i) // It will delete the index passed in the view
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            DataSet virtdb = new DataSet();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from OrderList", c);
                da.Fill(virtdb, "order");
                DataTable t = new DataTable();
                t = virtdb.Tables["order"];

                t.Rows[i].Delete();

                SqlCommandBuilder cbuilder = new SqlCommandBuilder(da);
                da.Update(virtdb, "order");
            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: Delete order");
            }
            finally
            {
                c.Close();
            }
            return virtdb;
        }

        public DataSet updateOrder(OrderEN o, int i)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            DataSet virtdb = new DataSet();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from OrderList", c);
                da.Fill(virtdb, "order");
                DataTable t = new DataTable();
                t = virtdb.Tables["order"];

                t.Rows[i]["Id"] = o.id;
                t.Rows[i]["Product"] = o.product;
                t.Rows[i]["ProductName"] = o.productName;
                t.Rows[i]["Price"] = o.price;
                t.Rows[i]["UserN"] = o.userN;
                t.Rows[i]["Adults"] = o.adults;
                t.Rows[i]["Children"] = o.children;
                t.Rows[i]["Buy"] = o.buy;
                t.Rows[i]["TotalPrice"] = o.totalPrice;

                SqlCommandBuilder cbuilder = new SqlCommandBuilder(da);
                da.Update(virtdb, "order");
            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: Delete order");
            }
            finally
            {
                c.Close();
            }
            return virtdb;
        }

        public DataSet buyOrder(OrderEN o, int i)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            DataSet virtdb = new DataSet();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from OrderList", c);
                da.Fill(virtdb, "order");
                DataTable t = new DataTable();
                t = virtdb.Tables["order"];

                t.Rows[i]["Buy"] = o.buy;

                SqlCommandBuilder cbuilder = new SqlCommandBuilder(da);
                da.Update(virtdb, "order");
            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: Delete order");
            }
            finally
            {
                c.Close();
            }
            return virtdb;
        }
    }
}
