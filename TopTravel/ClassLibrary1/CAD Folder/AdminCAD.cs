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
                SqlDataAdapter da = new SqlDataAdapter("select count(*) from Admin where Id = '" + nameAd + "'", c);
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
    }
}
