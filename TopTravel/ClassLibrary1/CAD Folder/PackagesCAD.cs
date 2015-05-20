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
        public DataSet addPackages(PackagesEN b)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            DataSet virtdb = new DataSet();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from Packages", c);
                da.Fill(virtdb, "Packages");
                DataTable dt = new DataTable();
                dt = virtdb.Tables["Packages"];
                DataRow newRow = dt.NewRow();
                newRow[0] = b.id;
                newRow[1] = b.Name;
                newRow[2] = b.Transport;
                newRow[3] = b.Hotel;
                dt.Rows.Add(newRow);
                SqlCommandBuilder cbuilder = new SqlCommandBuilder(da);
                da.Update(virtdb, "Packages");
            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: Add Packages");
            }
            finally
            {
                c.Close();
            }

            return virtdb;
        }
        public DataSet showPackages(PackagesEN b)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            DataSet virtdb = new DataSet();
            SqlConnection c = new SqlConnection(s);

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from Packages", c);
                da.Fill(virtdb, "Packages");

            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: show Packages");
            }
            finally
            {
                c.Close();
            }
            return virtdb;

        }

        public DataSet searchPackages(String b1, String b2)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            DataSet virtdb = new DataSet();
            SqlConnection c = new SqlConnection(s);

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * from Packages where departureCity LIKE '%" + b1 + "%' and destinationCity LIKE '%" + b2 + "%'", c);
                da.Fill(virtdb, "Packages");

            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: show Packages");
            }
            finally
            {
                c.Close();
            }
            return virtdb;

        }

        public DataSet searchIDPackages(String IDF)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            DataSet virtdb = new DataSet();
            SqlConnection c = new SqlConnection(s);

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * from Packages where Id = '" + IDF + "'", c);
                da.Fill(virtdb, "Packages");

            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: show Packages");
            }
            finally
            {
                c.Close();
            }
            return virtdb;

        }


        public DataSet deletePackages(PackagesEN b, int i) // It will delete the index passed in the view
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            DataSet virtdb = new DataSet();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from Packages", c);
                da.Fill(virtdb, "Packages");
                DataTable t = new DataTable();
                t = virtdb.Tables["Packages"];

                t.Rows[i].Delete();

                SqlCommandBuilder cbuilder = new SqlCommandBuilder(da);
                da.Update(virtdb, "Packages");
            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: Delete Packages");
            }
            finally
            {
                c.Close();
            }
            return virtdb;
        }

        public DataSet updatePackages(PackagesEN b, int i)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            DataSet virtdb = new DataSet();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from Packages", c);
                da.Fill(virtdb, "Packages");
                DataTable t = new DataTable();
                t = virtdb.Tables["Packages"];

                t.Rows[i]["Id"] = b.id;
                t.Rows[i]["name"] = b.Name;
                t.Rows[i]["arrivalTime"] = b.Transport;
                t.Rows[i]["departureCity"] = b.Hotel;
                t.Rows[i]["price"] = b.Price;
                t.Rows[i]["image"] = b.Image;


                SqlCommandBuilder cbuilder = new SqlCommandBuilder(da);
                da.Update(virtdb, "Packages");
            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: Delete Packages");
            }
            finally
            {
                c.Close();
            }
            return virtdb;


        }
    }
        /*
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
        } */
}