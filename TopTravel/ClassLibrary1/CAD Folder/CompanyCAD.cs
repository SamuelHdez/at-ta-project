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
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString(); //Connection string
            DataSet virtdb = new DataSet();
            SqlConnection c = new SqlConnection(s);

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from Company", c); //The select in SQL language that is processed in the DB which will return all the rows from the table 
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
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString(); //Connection string
            DataSet virtdb = new DataSet();
            SqlConnection c = new SqlConnection(s);

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * from Company where Type LIKE '%" + ty + "%'", c); //select statement filter by type
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
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString(); //Connection string
            DataSet virtdb = new DataSet();
            SqlConnection c = new SqlConnection(s);

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * from Company where ID = '" + idC + "'", c); //select statement filter by id
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
            string s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString(); //Connection string
            SqlConnection c = new SqlConnection(s);
            DataSet virtdb = new DataSet();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                da.Fill(virtdb, "company");
                DataTable dt = new DataTable();
                dt = virtdb.Tables["company"];
                DataRow newRow = dt.NewRow(); //insert new values in a new row
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
            string s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString(); //Connection string
            SqlConnection c = new SqlConnection(s);
            DataSet virtdb = new DataSet();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                da.Fill(virtdb, "company");
                DataTable t = new DataTable();
                t = virtdb.Tables["company"];

                t.Rows[i].Delete(); //delete row

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
            string s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString(); //Connection string
            SqlConnection c = new SqlConnection(s);
            DataSet virtdb = new DataSet();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                da.Fill(virtdb, "company");
                DataTable t = new DataTable();
                t = virtdb.Tables["company"];

                t.Rows[i]["ID"] = com.Id;   //update rows

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
    }
}