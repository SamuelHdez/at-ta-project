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
        public void register_admin(AdminEN a)
        {
            string s =  ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Insert Into Admin (Id,name,dni,email,password) VALUES ('" + a.Id + "','" + a.name + "','" + a.dni + "','" +
                    a.email + "','" + a.password + "')", c);

                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: Add Admin");
            }
            finally
            {
                c.Close();
            }
        }

        public void delete_admin(AdminEN a)
        {
            string s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Delete From Admin Where Id = " + a.Id, c);
                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: Delete Admin");
            }
            finally
            {
                c.Close();
            }
        }

        public void update_admin(AdminEN a)
        {
            string s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Update Admin Set name = '" + a.name + "', dni = '" + a.dni + "', email ='" +
                    a.email + "', password = '" + a.password  + "' Where Id = " + a.Id, c);
                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: Update Admin");
            }
            finally
            {
                c.Close();
            }
        }

        public ArrayList login_admin(AdminEN a)
        {
            string s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            ArrayList al = new ArrayList(); 
            SqlConnection c = new SqlConnection(s);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Select * from Admin where email = " + a.email , c);
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
                Console.WriteLine("ERROR: login Admin");
            }
            finally
            {
                c.Close();
            }
            return al;
        }
    }
}
