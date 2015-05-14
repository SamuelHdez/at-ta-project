using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;

namespace TopTravel
{
    public class CruiseCAD
    {
        public void add_Cruise(CruiseEN cr)
        {
            string s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Insert Into Cruise (ID,departureTime,arrivaleTime,City,Route) VALUES ('" + cr.Id + "','" + cr.departureDate + "','" + cr.arrivalDate + "','" +
                    cr.City + "','" + cr.Route + "')", c);

                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: Add Cruise");
            }
            finally
            {
                c.Close();
            }
        }

        public void delete_Cruise(CruiseEN cr)
        {
            string s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Delete from Cruise where ID = " + cr.Id , c);

                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: Delete Cruise");
            }
            finally
            {
                c.Close();
            }
        }

        public void update_Cruise(CruiseEN cr)
        {
            string s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Update Cruise where ID = '" + cr.Id + "', departureTime = '"
                    + cr.departureDate + "', arrivalTime = '" + cr.arrivalDate + "' , City ='" + cr.City +
                    "', Route = '" + cr.Route + "')", c);

                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: Update Cruise");
            }
            finally
            {
                c.Close();
            }
        }

        public ArrayList show_All_Cruises()
        {
            ArrayList a = new ArrayList();
            string s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Select * from Cruise", c);
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
                Console.WriteLine("ERROR: Show Cruise");
            }
            finally
            {
                c.Close();
            }
            return a;
        }

        public ArrayList searchCruises(CruiseEN cr)
        {
            ArrayList a = new ArrayList();
            string s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Select * from Cruise where Id = " + cr.Id , c);
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
                Console.WriteLine("ERROR: Search Cruise");
            }
            finally
            {
                c.Close();
            }
            return a;
        }
    }
}

