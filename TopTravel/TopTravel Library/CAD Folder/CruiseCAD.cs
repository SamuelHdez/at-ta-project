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
        ArrayList lista = new ArrayList();

        public void add_Cruise(CruiseEN cen)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            CruiseEN co = cen;
            SqlConnection c = new SqlConnection(s);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Insert Into Cruise (ID,departureTime,arrivaleTime,City,Route) VALUES ('" + co.Id + "','" + co.departureDate + "','" + co.arrivalDate + "','" +
                    co.City + "','" + co.Route + "')", c);

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

        public void delete_Cruise(CruiseEN cen)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            CruiseEN co = cen;
            SqlConnection c = new SqlConnection(s);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Delete from Cruise where ID = " + co.Id , c);

                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: Delete from Cruise");
            }
            finally
            {
                c.Close();
            }
        }

        public void update_Cruise(CruiseEN cen)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            CruiseEN co = cen;
            SqlConnection c = new SqlConnection(s);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Update Cruise where ID = " + co.Id + ", departureTime = "
                    + co.departureDate + ", arrivalTime = " + co.arrivalDate + " , City =" + co.City +
                    ", Route = " + co.Route + " )", c);

                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: Delete from Cruise");
            }
            finally
            {
                c.Close();
            }
        }

        public ArrayList show_All_Cruises()
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Select * from Cruise", c);
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
                Console.WriteLine("ERROR: Show Cruise");
            }
            finally
            {
                c.Close();
            }
            return lista;
        }

        public ArrayList searchCruises(CruiseEN aux)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Select * from Cruise where Id = " + aux.Id , c);
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
                Console.WriteLine("ERROR: Search Cruise");
            }
            finally
            {
                c.Close();
            }
            return lista;
        }
    }
}

