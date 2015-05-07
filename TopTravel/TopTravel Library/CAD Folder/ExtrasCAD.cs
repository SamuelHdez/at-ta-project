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
        ArrayList lista = new ArrayList();
        ArrayList search = new ArrayList();

        public void addExtra(ExtrasEN e)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            ExtrasEN ex = e;
            SqlConnection c = new SqlConnection(s);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Insert Into Extras (Id,WiFi,Food,Discount) VALUES ('" + ex.Id + "','" + ex.WiFi + "','" + ex.Food + "','" +
                    ex.Discount + "')", c);

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
            string s;
            s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            ExtrasEN ex = e;
            SqlConnection c = new SqlConnection(s);

            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Delete From Extras Where Id = " + ex.Id, c);
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
            string s;
            s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            ExtrasEN ex = e;
            SqlConnection c = new SqlConnection(s);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Update Extras Set WiFi = '" + ex.WiFi + "', Food = '" + ex.Food + "', Discount ='" +
                    ex.Discount + "' Where Id = " + ex.Id, c);
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
            string s;
            s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Select * from Extras", c);
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
                Console.WriteLine("ERROR: Show extras");
            }
            finally
            {
                c.Close();
            }
            return lista;
        }

    }
}
