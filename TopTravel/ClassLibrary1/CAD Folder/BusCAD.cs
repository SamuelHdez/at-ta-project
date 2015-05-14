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
    }
}