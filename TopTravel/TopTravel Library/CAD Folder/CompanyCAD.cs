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
    public class CompanyCAD
    {
        public ArrayList showCompanies()
        {
            ArrayList a = new ArrayList();
            string s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Select * from Company", c);
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
                Console.WriteLine("ERROR: Show companies");
            }
            finally
            {
                c.Close();
            }
            return a;
        }

        public void addCompany(CompanyEN co)
        {
            string s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Insert Into Company (ID,Name,Type,Phone,Email,Country,Website,Description) VALUES ('" + co.ID + "','" + co.Name + "','" + co.Type + "','" +
                    co.Phone + "','" + co.Email + "','" + co.Country + "','" + co.Website + "','" + co.Description + "')", c);

                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: Add company");
            }
            finally
            {
                c.Close();
            }

        }

        public void deleteCompany(CompanyEN co)
        {
            string s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
         
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Delete From Company Where id = " + co.ID , c);
                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: Delete company");
            }
            finally
            {
                c.Close();
            }
        }

        public void updateCompany(CompanyEN co)
        {
            string s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Update Company Set Name = '" + co.Name + "', Type = '" + co.Type + "', Phone ='" +
                    co.Phone + "', Email = '" + co.Email + "', County = '" + co.Country + "', Website = '" + co.Website + "', Description = '" + 
                    co.Description + "' Where ID = " + co.ID, c);
                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: Update company");
            }
            finally
            {
                c.Close();
            }
        }
    }
}