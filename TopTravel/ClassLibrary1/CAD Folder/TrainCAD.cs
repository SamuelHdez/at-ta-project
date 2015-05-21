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
    public class TrainCAD
    {

        public DataSet showTrains(TrainEN t)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString(); //Connection string
            DataSet virtdb = new DataSet();
            SqlConnection c = new SqlConnection(s);

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from Train", c); //select statement
                da.Fill(virtdb, "train");

            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: show train");
            }
            finally
            {
                c.Close();
            }
            return virtdb;

        }

        public DataSet searchTrains(String t1, String t2)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString(); //Connection string
            DataSet virtdb = new DataSet();
            SqlConnection c = new SqlConnection(s);

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * from Train where departureCity LIKE '%" + t1 + "%' and destinationCity LIKE '%" + t2 + "%'", c); //select statement filter by departure and destination cities
                da.Fill(virtdb, "train");

            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: show train");
            }
            finally
            {
                c.Close();
            }
            return virtdb;

        }

        public DataSet searchIDTrains(String IDT)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString(); //Connection string
            DataSet virtdb = new DataSet();
            SqlConnection c = new SqlConnection(s);

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * from Train where Id = '" + IDT + "'", c); //select statement filter by id
                da.Fill(virtdb, "train");

            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: show train");
            }
            finally
            {
                c.Close();
            }
            return virtdb;

        }


        public DataSet addTrain(TrainEN t)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString(); //Connection string
            SqlConnection c = new SqlConnection(s);
            DataSet virtdb = new DataSet();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from Train", c); 
                da.Fill(virtdb, "train");
                DataTable dt = new DataTable();
                dt = virtdb.Tables["train"];
                DataRow newRow = dt.NewRow(); //new row with new values
                newRow[0] = t.id;
                newRow[1] = t.DepartureTime;
                newRow[2] = t.ArrivalTime;
                newRow[3] = t.DepartureCity;
                newRow[4] = t.DestinationCity;
                newRow[5] = t.Price;
                newRow[6] = t.Company;
                newRow[7] = t.Extras;
                newRow[8] = t.Images;
                dt.Rows.Add(newRow);
                SqlCommandBuilder cbuilder = new SqlCommandBuilder(da);
                da.Update(virtdb, "train");
            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: Add train");
            }
            finally
            {
                c.Close();
            }

            return virtdb;
        }

        public DataSet deleteTrain(TrainEN tr, int i) // It will delete the index passed in the view
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();//Connection string
            SqlConnection c = new SqlConnection(s);
            DataSet virtdb = new DataSet();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from Train", c); //Select statement
                da.Fill(virtdb, "train");
                DataTable t = new DataTable();
                t = virtdb.Tables["train"];

                t.Rows[i].Delete(); //delete row

                SqlCommandBuilder cbuilder = new SqlCommandBuilder(da);
                da.Update(virtdb, "train");
            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: Delete train");
            }
            finally
            {
                c.Close();
            }
            return virtdb;
        }

        public DataSet updateTrain(TrainEN tr, int i)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString(); //Connection string
            SqlConnection c = new SqlConnection(s);
            DataSet virtdb = new DataSet();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from Train", c); //select statement
                da.Fill(virtdb, "train");
                DataTable t = new DataTable();
                t = virtdb.Tables["train"];

                t.Rows[i]["Id"] = tr.id;   //update values
                t.Rows[i]["departureTime"] = tr.DepartureTime;
                t.Rows[i]["arrivalTime"] = tr.ArrivalTime;
                t.Rows[i]["departureCity"] = tr.DepartureCity;
                t.Rows[i]["destinationCity"] = tr.DestinationCity;
                t.Rows[i]["price"] = tr.Price;
                t.Rows[i]["company"] = tr.Company;
                t.Rows[i]["extras"] = tr.Extras;
                t.Rows[i]["images"] = tr.Images;


                SqlCommandBuilder cbuilder = new SqlCommandBuilder(da);
                da.Update(virtdb, "train");
            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: Delete train");
            }
            finally
            {
                c.Close();
            }
            return virtdb;
        }
      
    }
         
}