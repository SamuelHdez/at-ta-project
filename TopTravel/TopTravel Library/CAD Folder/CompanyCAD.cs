using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace TopTravel
{
    public class CompanyCAD
    {
        ArrayList lista = new ArrayList();
        string s = "data source=.\\SQLEXPRESS;Integrated Security=SSPI;AttachDBFilename=| DataDirectory|\\Database.mdf;User Instance=true";

        public ArrayList showCompanies()
        {
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

            SqlCommand com = new SqlCommand("Insert Into Company (ID,Name,Type,Phone,Email,Country,Website,Description) VALUES ('" + co.Id + "','" + co.Name + "','" + co.Type + "','" +
                co.Phone + "','" + co.Email + "','" + co.Country + "','" + co.Website + "','" + co.Description + "')", c);

            com.ExecuteNonQuery();
            c.Close();

        }

        public void delete_Company(CompanyEN c)
        {
        }

        public void update_Company(CompanyEN c)
        {
        }

        }
}