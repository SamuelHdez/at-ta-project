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
    public class HotelCAD
    {
        public void addHotel(HotelEN h)
        {
            string s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Insert Into Hotel (ID,Name,City,Days,Phone,Adress,Email,Stars,Bedrooms,Date) VALUES ('" + h.Id + "','" + h.Name + "','" + h.City + "','" +
                    h.Days + "','" + h.Phone + "','" + h.Address + "','" + h.Email + "','" + h.Stars + "','" + h.Bedrooms + "','" + h.Date + "')", c);

                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: Add hotel");
            }
            finally
            {
                c.Close();
            }
        }

        public void deleteHotel(HotelEN h)
        {
            string s= ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Delete From Hotel Where id = " + h.Id, c);
                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: Delete hotel");
            }
            finally
            {
                c.Close();
            }
        }

        public void updateHotel(HotelEN h)
        {
            string s= ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Update Hotel Set Name = '" + h.Name + "', City = '" + h.City + "', Days ='" +
                    h.Days + "', Phone = '" + h.Phone + "', Adress = '" + h.Address + "', Email = '" + h.Email + "', Stars = '" +
                    h.Stars + "', Bedrooms = '" + h.Bedrooms + "', Date = '" + h.Date + "' Where Id = " + h.Id, c);
                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: Update hotel");
            }
            finally
            {
                c.Close();
            }
        }

        public ArrayList searchHotel(HotelEN h)
        {
            ArrayList a = new ArrayList();
            string s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Select * from Hotels where City = " + h.City, c);
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    a.Add(dr["Name"].ToString());
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: Search hotels");
            }
            finally
            {
                c.Close();
            }
            return a;
        }

        public ArrayList showHotels()
        {
            ArrayList a = new ArrayList();
            string s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Select * from Hotels", c);
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    a.Add(dr["Name"].ToString());
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: Show hotels");
            }
            finally
            {
                c.Close();
            }
            return a;
        }
    }
}