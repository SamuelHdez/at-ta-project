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


namespace HADA
{
    public class HotelCAD
    {
        public DataSet showHotels(HotelEN h)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            DataSet virtdb = new DataSet();
            SqlConnection c = new SqlConnection(s);

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from Hotel", c);
                da.Fill(virtdb, "hotel");

            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: show hotel");
            }
            finally
            {
                c.Close();
            }
            return virtdb;

        }

        public void addHotel(HotelEN h)
        {
            string s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            DataSet virtdb = new DataSet();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                da.Fill(virtdb, "hotel");
                DataTable t = new DataTable();
                t = virtdb.Tables["hotel"];
                DataRow newRow = t.NewRow();
                newRow[0] = h.Id;
                newRow[1] = h.Name;
                newRow[2] = h.City;
                newRow[3] = h.Days;
                newRow[4] = h.Phone;
                newRow[5] = h.Address;
                newRow[6] = h.Email;
                newRow[7] = h.Stars;
                newRow[8] = h.Bedrooms;
                newRow[9] = h.Date;
                t.Rows.Add(newRow);
                SqlCommandBuilder cbuilder = new SqlCommandBuilder(da);
                da.Update(virtdb, "hotel");
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

        public DataSet deleteHotel(HotelEN h, int i) // It will delete the index passed in the view
        {
            string s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            DataSet virtdb = new DataSet();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                da.Fill(virtdb, "hotel");
                DataTable t = new DataTable();
                t = virtdb.Tables["hotel"];

                t.Rows[i].Delete();

                SqlCommandBuilder cbuilder = new SqlCommandBuilder(da);
                da.Update(virtdb, "hotel");
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
            return virtdb;
        }

        public DataSet updateHotel(HotelEN h, int i)
        {
            string s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            DataSet virtdb = new DataSet();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                da.Fill(virtdb, "hotel");
                DataTable t = new DataTable();
                t = virtdb.Tables["hotel"];

                t.Rows[i]["Id"] = h.Id;

                t.Rows[i]["Id"] = h.Id;
                t.Rows[i]["Name"] = h.Name;
                t.Rows[i]["City"] = h.City;
                t.Rows[i]["Days"] = h.Days;
                t.Rows[i]["Phone"] = h.Phone;
                t.Rows[i]["Adress"] = h.Address;
                t.Rows[i]["Email"] = h.Email;
                t.Rows[i]["Stars"] = h.Stars;
                t.Rows[i]["Bedrooms"] = h.Bedrooms;
                t.Rows[i]["Date"] = h.Date;

                SqlCommandBuilder cbuilder = new SqlCommandBuilder(da);
                da.Update(virtdb, "hotel");
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
            return virtdb;


        }
    }
}


        /* Parte base de datos desconectada

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
} */