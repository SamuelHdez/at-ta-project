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
    public class CarRentalCAD
    {
        public DataSet showCarRental(CarRentalEN CR)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            DataSet virtdb = new DataSet();
            SqlConnection c = new SqlConnection(s);

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from CarRental", c);
                da.Fill(virtdb, "carrental");

            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: show carrental");
            }
            finally
            {
                c.Close();
            }
            return virtdb;

        }

        public DataSet searchCarRental(String b1, String b2)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            DataSet virtdb = new DataSet();
            SqlConnection c = new SqlConnection(s);

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * from CarRental where City LIKE '%" + b1 + "%' and Brand LIKE '%" + b2 + "%'", c);
                da.Fill(virtdb, "carrental");

            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: show carrental");
            }
            finally
            {
                c.Close();
            }
            return virtdb;

        }

        public DataSet searchIDCarRental(String IDcr)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            DataSet virtdb = new DataSet();
            SqlConnection c = new SqlConnection(s);

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * from CarRental where Id = '" + IDcr + "'", c);
                da.Fill(virtdb, "carrental");

            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: show carrental");
            }
            finally
            {
                c.Close();
            }
            return virtdb;

        }


        public DataSet addCarRental(CarRentalEN cr)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            DataSet virtdb = new DataSet();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from CarRental", c);
                da.Fill(virtdb, "carrental");
                DataTable dt = new DataTable();
                dt = virtdb.Tables["carrental"];
                DataRow newRow = dt.NewRow();
                newRow[0] = cr.id;
                newRow[1] = cr.city;
                newRow[2] = cr.brand;
                newRow[3] = cr.model;
                newRow[4] = cr.days;
                newRow[5] = cr.Price;
                newRow[6] = cr.Company;
                newRow[7] = cr.Extras;
                newRow[8] = cr.Image;
                dt.Rows.Add(newRow);
                SqlCommandBuilder cbuilder = new SqlCommandBuilder(da);
                da.Update(virtdb, "carrental");
            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: Add carrental");
            }
            finally
            {
                c.Close();
            }

            return virtdb;
        }


        public DataSet deleteCarRental(CarRentalEN b, int i) // It will delete the index passed in the view
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            DataSet virtdb = new DataSet();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from CarRental", c);
                da.Fill(virtdb, "carrental");
                DataTable t = new DataTable();
                t = virtdb.Tables["carrental"];

                t.Rows[i].Delete();

                SqlCommandBuilder cbuilder = new SqlCommandBuilder(da);
                da.Update(virtdb, "carrental");
            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: Delete carrental");
            }
            finally
            {
                c.Close();
            }
            return virtdb;
        }

        public DataSet updateCarRental(CarRentalEN cr, int i)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            DataSet virtdb = new DataSet();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from CarRental", c);
                da.Fill(virtdb, "carrental");
                DataTable t = new DataTable();
                t = virtdb.Tables["carrental"];

                t.Rows[i]["Id"] = cr.id;
                t.Rows[i]["City"] = cr.city;
                t.Rows[i]["Brand"] = cr.brand;
                t.Rows[i]["Model"] = cr.model;
                t.Rows[i]["Days"] = cr.days;
                t.Rows[i]["price"] = cr.Price;
                t.Rows[i]["company"] = cr.Company;
                t.Rows[i]["extras"] = cr.Extras;
                t.Rows[i]["image"] = cr.Image;


                SqlCommandBuilder cbuilder = new SqlCommandBuilder(da);
                da.Update(virtdb, "carrental");
            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: Delete carrental");
            }
            finally
            {
                c.Close();
            }
            return virtdb;


        }

    }
}