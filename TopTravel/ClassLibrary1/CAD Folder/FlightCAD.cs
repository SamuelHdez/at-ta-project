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
    //This class represents the entity of a flight with its methods and atributes listed below
    public class FlightCAD
    {
        //It provides with the information of all the flights contained in the DB
        public DataSet showFlights(FlightEN b)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString(); //String where it's stored the instructions for the connecton for the DB
            DataSet virtdb = new DataSet();         //Created the DataSet that is going to be returned with the information asked
            SqlConnection c = new SqlConnection(s); //The connection is effectuated

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from Flight", c);  //The select in SQL language that is processed in the DB which will return all the rows from the table "Flight"
                da.Fill(virtdb, "flight");      //It introduces the information returned from the select into this virtual DB 

            }
            catch (Exception ex)
            {
                ex.ToString();      //In case of an error it is printed here
                Console.WriteLine("ERROR: show flight");
            }
            finally
            {
                c.Close();      //Closes the connection to the DB
            }
            return virtdb;              //It returns the virtual DB with all the information needed inside

        }
        //It behaves like showFlights but it includes some restrictions in the shearch, providing the departure and destination cities
        public DataSet searchFlights(String b1, String b2)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString(); //String where it's stored the instructions for the connecton for the DB
            DataSet virtdb = new DataSet();         //Created the DataSet that is going to be returned with the information asked
            SqlConnection c = new SqlConnection(s); //The connection is effectuated

            try
            {                                                     //The select in SQL language that is processed in the DB which will return all the rows from the table "Flight"
                SqlDataAdapter da = new SqlDataAdapter("Select * from Flight where departureCity LIKE '%" + b1 + "%' and destinationCity LIKE '%" + b2 + "%'", c);
                da.Fill(virtdb, "flight");      //It introduces the information returned from the select into this virtual DB 

            }
            catch (Exception ex)
            {
                ex.ToString();      //In case of an error it is printed here
                Console.WriteLine("ERROR: show flight");
            }
            finally
            {
                c.Close();      //Closes the connection to the DB
            }
            return virtdb;              //It returns the virtual DB with all the information needed inside

        }
        //Shows information about the flight with the provided id
        public DataSet searchIDFlights(String IDF)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString(); //String where it's stored the instructions for the connecton for the DB
            DataSet virtdb = new DataSet();         //Created the DataSet that is going to be returned with the information asked
            SqlConnection c = new SqlConnection(s); //The connection is effectuated

            try
            {                           //The select in SQL language that is processed in the DB which will return all the rows from the table "Flight"
                SqlDataAdapter da = new SqlDataAdapter("Select * from Flight where Id = '" + IDF + "'", c);
                da.Fill(virtdb, "flight");      //It introduces the information returned from the select into this virtual DB 

            }
            catch (Exception ex)
            {
                ex.ToString();      //In case of an error it is printed here
                Console.WriteLine("ERROR: show flight");
            }
            finally
            {
                c.Close();      //Closes the connection to the DB
            }
            return virtdb;              //It returns the virtual DB with all the information asked inside

        }

        //Adds a new flight to the DB
        public DataSet addFlight(FlightEN b)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString(); //String where it's stored the instructions for the connecton for the DB
            SqlConnection c = new SqlConnection(s); //The connection is effectuated
            DataSet virtdb = new DataSet();         //Created the DataSet that is going to be returned with the information asked
            try
            {               //The select in SQL language that is processed in the DB which will return all the rows from the table "Flight"
                SqlDataAdapter da = new SqlDataAdapter("select * from Flight", c);
                da.Fill(virtdb, "flight");      //It introduces the information returned from the select into this virtual DB 
                DataTable dt = new DataTable(); //Creates a new instance of a table
                dt = virtdb.Tables["flight"];   //Fills it with the information obtained from the select
                DataRow newRow = dt.NewRow();   //Creates a new row
                newRow[0] = b.id;
                newRow[1] = b.DepartureTime;
                newRow[2] = b.ArrivalTime;      //Fills it with the content of the new flight
                newRow[3] = b.DepartureCity;
                newRow[4] = b.DestinationCity;
                newRow[5] = b.classFlight;
                newRow[6] = b.Price;
                newRow[7] = b.Company;
                newRow[8] = b.Extras;
                newRow[9] = b.Image;
                dt.Rows.Add(newRow);
                SqlCommandBuilder cbuilder = new SqlCommandBuilder(da); //Elaborates the SQL command needed to make the changes
                da.Update(virtdb, "flight");        //Updates the DB with the new information added
            }
            catch (Exception ex)
            {
                ex.ToString();      //In case of an error it is printed here
                Console.WriteLine("ERROR: Add flight");
            }
            finally
            {
                c.Close();      //Closes the connection to the DB
            }

            return virtdb;              //It returns the virtual DB with all the information asked inside
        }

        //Removes all the information about an especific flight, provided its id
        public DataSet deleteFlight(FlightEN b, int i) // It will delete the index passed in the view
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString(); //String where it's stored the instructions for the connecton for the DB
            SqlConnection c = new SqlConnection(s); //The connection is effectuated
            DataSet virtdb = new DataSet();
            try
            {               //The select in SQL language that is processed in the DB which will return all the rows from the table "Flight"
                SqlDataAdapter da = new SqlDataAdapter("select * from Flight", c);
                da.Fill(virtdb, "flight");      //It introduces the information returned from the select into this virtual DB 
                DataTable t = new DataTable();  //Creates a new instance of a table
                t = virtdb.Tables["flight"];    //Fills it with the information obtained from the select

                t.Rows[i].Delete();             //Deletes the row

                SqlCommandBuilder cbuilder = new SqlCommandBuilder(da); //Elaborates the SQL command needed to make the changes
                da.Update(virtdb, "flight");    //Updates the DB with the new information
            }
            catch (Exception ex)
            {
                ex.ToString();      //In case of an error it is printed here
                Console.WriteLine("ERROR: Delete flight");
            }
            finally
            {
                c.Close();      //Closes the connection to the DB
            }
            return virtdb;              //It returns the virtual DB with all the information asked inside
        }
        //Updates the information of an especific flight provided its id
        public DataSet updateFlight(FlightEN b, int i)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString(); //String where it's stored the instructions for the connecton for the DB
            SqlConnection c = new SqlConnection(s); //The connection is effectuated
            DataSet virtdb = new DataSet();         //Created the DataSet that is going to be returned with the information asked
            try
            {                   //The select in SQL language that is processed in the DB which will return all the rows from the table "Flight"
                SqlDataAdapter da = new SqlDataAdapter("select * from Flight", c);
                da.Fill(virtdb, "flight");      //It introduces the information returned from the select into this virtual DB 
                DataTable t = new DataTable();  //Creates a new instance of a table
                t = virtdb.Tables["flight"];    //Fills it with the information obtained from the select

                t.Rows[i]["Id"] = b.id;
                t.Rows[i]["departureTime"] = b.DepartureTime;
                t.Rows[i]["arrivalTime"] = b.ArrivalTime;
                t.Rows[i]["departureCity"] = b.DepartureCity;   //Makes the changes in the atributes
                t.Rows[i]["destinationCity"] = b.DestinationCity;
                t.Rows[i]["ClassFlight"] = b.classFlight;
                t.Rows[i]["price"] = b.Price;
                t.Rows[i]["company"] = b.Company;
                t.Rows[i]["extras"] = b.Extras;
                t.Rows[i]["image"] = b.Image;


                SqlCommandBuilder cbuilder = new SqlCommandBuilder(da); //Elaborates the SQL command needed to make the changes
                da.Update(virtdb, "flight");    //Updates the DB with the new information
            }
            catch (Exception ex)
            {
                ex.ToString();      //In case of an error it is printed here
                Console.WriteLine("ERROR: Delete flight");
            }
            finally
            {
                c.Close();      //Closes the connection to the DB
            }
            return virtdb;              //It returns the virtual DB with all the information asked inside


        }

    }
}