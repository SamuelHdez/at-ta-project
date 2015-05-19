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

        public DataSet searchHotels(String h)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            DataSet virtdb = new DataSet();
            SqlConnection c = new SqlConnection(s);

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * from Hotel where City Like '%" + h + "%'", c);
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

        public DataSet searchIDHotels(String idH)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            DataSet virtdb = new DataSet();
            SqlConnection c = new SqlConnection(s);

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * from Hotel where Id = '" + idH + "'", c);
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

        
        public DataSet addHotel(HotelEN h)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            DataSet virtdb = new DataSet();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from Hotel", c);
                da.Fill(virtdb, "hotel");
                DataTable t = new DataTable();
                t = virtdb.Tables["hotel"];

                DataRow newRow = t.NewRow();
                newRow[0] = h.Id;
                newRow[1] = h.Name;
                newRow[2] = h.City;
                newRow[3] = h.Phone;
                newRow[4] = h.Address;
                newRow[5] = h.Email;
                newRow[6] = h.Stars;
                newRow[7] = h.Bedrooms;
                newRow[8] = h.Price;
                newRow[9] = h.Company;
                newRow[10] = h.Extras;
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
            return virtdb;
        }
        
        public DataSet deleteHotel(HotelEN h, int i) // It will delete the index passed in the view
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            DataSet virtdb = new DataSet();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from Hotel", c);
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
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();

            SqlConnection c = new SqlConnection(s);
            DataSet virtdb = new DataSet();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from Hotel", c);
                da.Fill(virtdb, "hotel");
                DataTable t = new DataTable();
                t = virtdb.Tables["hotel"];

               // t.Rows[i]["Id"] = h.Id;

                t.Rows[i]["Id"] = h.Id;
                t.Rows[i]["Name"] = h.Name;
                t.Rows[i]["City"] = h.City;
                t.Rows[i]["Phone"] = h.Phone;
                t.Rows[i]["Adress"] = h.Address;
                t.Rows[i]["Email"] = h.Email;
                t.Rows[i]["Stars"] = h.Stars;
                t.Rows[i]["Bedrooms"] = h.Bedrooms;
                t.Rows[i]["Price"] = h.Price;
                t.Rows[i]["company"] = h.Company;
                t.Rows[i]["extras"] = h.Extras;

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
