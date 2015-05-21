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
    //THis class represents the entity Extras
    class ExtrasCAD
    {
        //Shearches for a specific Extra given its id
        public DataSet searchExtrasID(string idx)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString(); //String where it's stored the instructions for the connecton for the DB
            SqlConnection c = new SqlConnection(s); //The connection is effectuated
            DataSet virtdb = new DataSet();         //Created the DataSet that is going to be returned with the information asked

            try
            {                   //The select in SQL language that is processed in the DB which will return all the rows from the table "extra"
                SqlDataAdapter da = new SqlDataAdapter("Select * from Extras where Id = '" + idx + "'", c);
                da.Fill(virtdb, "extra");      //It introduces the information returned from the select into this virtual DB 

            }
            catch (Exception ex)
            {
                ex.ToString();      //In case of an error it is printed here
                Console.WriteLine("ERROR: show extra");
            }
            finally
            {
                c.Close();      //Closes the connection to the DB
            }
            return virtdb;

        }
        //Adds a new Extra to the DB
        public void addExtra(ExtrasEN e)
        {
            string s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString(); //String where it's stored the instructions for the connecton for the DB
            SqlConnection c = new SqlConnection(s); //The connection is effectuated
            try
            {
                c.Open();                   //The select in SQL language that is processed in the DB which will return all the rows from the table "extra"
                SqlCommand com = new SqlCommand("Insert Into Extras (Id,WiFi,Food,Discount) VALUES ('" + e.Id + "','" + e.WiFi + "','" + e.Food + "','" +
                    e.Discount + "')", c);

                com.ExecuteNonQuery();     //Executes the SQL command
            }
            catch (Exception exc)
            {
                exc.ToString();      //In case of an error it is printed here
                Console.WriteLine("ERROR: Add extra");
            }
            finally
            {
                c.Close();      //Closes the connection to the DB
            }
        }
        //Removes an existing Extra form the DB
        public void deleteExtra(ExtrasEN e)
        {
            string s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString(); //String where it's stored the instructions for the connecton for the DB
            SqlConnection c = new SqlConnection(s); //The connection is effectuated
            try
            {
                c.Open();                   //The select in SQL language that is processed in the DB which will return all the rows from the table "extra"
                SqlCommand com = new SqlCommand("Delete From Extras Where Id = " + e.Id, c);
                com.ExecuteNonQuery();     //Executes the SQL command
            }
            catch (Exception exc)
            {
                exc.ToString();      //In case of an error it is printed here
                Console.WriteLine("ERROR: Delete extra");
            }
            finally
            {
                c.Close();      //Closes the connection to the DB
            }
        }
        //Updates the information of a Extra form the DB
        public void updateExtra(ExtrasEN e)
        {
            string s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString(); //String where it's stored the instructions for the connecton for the DB
            SqlConnection c = new SqlConnection(s); //The connection is effectuated
            try
            {
                c.Open();                   //The select in SQL language that is processed in the DB which will return all the rows from the table "extra"
                SqlCommand com = new SqlCommand("Update Extras Set WiFi = '" + e.WiFi + "', Food = '" + e.Food + "', Discount ='" +
                    e.Discount + "' Where Id = " + e.Id, c);
                com.ExecuteNonQuery();     //Executes the SQL command
            }
            catch (Exception exc)
            {
                exc.ToString();      //In case of an error it is printed here
                Console.WriteLine("ERROR: Update extra");
            }
            finally
            {
                c.Close();      //Closes the connection to the DB
            }
        }
        //Shows and lists the Extras available in the DB
        public ArrayList showExtras()
        {
            ArrayList a = new ArrayList();
            string s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString(); //String where it's stored the instructions for the connecton for the DB
            SqlConnection c = new SqlConnection(s); //The connection is effectuated
            try
            {
                c.Open();                   //The select in SQL language that is processed in the DB which will return all the rows from the table "extra"
                SqlCommand com = new SqlCommand("Select * from Extras", c);
                SqlDataReader dr = com.ExecuteReader();     //Executes the SQL command
                while (dr.Read())
                {
                    a.Add(dr["Id"].ToString());     //Gathers the information
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                ex.ToString();      //In case of an error it is printed here
                Console.WriteLine("ERROR: Show extras");
            }
            finally
            {
                c.Close();      //Closes the connection to the DB
            }
            return a;       //Returns an arrayList with the information
        }

    }
}
