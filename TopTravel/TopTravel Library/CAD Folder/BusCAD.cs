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
        ArrayList search = new ArrayList();

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
                    lista.Add(dr["Id"].ToString());
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


        public void addBus(BusEN b)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            BusEN bus = b;
            SqlConnection c = new SqlConnection(s);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Insert Into Bus (Id,departureDate,arrivalDate,departureCity,destinationCity,bonus) VALUES ('" + bus.Id + "','" + bus.DepartureDate + "','" + bus.ArrivalDate + "','" +
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


        public void deleteBus(BusEN b)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            BusEN bus = b;
            SqlConnection c = new SqlConnection(s);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Delete From Bus Where ID = " + bus.Id, c);
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
            string s;
            s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            BusEN bus = b;
            SqlConnection c = new SqlConnection(s);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Update Bus Set departureDate = '" + bus.DepartureDate + "', arrivalDate = '" + bus.ArrivalDate + "', departureCity ='" +
                    bus.departureCity + "', destinationCity = '" + bus.destinationCity + "', Bonus = '" + bus.Bonus + "' Where ID = " + bus.Id, c);
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
            string s;
            s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Select * from Bus where departureCite = " + b.DepartureCity + " and destinationCity = " + b.DestinationCity, c);
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
                Console.WriteLine("ERROR: Show buses");
            }
            finally
            {
                c.Close();
            }
            return search;
        }
    }
}