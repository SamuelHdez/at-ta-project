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
    class SpaceTravelCAD
    {
        /*
        public void add_SpaceTravel(SpaceTravelEN b)
        {
            string s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Insert Into SpaceTravel (Id,departureDate,arrivalDate,departureCity,Preparation Center) VALUES ('" + b.Id + "','" + b.departureDate + "','" + b.arrivalDate + "','" +
                    b.departureCity + "','" + b.PreparationCenter + "')", c);

                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: Add SpaceTravel");
            }
            finally
            {
                c.Close();
            }
        }
        public void delete_SpaceTravel(SpaceTravelEN b)
        {
            string s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Delete From SpaceTravel Where Id = " + b.Id, c);
                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: Delete SpaceTravel");
            }
            finally
            {
                c.Close();
            }
        }
        public void update_SpaceTravel(SpaceTravelEN b)
        {
            string s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Update SpaceTravel Set departureDate = '" + b.departureDate + "', arrivalDate = '" + b.arrivalDate + "', departureCity ='" +
                    b.departureCity + ",' Preparation Center  '= " + b.PreparationCenter + "' Where ID = " + b.Id, c);
                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: Update SpaceTravel");
            }
            finally
            {
                c.Close();
            }
        }
        public ArrayList show_SpaceTravel()
        {
            ArrayList a = new ArrayList();
            string s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Select * from SpaceTravel", c);
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
                Console.WriteLine("ERROR: Show SpaceTravel");
            }
            finally
            {
                c.Close();
            }
            return a;
        }
        public ArrayList search_SpaceTravel(SpaceTravelEN b)
        {
            ArrayList a = new ArrayList();
            string s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Select * from SpaceTravel where Id = " + b.Id, c);
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
                Console.WriteLine("ERROR: Search SpaceTravel");
            }
            finally
            {
                c.Close();
            }
            return a;
        } */
    }
}
