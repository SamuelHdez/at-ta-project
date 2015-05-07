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
        ArrayList lista = new ArrayList();
        ArrayList search = new ArrayList();

        public void addHotel(HotelEN h)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            HotelEN ho = h;
            SqlConnection c = new SqlConnection(s);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Insert Into Hotel (ID,Name,City,Days,Phone,Adress,Email,Stars,Bedrooms,Date) VALUES ('" + ho.Id + "','" + ho.Name + "','" + ho.City + "','" +
                    ho.Days + "','" + ho.Phone + "','" + ho.Address + "','" + ho.Email + "','" + ho.Stars + "','" + ho.Bedrooms + "','" + ho.Date + "')", c);

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
            string s;
            s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            HotelEN ho = h;
            SqlConnection c = new SqlConnection(s);

            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Delete From Hotel Where id = " + ho.Id, c);
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
            string s;
            s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            HotelEN ho = h;
            SqlConnection c = new SqlConnection(s);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Update Hotel Set Name = '" + ho.Name + "', City = '" + ho.City + "', Days ='" +
                    ho.Days + "', Phone = '" + ho.Phone + "', Adress = '" + ho.Address + "', Email = '" + ho.Email + "', Stars = '" +
                    ho.Stars + "', Bedrooms = '" + ho.Bedrooms + "', Date = '" + ho.Date + "' Where Id = " + ho.Id, c);
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
            string s;
            s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Select * from Hotels where City = " + h.City, c);
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    search.Add(dr["Name"].ToString());
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
            return lista;
        }

        public ArrayList showHotels()
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Select * from Hotels", c);
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(dr["Name"].ToString());
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
            return lista;
        }

    }
}