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
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            DataSet virtdb = new DataSet();
            SqlConnection c = new SqlConnection(s);

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from Train", c);
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
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            DataSet virtdb = new DataSet();
            SqlConnection c = new SqlConnection(s);

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * from Train where departureCity LIKE '%" + t1 + "%' and destinationCity LIKE '%" + t2 + "%'", c);
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


        public void addTrain(TrainEN t)
        {
            string s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            DataSet virtdb = new DataSet();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                da.Fill(virtdb, "train");
                DataTable dt = new DataTable();
                dt = virtdb.Tables["train"];
                DataRow newRow = dt.NewRow();
                newRow[0] = t.id;
                newRow[1] = t.DepartureTime;
                newRow[2] = t.ArrivalTime;
                newRow[3] = t.DepartureCity;
                newRow[4] = t.DestinationCity;
                newRow[5] = t.bonus;
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
        }

        public DataSet deleteTrain(TrainEN tr, int i) // It will delete the index passed in the view
        {
            string s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            DataSet virtdb = new DataSet();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                da.Fill(virtdb, "train");
                DataTable t = new DataTable();
                t = virtdb.Tables["train"];

                t.Rows[i].Delete();

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
            string s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            DataSet virtdb = new DataSet();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                da.Fill(virtdb, "train");
                DataTable t = new DataTable();
                t = virtdb.Tables["train"];

                t.Rows[i]["Id"] = tr.id;

                t.Rows[i]["Id"] = tr.id;
                t.Rows[i]["departureTime"] = tr.DepartureTime;
                t.Rows[i]["arrivalTime"] = tr.ArrivalTime;
                t.Rows[i]["departureCity"] = tr.DepartureCity;
                t.Rows[i]["arrivalCity"] = tr.DestinationCity;
                t.Rows[i]["Bonus"] = tr.bonus;


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
        /*
        public ArrayList showTrains()
        {
            ArrayList a = new ArrayList();
            string s= ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Select * from Train", c);
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
                Console.WriteLine("ERROR: Show trains");
            }
            finally
            {
                c.Close();
            }
            return a;
        }

        public void addTrain(TrainEN t)
        {
            string s= ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Insert Into Train (Id,departureDay,arrivalDay,departureCity,destinationCity,Bonus) VALUES ('" + t.Id + "','" + t.departureDay + "','" + t.arrivalDay + "','" +
                    t.departureCity + "','" + t.destinationCity + "','" + t.Bonus + "')", c);

                com.ExecuteNonQuery();
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

        }

        public void deleteTrain(TrainEN t)
        {
            string s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Delete From Train Where Id = " + t.Id, c);
                com.ExecuteNonQuery();
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
        }

        public void updateTrain(TrainEN t)
        {
            string s= ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Update Train Set departureDay = '" + t.departureDay + "', arrivalDay = '" + t.arrivalDay + "', departureCity ='" +
                    t.departureCity + "', destinationCity = '" + t.destinationCity + "', Bonus = '" + t.Bonus + "' Where Id = " + t.Id, c);
                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: Update train");
            }
            finally
            {
                c.Close();
            }
        }

        public ArrayList searchTrain(TrainEN t)
        {
            ArrayList a = new ArrayList();
            string s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Select * from Train where departureCite = " + t.departureCity + " and destinationCity = " + t.destinationCity, c);
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
                Console.WriteLine("ERROR: Search train");
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