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
        ArrayList lista = new ArrayList();
        ArrayList search = new ArrayList();

        public ArrayList showTrains()
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Select * from Train", c);
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(dr["Id"].ToString());
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
            return lista;
        }


        public void addTrain(TrainEN t)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            TrainEN train = t;
            SqlConnection c = new SqlConnection(s);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Insert Into Train (Id,departureDay,arrivalDay,departureCity,destinationCity,Bonus) VALUES ('" + train.Id + "','" + train.DepartureDay + "','" + train.ArrivalDay + "','" +
                    train.departureCity + "','" + train.destinationCity + "','" + train.Bonus + "')", c);

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
            string s;
            s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            TrainEN train = t;
            SqlConnection c = new SqlConnection(s);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Delete From Train Where ID = " + train.Id, c);
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
            string s;
            s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            TrainEN train = t;
            SqlConnection c = new SqlConnection(s);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Update Train Set departureDay = '" + train.DepartureDay + "', arrivalDay = '" + train.ArrivalDay + "', departureCity ='" +
                    train.departureCity + "', destinationCity = '" + train.destinationCity + "', Bonus = '" + train.Bonus + "' Where ID = " + train.Id, c);
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
            string s;
            s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Select * from Train where departureCite = " + t.DepartureCity + " and destinationCity = " + t.DestinationCity, c);
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    search.Add(dr["Id"].ToString());
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: Show train");
            }
            finally
            {
                c.Close();
            }
            return search;
        }
    }
}