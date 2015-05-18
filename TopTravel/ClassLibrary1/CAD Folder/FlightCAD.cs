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
    public class FlightCAD
    {
        public DataSet showFlights(FlightEN b)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            DataSet virtdb = new DataSet();
            SqlConnection c = new SqlConnection(s);

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from Flight", c);
                da.Fill(virtdb, "flight");

            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: show flight");
            }
            finally
            {
                c.Close();
            }
            return virtdb;

        }

        public DataSet searchFlights(String b1, String b2)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            DataSet virtdb = new DataSet();
            SqlConnection c = new SqlConnection(s);

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * from Flight where departureCity LIKE '%" + b1 + "%' and destinationCity LIKE '%" + b2 + "%'", c);
                da.Fill(virtdb, "flight");

            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: show flight");
            }
            finally
            {
                c.Close();
            }
            return virtdb;

        }


        public DataSet addFlight(FlightEN b)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            DataSet virtdb = new DataSet();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from Flight", c);
                da.Fill(virtdb, "flight");
                DataTable dt = new DataTable();
                dt = virtdb.Tables["flight"];
                DataRow newRow = dt.NewRow();
                newRow[0] = b.id;
                newRow[1] = b.DepartureTime;
                newRow[2] = b.ArrivalTime;
                newRow[3] = b.DepartureCity;
                newRow[4] = b.DestinationCity;
                newRow[5] = b.classFlight;
                newRow[6] = b.Price;
                newRow[7] = b.Company;
                newRow[8] = b.Extras;
                newRow[9] = b.Image;
                dt.Rows.Add(newRow);
                SqlCommandBuilder cbuilder = new SqlCommandBuilder(da);
                da.Update(virtdb, "flight");
            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: Add flight");
            }
            finally
            {
                c.Close();
            }

            return virtdb;
        }


        public DataSet deleteFlight(FlightEN b, int i) // It will delete the index passed in the view
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            DataSet virtdb = new DataSet();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from Flight", c);
                da.Fill(virtdb, "flight");
                DataTable t = new DataTable();
                t = virtdb.Tables["flight"];

                t.Rows[i].Delete();

                SqlCommandBuilder cbuilder = new SqlCommandBuilder(da);
                da.Update(virtdb, "flight");
            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: Delete flight");
            }
            finally
            {
                c.Close();
            }
            return virtdb;
        }

        public DataSet updateFlight(FlightEN b, int i)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            DataSet virtdb = new DataSet();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from Flight", c);
                da.Fill(virtdb, "flight");
                DataTable t = new DataTable();
                t = virtdb.Tables["flight"];

                t.Rows[i]["Id"] = b.id;
                t.Rows[i]["departureTime"] = b.DepartureTime;
                t.Rows[i]["arrivalTime"] = b.ArrivalTime;
                t.Rows[i]["departureCity"] = b.DepartureCity;
                t.Rows[i]["destinationCity"] = b.DestinationCity;
                t.Rows[i]["ClassFlight"] = b.classFlight;
                t.Rows[i]["price"] = b.Price;
                t.Rows[i]["company"] = b.Company;
                t.Rows[i]["extras"] = b.Extras;
                t.Rows[i]["image"] = b.Image;


                SqlCommandBuilder cbuilder = new SqlCommandBuilder(da);
                da.Update(virtdb, "flight");
            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: Delete flight");
            }
            finally
            {
                c.Close();
            }
            return virtdb;


        }
  
    }
}