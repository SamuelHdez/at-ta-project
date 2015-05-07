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
        ArrayList lista = new ArrayList();
       // string s = "Data Source=(LocalDB)\v11.0;AttachDbFilename=| DataDirectory|\\Database.mdf;Integrated Security=True";
 
        public ArrayList showCompanies()
        {
             string s;
             s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Select * from Company", c);
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
                Console.WriteLine("ERROR: Show companies");
            }
            finally
            {
                c.Close();
            }
            return lista;
        }

        public void addCompany(CompanyEN cen)
        {
            CompanyEN co = cen;
            SqlConnection c = new SqlConnection(s);
            c.Open();
            try
            {
                SqlCommand com = new SqlCommand("Insert Into Company (ID,Name,Type,Phone,Email,Country,Website,Description) VALUES ('" + co.Id + "','" + co.Name + "','" + co.Type + "','" +
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

        public void delete_Company(CompanyEN cen)
        {
            CompanyEN co = cen;
            SqlConnection c = new SqlConnection(s);
            c.Open();
            try
            {
                SqlCommand com = new SqlCommand("Delete From Company Where id = " + co.Id , c);
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

        public void update_Company(CompanyEN cen)
        {
            CompanyEN co = cen;
            SqlConnection c = new SqlConnection(s);
            c.Open();
            try
            {
                SqlCommand com = new SqlCommand("Update Company Set Name = '" + co.Name + "', Type = '" + co.Type + "', Phone ='" +
                    co.Phone + "', Email = '" + co.Email + "', County = '" + co.Country + "', Website = '" + co.Website + "', Description = '" + 
                    co.Description + "' Where ID = " + co.Id, c);
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