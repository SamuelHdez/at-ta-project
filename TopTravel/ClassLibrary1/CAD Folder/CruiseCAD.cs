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
    //This class represents the entity of the Cruise
    public class CruiseCAD
    {
        //Shows all the information about all the cruises of the DB
        public DataSet showCruises(CruiseEN b)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString(); //String where it's stored the instructions for the connecton for the DB
            SqlConnection c = new SqlConnection(s); //The connection is effectuated
            DataSet virtdb = new DataSet();         //Created the DataSet that is going to be returned with the information asked

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from Cruise", c);  //The select in SQL language that is processed in the DB which will return all the rows from the table "Cruise"
                da.Fill(virtdb, "cruise");      //It introduces the information returned from the select into this virtual DB 

            }
            catch (Exception ex)
            {
                ex.ToString();      //In case of an error it is printed here
                Console.WriteLine("ERROR: show cruise");
            }
            finally
            {
                c.Close();      //Closes the connection to the DB
            }
            return virtdb;      //It returns the virtual DB with all the information asked inside

        }
        //Shearches for all the cruises with the provided route and city
        public DataSet searchCruises(String reg, String ci)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString(); //String where it's stored the instructions for the connecton for the DB
            SqlConnection c = new SqlConnection(s); //The connection is effectuated
            DataSet virtdb = new DataSet();         //Created the DataSet that is going to be returned with the information asked

            try
            {                   //The select in SQL language that is processed in the DB which will return all the rows from the table "Cruise"
                SqlDataAdapter da = new SqlDataAdapter("Select * from Cruise where Route LIKE '%" + reg + "%' and City LIKE '%" + ci + "%'", c);
                da.Fill(virtdb, "cruise");      //It introduces the information returned from the select into this virtual DB 

            }
            catch (Exception ex)
            {
                ex.ToString();      //In case of an error it is printed here
                Console.WriteLine("ERROR: show cruise");
            }
            finally
            {
                c.Close();      //Closes the connection to the DB
            }
            return virtdb;      //It returns the virtual DB with all the information asked inside
        }
        //Shearches for a specific cruise provided its id
        public DataSet searchIDCruises(String IDc)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString(); //String where it's stored the instructions for the connecton for the DB
            SqlConnection c = new SqlConnection(s); //The connection is effectuated
            DataSet virtdb = new DataSet();         //Created the DataSet that is going to be returned with the information asked

            try
            {                      //The select in SQL language that is processed in the DB which will return all the rows from the table "Cruise"
                SqlDataAdapter da = new SqlDataAdapter("Select * from Cruise where Id = '" + IDc + "'", c);
                da.Fill(virtdb, "cruise");      //It introduces the information returned from the select into this virtual DB 

            }
            catch (Exception ex)
            {
                ex.ToString();      //In case of an error it is printed here
                Console.WriteLine("ERROR: show cruise");
            }
            finally
            {
                c.Close();      //Closes the connection to the DB
            }
            return virtdb;      //It returns the virtual DB with all the information asked inside
        }
        //Adds a new Cruise to the DB
        public DataSet addCruise(CruiseEN b)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString(); //String where it's stored the instructions for the connecton for the DB
            SqlConnection c = new SqlConnection(s); //The connection is effectuated
            DataSet virtdb = new DataSet();         //Created the DataSet that is going to be returned with the information asked
            try
            {                       //The select in SQL language that is processed in the DB which will return all the rows from the table "Cruise"
                SqlDataAdapter da = new SqlDataAdapter("Select * from Cruise", c);
                da.Fill(virtdb, "cruise");      //It introduces the information returned from the select into this virtual DB 
                DataTable dt = new DataTable(); //Creates a table
                dt = virtdb.Tables["cruise"];   //Fills it with the select information
                DataRow newRow = dt.NewRow();   //Crreates a new row
                newRow[0] = b.id;
                newRow[1] = b.DepartureTime;
                newRow[2] = b.ArrivalTime;      //Fills the row with the information of the new cruise
                newRow[3] = b.city;
                newRow[4] = b.route;
                newRow[5] = b.Price;
                newRow[6] = b.Company;
                newRow[7] = b.Extras;
                dt.Rows.Add(newRow);            //Inserts the row to the table
                SqlCommandBuilder cbuilder = new SqlCommandBuilder(da); //Elaborates the SQL command needed to make the changes
                da.Update(virtdb, "cruise");        //Updates the DB with the new information added
            }
            catch (Exception ex)
            {
                ex.ToString();      //In case of an error it is printed here
                Console.WriteLine("ERROR: Add cruise");
            }
            finally
            {
                c.Close();      //Closes the connection to the DB
            }

            return virtdb;      //It returns the virtual DB with all the information asked inside
        }
        //Removes a cruise from the DB
        public DataSet deleteCruise(CruiseEN b, int i) // It will delete the index passed in the view
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString(); //String where it's stored the instructions for the connecton for the DB
            SqlConnection c = new SqlConnection(s); //The connection is effectuated
            DataSet virtdb = new DataSet();         //Created the DataSet that is going to be returned with the information asked
            try
            {                       //The select in SQL language that is processed in the DB which will return all the rows from the table "Cruise"
                SqlDataAdapter da = new SqlDataAdapter("Select * from Cruise", c);
                da.Fill(virtdb, "cruise");      //It introduces the information returned from the select into this virtual DB 
                DataTable t = new DataTable();  //Creates a table
                t = virtdb.Tables["cruise"];    //Fills it with the select

                t.Rows[i].Delete();             //Removes the cruise from the table

                SqlCommandBuilder cbuilder = new SqlCommandBuilder(da); //Elaborates the SQL command needed to make the changes
                da.Update(virtdb, "cruise");        //Updates the DB with the new information added
            }
            catch (Exception ex)
            {
                ex.ToString();      //In case of an error it is printed here
                Console.WriteLine("ERROR: Delete cruise");
            }
            finally
            {
                c.Close();      //Closes the connection to the DB
            }
            return virtdb;      //It returns the virtual DB with all the information asked inside
        }
        //Updates the information of a cruise
        public DataSet updateCruise(CruiseEN b, int i)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString(); //String where it's stored the instructions for the connecton for the DB
            SqlConnection c = new SqlConnection(s); //The connection is effectuated
            DataSet virtdb = new DataSet();         //Created the DataSet that is going to be returned with the information asked
            try
            {                       //The select in SQL language that is processed in the DB which will return all the rows from the table "Cruise"
                SqlDataAdapter da = new SqlDataAdapter("Select * from Cruise", c);
                da.Fill(virtdb, "cruise");      //It introduces the information returned from the select into this virtual DB 
                DataTable t = new DataTable();  //Creates a table
                t = virtdb.Tables["cruise"];    //Fills it with the information of the select

                //t.Rows[i]["Id"] = b.id;

                t.Rows[i]["Id"] = b.id;
                t.Rows[i]["departureTime"] = b.DepartureTime;
                t.Rows[i]["arrivalTime"] = b.ArrivalTime;       //Updates the information
                t.Rows[i]["city"] = b.city;
                t.Rows[i]["route"] = b.route;
                t.Rows[i]["price"] = b.Price;
                t.Rows[i]["company"] = b.Company;
                t.Rows[i]["extras"] = b.Extras;


                SqlCommandBuilder cbuilder = new SqlCommandBuilder(da); //Elaborates the SQL command needed to make the changes
                da.Update(virtdb, "cruise");        //Updates the DB with the new information added
            }
            catch (Exception ex)
            {
                ex.ToString();      //In case of an error it is printed here
                Console.WriteLine("ERROR: Delete cruise");
            }
            finally
            {
                c.Close();      //Closes the connection to the DB
            }
            return virtdb;      //It returns the virtual DB with all the information asked inside
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

