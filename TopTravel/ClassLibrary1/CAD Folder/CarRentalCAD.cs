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
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString(); //String where it's stored the instructions for the connecton for the DB
            DataSet virtdb = new DataSet();         //Created the DataSet that is going to be returned with the information asked
            SqlConnection c = new SqlConnection(s); //The connection is effectuated

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from CarRental", c);//The select in SQL language that is processed in the DB which will return all the rows from the table 
                da.Fill(virtdb, "carrental");      //It introduces the information returned from the select into this virtual DB 

            }
            catch (Exception ex)
            {
                ex.ToString();      //In case of an error it is printed here
                Console.WriteLine("ERROR: show carrental");
            }
            finally
            {
                c.Close();      //Closes the connection to the DB
            }
            return virtdb;              //It returns the virtual DB with all the information needed inside

        }

        public DataSet searchCarRental(String b1, String b2)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString(); //String where it's stored the instructions for the connecton for the DB
            DataSet virtdb = new DataSet();         //Created the DataSet that is going to be returned with the information asked
            SqlConnection c = new SqlConnection(s); //The connection is effectuated

            try
            {                   //The select in SQL language that is processed in the DB which will return all the rows from the table 
                SqlDataAdapter da = new SqlDataAdapter("Select * from CarRental where City LIKE '%" + b1 + "%' and Brand LIKE '%" + b2 + "%'", c);
                da.Fill(virtdb, "carrental");      //It introduces the information returned from the select into this virtual DB 

            }
            catch (Exception ex)
            {
                ex.ToString();      //In case of an error it is printed here
                Console.WriteLine("ERROR: show carrental");
            }
            finally
            {
                c.Close();      //Closes the connection to the DB
            }
            return virtdb;              //It returns the virtual DB with all the information needed inside

        }

        public DataSet searchIDCarRental(String IDcr)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString(); //String where it's stored the instructions for the connecton for the DB
            DataSet virtdb = new DataSet();         //Created the DataSet that is going to be returned with the information asked
            SqlConnection c = new SqlConnection(s); //The connection is effectuated

            try
            {                   //The select in SQL language that is processed in the DB which will return all the rows from the table 
                SqlDataAdapter da = new SqlDataAdapter("Select * from CarRental where Id = '" + IDcr + "'", c);
                da.Fill(virtdb, "carrental");      //It introduces the information returned from the select into this virtual DB 

            }
            catch (Exception ex)
            {
                ex.ToString();      //In case of an error it is printed here
                Console.WriteLine("ERROR: show carrental");
            }
            finally
            {
                c.Close();      //Closes the connection to the DB
            }
            return virtdb;              //It returns the virtual DB with all the information needed inside

        }


        public DataSet addCarRental(CarRentalEN cr)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString(); //String where it's stored the instructions for the connecton for the DB
            DataSet virtdb = new DataSet();         //Created the DataSet that is going to be returned with the information asked
            SqlConnection c = new SqlConnection(s); //The connection is effectuated
            try
            {                   //The select in SQL language that is processed in the DB which will return all the rows from the table 
                SqlDataAdapter da = new SqlDataAdapter("select * from CarRental", c);
                da.Fill(virtdb, "carrental");       //It introduces the information returned from the select into this virtual DB 
                DataTable dt = new DataTable();     //Creates a table
                dt = virtdb.Tables["carrental"];    //Fills it with the select content
                DataRow newRow = dt.NewRow();       //Creates a row
                newRow[0] = cr.id;
                newRow[1] = cr.city;
                newRow[2] = cr.brand;               //Introduces the information on the row
                newRow[3] = cr.model;
                newRow[4] = cr.days;
                newRow[5] = cr.Price;
                newRow[6] = cr.Company;
                newRow[7] = cr.Extras;
                newRow[8] = cr.Image;
                dt.Rows.Add(newRow);                //Adds the row to the table
                SqlCommandBuilder cbuilder = new SqlCommandBuilder(da); //Elaborates the SQL command needed to make the changes
                da.Update(virtdb, "carrental");     //Updates the DB with the new information added
            }
            catch (Exception ex)
            {
                ex.ToString();      //In case of an error it is printed here
                Console.WriteLine("ERROR: Add carrental");
            }
            finally
            {
                c.Close();      //Closes the connection to the DB
            }

            return virtdb;              //It returns the virtual DB with all the information needed inside
        }


        public DataSet deleteCarRental(CarRentalEN b, int i) // It will delete the index passed in the view
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString(); //String where it's stored the instructions for the connecton for the DB
            DataSet virtdb = new DataSet();         //Created the DataSet that is going to be returned with the information asked
            SqlConnection c = new SqlConnection(s); //The connection is effectuated
            try
            {                       //The select in SQL language that is processed in the DB which will return all the rows from the table 
                SqlDataAdapter da = new SqlDataAdapter("select * from CarRental", c);
                da.Fill(virtdb, "carrental");      //It introduces the information returned from the select into this virtual DB 
                DataTable t = new DataTable();      //Creates a new table
                t = virtdb.Tables["carrental"];     //Fills it with the select data

                t.Rows[i].Delete();                 //Erases a row where is stored the car we want to delete

                SqlCommandBuilder cbuilder = new SqlCommandBuilder(da); //Elaborates the SQL command needed to make the changes
                da.Update(virtdb, "carrental");        //Updates the DB with the new information added
            }
            catch (Exception ex)
            {
                ex.ToString();      //In case of an error it is printed here
                Console.WriteLine("ERROR: Delete carrental");
            }
            finally
            {
                c.Close();      //Closes the connection to the DB
            }
            return virtdb;              //It returns the virtual DB with all the information needed inside
        }

        public DataSet updateCarRental(CarRentalEN cr, int i)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString(); //String where it's stored the instructions for the connecton for the DB
            DataSet virtdb = new DataSet();         //Created the DataSet that is going to be returned with the information asked
            SqlConnection c = new SqlConnection(s); //The connection is effectuated
            try
            {                       //The select in SQL language that is processed in the DB which will return all the rows from the table 
                SqlDataAdapter da = new SqlDataAdapter("select * from CarRental", c);
                da.Fill(virtdb, "carrental");       //It introduces the information returned from the select into this virtual DB 
                DataTable t = new DataTable();      //creates a table
                t = virtdb.Tables["carrental"];     //Fills it with 

                t.Rows[i]["Id"] = cr.id;
                t.Rows[i]["City"] = cr.city;
                t.Rows[i]["Brand"] = cr.brand;      //Introduces in the row al the updated information
                t.Rows[i]["Model"] = cr.model;
                t.Rows[i]["Days"] = cr.days;
                t.Rows[i]["price"] = cr.Price;
                t.Rows[i]["company"] = cr.Company;
                t.Rows[i]["extras"] = cr.Extras;
                t.Rows[i]["image"] = cr.Image;


                SqlCommandBuilder cbuilder = new SqlCommandBuilder(da); //Elaborates the SQL command needed to make the changes
                da.Update(virtdb, "carrental");        //Updates the DB with the new information added
            }
            catch (Exception ex)
            {
                ex.ToString();      //In case of an error it is printed here
                Console.WriteLine("ERROR: Delete carrental");
            }
            finally
            {
                c.Close();      //Closes the connection to the DB
            }
            return virtdb;              //It returns the virtual DB with all the information needed inside
        }
    }
}