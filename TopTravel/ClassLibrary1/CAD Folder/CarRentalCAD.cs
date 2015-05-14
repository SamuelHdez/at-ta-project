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
    public class CarRentalCAD // To-do arreglar la insercion de las fechas en la base de datos. string a tipo date
    {
        public void add_CarRental(CarRentalEN cr)
		{
            string s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Insert Into CarRental (Id,City,Brand,Model,Days,Date) VALUES ('" + cr.Id + "','" + cr.City + "','" + cr.Brand + "','" +
                    cr.Model + "','" + cr.Days + "','" + cr.Date + "')", c);
                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: Add CarRental");
            }
            finally
            {
                c.Close();
            }
		}

        public void update_CarRental(CarRentalEN cr)
		{
            string s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Update CarRental Set City = '" + cr.City + "', Brand = '" + cr.Brand + "', Model ='" +
                    cr.Model + "', Days = '" + cr.Days + "', Date = '" + cr.Date + "' Where ID = " + cr.Id, c);
                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: Update CarRental");
            }
            finally
            {
                c.Close();
            }
		}

        public void delete_CarRental(CarRentalEN cr)
		{
            string s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Delete From CarRental Where Id = " + cr.Id, c);
                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: Delete CarRental");
            }
            finally
            {
                c.Close();
            }
		}

        public ArrayList search_CarRental(CarRentalEN cr)
		{
            ArrayList a = new ArrayList();
            string s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Select * from CarRental where Id = " + cr.Id, c);
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
                Console.WriteLine("ERROR: Search CarRental");
            }
            finally
            {
                c.Close();
            }
            return a;
		}
        public ArrayList showCarRental() 
        {
            ArrayList a = new ArrayList();
            string s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Select * from CarRental", c);
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
                Console.WriteLine("ERROR: Show CarRental");
            }
            finally
            {
                c.Close();
            }
            return a;
        }
    }
}