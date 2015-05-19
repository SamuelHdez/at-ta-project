using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;

namespace TopTravel
{
    public class CruiseCAD
    {

        public DataSet showCruises(CruiseEN b)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            DataSet virtdb = new DataSet();
            SqlConnection c = new SqlConnection(s);

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from Cruise", c);
                da.Fill(virtdb, "cruise");

            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: show cruise");
            }
            finally
            {
                c.Close();
            }
            return virtdb;

        }

        public DataSet searchCruises(String reg, String ci)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            DataSet virtdb = new DataSet();
            SqlConnection c = new SqlConnection(s);

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * from Cruise where Route LIKE '%" + reg + "%' and City LIKE '%" + ci + "%'", c);
                da.Fill(virtdb, "cruise");

            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: show cruise");
            }
            finally
            {
                c.Close();
            }
            return virtdb;
        }

        public DataSet searchIDCruises(String IDc)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            DataSet virtdb = new DataSet();
            SqlConnection c = new SqlConnection(s);

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * from Cruise where Id = '" + IDc + "'", c);
                da.Fill(virtdb, "cruise");

            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: show cruise");
            }
            finally
            {
                c.Close();
            }
            return virtdb;
        }


        public DataSet addCruise(CruiseEN b)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            DataSet virtdb = new DataSet();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * from Cruise", c);
                da.Fill(virtdb, "cruise");
                DataTable dt = new DataTable();
                dt = virtdb.Tables["cruise"];
                DataRow newRow = dt.NewRow();
                newRow[0] = b.id;
                newRow[1] = b.DepartureTime;
                newRow[2] = b.ArrivalTime;
                newRow[3] = b.city;
                newRow[4] = b.route;
                newRow[5] = b.Price;
                newRow[6] = b.Company;
                newRow[7] = b.Extras;
                dt.Rows.Add(newRow);
                SqlCommandBuilder cbuilder = new SqlCommandBuilder(da);
                da.Update(virtdb, "cruise");
            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: Add cruise");
            }
            finally
            {
                c.Close();
            }

            return virtdb;
        }


        public DataSet deleteCruise(CruiseEN b, int i) // It will delete the index passed in the view
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            DataSet virtdb = new DataSet();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * from Cruise", c);
                da.Fill(virtdb, "cruise");
                DataTable t = new DataTable();
                t = virtdb.Tables["cruise"];

                t.Rows[i].Delete();

                SqlCommandBuilder cbuilder = new SqlCommandBuilder(da);
                da.Update(virtdb, "cruise");
            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: Delete cruise");
            }
            finally
            {
                c.Close();
            }
            return virtdb;
        }

        public DataSet updateCruise(CruiseEN b, int i)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            DataSet virtdb = new DataSet();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * from Cruise", c);
                da.Fill(virtdb, "cruise");
                DataTable t = new DataTable();
                t = virtdb.Tables["cruise"];

                //t.Rows[i]["Id"] = b.id;

                t.Rows[i]["Id"] = b.id;
                t.Rows[i]["departureTime"] = b.DepartureTime;
                t.Rows[i]["arrivalTime"] = b.ArrivalTime;
                t.Rows[i]["city"] = b.city;
                t.Rows[i]["route"] = b.route;
                t.Rows[i]["price"] = b.Price;
                t.Rows[i]["company"] = b.Company;
                t.Rows[i]["extras"] = b.Extras;


                SqlCommandBuilder cbuilder = new SqlCommandBuilder(da);
                da.Update(virtdb, "cruise");
            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: Delete cruise");
            }
            finally
            {
                c.Close();
            }
            return virtdb;
        }

        /*
        public void add_Cruise(CruiseEN cr)
        {
            string s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Insert Into Cruise (ID,departureTime,arrivaleTime,City,Route) VALUES ('" + cr.Id + "','" + cr.departureDate + "','" + cr.arrivalDate + "','" +
                    cr.City + "','" + cr.Route + "')", c);

                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: Add Cruise");
            }
            finally
            {
                c.Close();
            }
        }

        public void delete_Cruise(CruiseEN cr)
        {
            string s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Delete from Cruise where ID = " + cr.Id , c);

                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: Delete Cruise");
            }
            finally
            {
                c.Close();
            }
        }

        public void update_Cruise(CruiseEN cr)
        {
            string s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Update Cruise where ID = '" + cr.Id + "', departureTime = '"
                    + cr.departureDate + "', arrivalTime = '" + cr.arrivalDate + "' , City ='" + cr.City +
                    "', Route = '" + cr.Route + "')", c);

                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: Update Cruise");
            }
            finally
            {
                c.Close();
            }
        }

        public ArrayList show_All_Cruises()
        {
            ArrayList a = new ArrayList();
            string s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Select * from Cruise", c);
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    a.Add(dr["Id"].ToString());
                }
                dr.Close();
            }
            catch (Exception ex) 
            {  
                ex.ToString();
                Console.WriteLine("ERROR: Show Cruise");
            }
            finally
            {
                c.Close();
            }
            return a;
        }

        public ArrayList searchCruises(CruiseEN cr)
        {
            ArrayList a = new ArrayList();
            string s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Select * from Cruise where Id = " + cr.Id , c);
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    a.Add(dr["Id"].ToString());
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: Search Cruise");
            }
            finally
            {
                c.Close();
            }
            return a;
        }
         */ 
    }
}

