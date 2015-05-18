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
        public DataSet showCompanies(CompanyEN b)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            DataSet virtdb = new DataSet();
            SqlConnection c = new SqlConnection(s);

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from Company", c);
                da.Fill(virtdb, "company");

            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: show company");
            }
            finally
            {
                c.Close();
            }
            return virtdb;

        }

        public DataSet searchCompanies(String ty)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            DataSet virtdb = new DataSet();
            SqlConnection c = new SqlConnection(s);

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * from Company where Type LIKE '%" + ty + "%'", c);
                da.Fill(virtdb, "company");

            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: show company");
            }
            finally
            {
                c.Close();
            }
            return virtdb;

        }

        public DataSet searchCompanyID(string idC)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            DataSet virtdb = new DataSet();
            SqlConnection c = new SqlConnection(s);

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * from Company where ID = '" + idC + "'", c);
                da.Fill(virtdb, "company");

            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: show company");
            }
            finally
            {
                c.Close();
            }
            return virtdb;

        }


        public void addCompany(CompanyEN com)
        {
            string s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            DataSet virtdb = new DataSet();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                da.Fill(virtdb, "company");
                DataTable dt = new DataTable();
                dt = virtdb.Tables["company"];
                DataRow newRow = dt.NewRow();
                newRow[0] = com.Id;
                newRow[1] = com.name;
                newRow[2] = com.type;
                newRow[3] = com.phone;
                newRow[4] = com.email;
                newRow[5] = com.country;
                newRow[5] = com.website;
                newRow[5] = com.description;
                dt.Rows.Add(newRow);
                SqlCommandBuilder cbuilder = new SqlCommandBuilder(da);
                da.Update(virtdb, "company");
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


        public DataSet deleteCompany(CompanyEN com, int i) // It will delete the index passed in the view
        {
            string s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            DataSet virtdb = new DataSet();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                da.Fill(virtdb, "company");
                DataTable t = new DataTable();
                t = virtdb.Tables["company"];

                t.Rows[i].Delete();

                SqlCommandBuilder cbuilder = new SqlCommandBuilder(da);
                da.Update(virtdb, "company");
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
            return virtdb;
        }

        public DataSet updateCompany(CompanyEN com, int i)
        {
            string s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            DataSet virtdb = new DataSet();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                da.Fill(virtdb, "company");
                DataTable t = new DataTable();
                t = virtdb.Tables["company"];

                t.Rows[i]["ID"] = com.Id;

                t.Rows[i]["ID"] = com.Id;
                t.Rows[i]["Name"] = com.name;
                t.Rows[i]["Type"] = com.type;
                t.Rows[i]["Phone"] = com.phone;
                t.Rows[i]["Email"] = com.email;
                t.Rows[i]["Country"] = com.country;
                t.Rows[i]["Website"] = com.website;
                t.Rows[i]["Country"] = com.country;
                t.Rows[i]["Description"] = com.description;


                SqlCommandBuilder cbuilder = new SqlCommandBuilder(da);
                da.Update(virtdb, "company");
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
            return virtdb;
        }
        /*
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
         */
    }
}