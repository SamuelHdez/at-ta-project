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
        ArrayList lista = new ArrayList();

        public ArrayList showBuses()
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Select * from Bus", c);
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
                Console.WriteLine("ERROR: Show buses");
            }
            finally
            {
                c.Close();
            }
            return lista;
        }


        public void add_Bus(BusEN b)
        {
            BusEN bus = b;
            SqlConnection c = new SqlConnection(s);
            c.Open();
            try
            {
                SqlCommand com = new SqlCommand("Insert Into Company (ID,departureTime,arrivalTime,departureCity,destinationCity,Bonus) VALUES ('" + bus.BusID + "','" + bus.departureTime + "','" + bus.arrivalTime + "','" +
                    bus.departureCity + "','" + bus.destinationCity + "','" + bus.Bonus + "')", c);

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


        public void delete_Bus(BusEN b)
        {
            BusEN bus = b;
            SqlConnection c = new SqlConnection(s);
            c.Open();
            try
            {
                SqlCommand com = new SqlCommand("Delete From Bus Where ID = " + bus.BusID, c);
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


        public void update_Bus(BusEN b)
        {
            BusEN bus = b;
            SqlConnection c = new SqlConnection(s);
            c.Open();
            try
            {
                SqlCommand com = new SqlCommand("Update Bus Set departureTime = '" + bus.departureTime + "', arrivalTime = '" + bus.arrivalTime + "', departureCity ='" +
                    bus.departureCity + "', destinationCity = '" + bus.destinationCity + "', Bonus = '" + bus.Bonus + "' Where ID = " + bus.BusID, c);
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


        public void search_Bus(BusEN b)
        {
            BusEN bus = b;
            SqlConnection c = new SqlConnection(s);
            c.Open();
            try
            {
                SqlCommand com = new SqlCommand("Select * from Bus Where ID = '" + bus.BusID, c);
                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: Search bus");
            }
            finally
            {
                c.Close();
            }
        }
    }
}