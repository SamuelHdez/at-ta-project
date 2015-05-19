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
    public class BusCAD
    {
        public DataSet showBuses(BusEN b)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            DataSet virtdb = new DataSet();
            SqlConnection c = new SqlConnection(s);

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from Bus", c);
                da.Fill(virtdb, "bus");

            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: show bus");
            }
            finally
            {
                c.Close();
            }
            return virtdb;

        }

        public DataSet searchBuses(String b1, String b2)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            DataSet virtdb = new DataSet();
            SqlConnection c = new SqlConnection(s);

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * from Bus where departureCity LIKE '%" + b1 + "%' and destinationCity LIKE '%" + b2 + "%'", c);
                da.Fill(virtdb, "bus");

            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: show bus");
            }
            finally
            {
                c.Close();
            }
            return virtdb;

        }

        public DataSet searchIDBuses(String IDB)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            DataSet virtdb = new DataSet();
            SqlConnection c = new SqlConnection(s);

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * from Bus where Id = '" + IDB + "'", c);
                da.Fill(virtdb, "bus");

            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: show bus");
            }
            finally
            {
                c.Close();
            }
            return virtdb;

        }


        public DataSet addBus(BusEN b)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            DataSet virtdb = new DataSet();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from Bus", c);
                da.Fill(virtdb, "bus");
                DataTable dt = new DataTable();
                dt = virtdb.Tables["bus"];
                DataRow newRow = dt.NewRow();
                newRow[0] = b.id;
                newRow[1] = b.DepartureTime;
                newRow[2] = b.ArrivaldTime;
                newRow[3] = b.DepartureCity;
                newRow[4] = b.DestinationCity;
                newRow[5] = b.Price;
                newRow[6] = b.Company;
                newRow[7] = b.Extras;
                newRow[8] = b.Image;
                dt.Rows.Add(newRow);
                SqlCommandBuilder cbuilder = new SqlCommandBuilder(da);
                da.Update(virtdb, "bus");
            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: Add bus");
            }
            finally
            {
                c.Close();
            }

            return virtdb;
        }


        public DataSet deleteBus(BusEN b, int i) // It will delete the index passed in the view
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            DataSet virtdb = new DataSet();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from Bus", c);
                da.Fill(virtdb, "bus");
                DataTable t = new DataTable();
                t = virtdb.Tables["bus"];

                t.Rows[i].Delete();

                SqlCommandBuilder cbuilder = new SqlCommandBuilder(da);
                da.Update(virtdb, "bus");
            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: Delete bus");
            }
            finally
            {
                c.Close();
            }
            return virtdb;
        }

        public DataSet updateBus(BusEN b, int i)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            DataSet virtdb = new DataSet();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from Bus", c);
                da.Fill(virtdb, "bus");
                DataTable t = new DataTable();
                t = virtdb.Tables["bus"];

                t.Rows[i]["Id"] = b.id;
                t.Rows[i]["departureTime"] = b.DepartureTime;
                t.Rows[i]["arrivaldTime"] = b.ArrivaldTime;
                t.Rows[i]["departureCity"] = b.DepartureCity;
                t.Rows[i]["destinationCity"] = b.DestinationCity;
                t.Rows[i]["price"] = b.Price;
                t.Rows[i]["company"] = b.Company;
                t.Rows[i]["extras"] = b.Extras;
                t.Rows[i]["image"] = b.Image;


                SqlCommandBuilder cbuilder = new SqlCommandBuilder(da);
                da.Update(virtdb, "bus");
            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: Delete bus");
            }
            finally
            {
                c.Close();
            }
            return virtdb;


        }
        /*
        string s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
        public ArrayList showBuses()
        {
            ArrayList a = new ArrayList();
            try{

            }
            catch (Exception ex){
                ex.ToString();
                Console.WriteLine("ERROR: Show buses");
            }
            finally
            {
               // c.Close();
            }
            return a;
        }


        public void addBus(BusEN b)
        {
            string s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Insert Into Bus (Id,departureDate,arrivalDate,departureCity,destinationCity,bonus) VALUES ('" + b.Id + "','" + b.departureDate + "','" + b.arrivalDate + "','" +
                    b.departureCity + "','" + b.destinationCity + "','" + b.bonus + "')", c);

                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: Add bus");
            }
            finally
            {
                c.Close();
            }

        }


        public void deleteBus(BusEN b)
        {
            string s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Delete From Bus Where ID = " + b.Id, c);
                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: Delete bus");
            }
            finally
            {
                c.Close();
            }
        }


        public void updateBus(BusEN b)
        {
            string s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Update Bus Set departureDate = '" + b.departureDate + "', arrivalDate = '" + b.arrivalDate + "', departureCity ='" +
                    b.departureCity + "', destinationCity = '" + b.destinationCity + "', Bonus = '" + b.bonus + "' Where ID = " + b.Id, c);

                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: Update bus");
            }
            finally
            {
                c.Close();
            }
        }


        public ArrayList searchBus(BusEN b)
        {
            ArrayList a = new ArrayList();
            string s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Select * from Bus where departureCity = " + b.departureCity + " and destinationCity = " + b.destinationCity, c);
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    a.Add(dr["Id"].ToString());
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: Show buses");
            }
            finally
            {
                c.Close();
            }
            return a;
        }
         */
    }
}