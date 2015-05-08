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
    public class PackagesCAD
    {

        public void add_pack(PackagesEN p)
        {
            string s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Insert Into Packages (Id,Name,Transport,Hotel) VALUES ('" + p.Id + "','" + p.Name + "','" + p.Transport + "','" +
                    p.Hotel + "')", c);

                com.ExecuteNonQuery();
            }
            catch (Exception exc)
            {
                exc.ToString();
                Console.WriteLine("ERROR: Add pack");
            }
            finally
            {
                c.Close();
            }
        }

        public void delete_pack(PackagesEN p)
        {
            string s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Delete From Packages Where Id = " + p.Id, c);
                com.ExecuteNonQuery();
            }
            catch (Exception exc)
            {
                exc.ToString();
                Console.WriteLine("ERROR: Delete pack");
            }
            finally
            {
                c.Close();
            }
        }
    }
}