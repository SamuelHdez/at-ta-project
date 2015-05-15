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
    }
}