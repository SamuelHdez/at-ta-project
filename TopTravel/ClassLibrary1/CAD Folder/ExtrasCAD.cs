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
    class ExtrasCAD
    {

        public DataSet searchExtrasID(string idx)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            DataSet virtdb = new DataSet();
            SqlConnection c = new SqlConnection(s);

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * from Extras where Id = '" + idx + "'", c);
                da.Fill(virtdb, "extra");

            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: show extra");
            }
            finally
            {
                c.Close();
            }
            return virtdb;

        }

        public void addExtra(ExtrasEN e)
        {
            string s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Insert Into Extras (Id,WiFi,Food,Discount) VALUES ('" + e.Id + "','" + e.WiFi + "','" + e.Food + "','" +
                    e.Discount + "')", c);

                com.ExecuteNonQuery();
            }
            catch (Exception exc)
            {
                exc.ToString();
                Console.WriteLine("ERROR: Add extra");
            }
            finally
            {
                c.Close();
            }
        }

        public void deleteExtra(ExtrasEN e)
        {
            string s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Delete From Extras Where Id = " + e.Id, c);
                com.ExecuteNonQuery();
            }
            catch (Exception exc)
            {
                exc.ToString();
                Console.WriteLine("ERROR: Delete extra");
            }
            finally
            {
                c.Close();
            }
        }

        public void updateExtra(ExtrasEN e)
        {
            string s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Update Extras Set WiFi = '" + e.WiFi + "', Food = '" + e.Food + "', Discount ='" +
                    e.Discount + "' Where Id = " + e.Id, c);
                com.ExecuteNonQuery();
            }
            catch (Exception exc)
            {
                exc.ToString();
                Console.WriteLine("ERROR: Update extra");
            }
            finally
            {
                c.Close();
            }
        }

        public ArrayList showExtras()
        {
            ArrayList a = new ArrayList();
            string s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Select * from Extras", c);
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
                Console.WriteLine("ERROR: Show extras");
            }
            finally
            {
                c.Close();
            }
            return a;
        }

    }
}
