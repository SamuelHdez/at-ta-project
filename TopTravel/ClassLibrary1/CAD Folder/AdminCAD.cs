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
    class AdminCAD
    {
        public DataSet searchAdmin(String nameAd)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            DataSet virtdb = new DataSet();
            SqlConnection c = new SqlConnection(s);

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select count(*) from Admin where name = '" + nameAd + "'", c);
                da.Fill(virtdb, "admin");

            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: show admin");
            }
            finally
            {
                c.Close();
            }
            return virtdb;

        }
        /*
       public ArrayList login_admin(AdminEN a)
        {
            string s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            ArrayList al = new ArrayList(); 
            SqlConnection c = new SqlConnection(s);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Select name from Admin", c);
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    al.Add(dr["Id"].ToString());
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: Login Admin");
            }
            finally
            {
                c.Close();
            }
            return al;
        }
         */
    }
}
