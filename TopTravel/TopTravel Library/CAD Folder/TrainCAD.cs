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
                    lista.Add(dr["ID"].ToString());
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

        public void add_train(TrainEN t)
        {
            TrainEN train = t;
            SqlConnection c = new SqlConnection(s);
            c.Open();
            try
            {
                SqlCommand com = new SqlCommand("Insert Into Train (ID,departureTime,arrivalTime,departureCity,destinationCity,Bonus) VALUES ('" + train.trainID + "','" + train.departureTime + "','" + train.arrivalTime + "','" +
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


        public void delete_train(TrainEN t)
        {
            TrainEN train = t;
            SqlConnection c = new SqlConnection(s);
            c.Open();
            try
            {
                SqlCommand com = new SqlCommand("Delete From Train Where ID = " + train.trainID, c);
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


        public void update_train(TrainEN t)
        {
            TrainEN train = t;
            SqlConnection c = new SqlConnection(s);
            c.Open();
            try
            {
                SqlCommand com = new SqlCommand("Update Train Set departureTime = '" + train.departureTime + "', arrivalTime = '" + train.arrivalTime + "', departureCity ='" +
                   train.departureCity + "', destinationCity = '" + train.destinationCity + "', Bonus = '" + train.Bonus + "' Where ID = " + train.trainID, c);
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


        public void search_train(TrainEN t)
        {
            TrainEN train = t;
            SqlConnection c = new SqlConnection(s);
            c.Open();
            try
            {
                SqlCommand com = new SqlCommand("Select * from Train Where ID = '" + train.trainID, c);
                com.ExecuteNonQuery();
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
        }
    }
}