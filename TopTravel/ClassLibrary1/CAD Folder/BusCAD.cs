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
    //This class represents the entty Bus
    public class BusCAD
    {
        // Shows all the information about the buses
        public DataSet showBuses(BusEN b)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString(); //String where it's stored the instructions for the connecton for the DB
            DataSet virtdb = new DataSet();         //Created the DataSet that is going to be returned with the information asked
            SqlConnection c = new SqlConnection(s); //The connection is effectuated

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from Bus", c);   //The select in SQL language that is processed in the DB which will return all the rows from the table "Bus"
                da.Fill(virtdb, "bus");      //It introduces the information returned from the select into this virtual DB 

            }
            catch (Exception ex)
            {
                ex.ToString();      //In case of an error it is printed here
                Console.WriteLine("ERROR: show bus");
            }
            finally
            {
                c.Close();      //Closes the connection to the DB
            }
            return virtdb;              //It returns the virtual DB with all the information asked inside

        }
        //Shows information about the buses provided the departure and arrival cities
        public DataSet searchBuses(String b1, String b2)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString(); //String where it's stored the instructions for the connecton for the DB
            DataSet virtdb = new DataSet();         //Created the DataSet that is going to be returned with the information asked
            SqlConnection c = new SqlConnection(s); //The connection is effectuated

            try
            {                         //The select in SQL language that is processed in the DB which will return all the rows from the table "Bus"
                SqlDataAdapter da = new SqlDataAdapter("Select * from Bus where departureCity LIKE '%" + b1 + "%' and destinationCity LIKE '%" + b2 + "%'", c);
                da.Fill(virtdb, "bus");      //It introduces the information returned from the select into this virtual DB 

            }
            catch (Exception ex)
            {
                ex.ToString();      //In case of an error it is printed here
                Console.WriteLine("ERROR: show bus");
            }
            finally
            {
                c.Close();      //Closes the connection to the DB
            }
            return virtdb;              //It returns the virtual DB with all the information asked inside

        }
        //Provides the information of the bus given the id
        public DataSet searchIDBuses(String IDB)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString(); //String where it's stored the instructions for the connecton for the DB
            DataSet virtdb = new DataSet();         //Created the DataSet that is going to be returned with the information asked
            SqlConnection c = new SqlConnection(s); //The connection is effectuated

            try
            {                     //The select in SQL language that is processed in the DB which will return all the rows from the table "Bus"
                SqlDataAdapter da = new SqlDataAdapter("Select * from Bus where Id = '" + IDB + "'", c);
                da.Fill(virtdb, "bus");      //It introduces the information returned from the select into this virtual DB 

            }
            catch (Exception ex)
            {
                ex.ToString();      //In case of an error it is printed here
                Console.WriteLine("ERROR: show bus");
            }
            finally
            {
                c.Close();      //Closes the connection to the DB
            }
            return virtdb;              //It returns the virtual DB with all the information asked inside

        }

        //Adds a new bus to the DB
        public DataSet addBus(BusEN b)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString(); //String where it's stored the instructions for the connecton for the DB
            DataSet virtdb = new DataSet();         //Created the DataSet that is going to be returned with the information asked
            SqlConnection c = new SqlConnection(s); //The connection is effectuated
            try
            {                     //The select in SQL language that is processed in the DB which will return all the rows from the table "Bus"
                SqlDataAdapter da = new SqlDataAdapter("select * from Bus", c);
                da.Fill(virtdb, "bus");      //It introduces the information returned from the select into this virtual DB 
                DataTable dt = new DataTable(); //Creates a new table
                dt = virtdb.Tables["bus"];      //Fills it with the information obtained from the select
                DataRow newRow = dt.NewRow();   //Creates a new row
                newRow[0] = b.id;
                newRow[1] = b.DepartureTime;
                newRow[2] = b.ArrivaldTime;
                newRow[3] = b.DepartureCity;        //Introduces the information of the row
                newRow[4] = b.DestinationCity;
                newRow[5] = b.Price;
                newRow[6] = b.Company;
                newRow[7] = b.Extras;
                newRow[8] = b.Image;
                dt.Rows.Add(newRow);
                SqlCommandBuilder cbuilder = new SqlCommandBuilder(da); //Elaborates the SQL command needed to make the changes
                da.Update(virtdb, "bus");        //Updates the DB with the new information added
            }
            catch (Exception ex)
            {
                ex.ToString();      //In case of an error it is printed here
                Console.WriteLine("ERROR: Add bus");
            }
            finally
            {
                c.Close();      //Closes the connection to the DB
            }

            return virtdb;              //It returns the virtual DB with all the information asked inside
        }

        //Erases a bus from the DB given its id
        public DataSet deleteBus(BusEN b, int i) // It will delete the index passed in the view
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString(); //String where it's stored the instructions for the connecton for the DB
            DataSet virtdb = new DataSet();         //Created the DataSet that is going to be returned with the information asked
            SqlConnection c = new SqlConnection(s); //The connection is effectuated
            try
            {                     //The select in SQL language that is processed in the DB which will return all the rows from the table "Bus"
                SqlDataAdapter da = new SqlDataAdapter("select * from Bus", c);
                da.Fill(virtdb, "bus");     //It introduces the information returned from the select into this virtual DB 
                DataTable t = new DataTable();
                t = virtdb.Tables["bus"];   //Fills it with the information obtained from the select

                t.Rows[i].Delete();         //Erases the information related about this bus

                SqlCommandBuilder cbuilder = new SqlCommandBuilder(da); //Elaborates the SQL command needed to make the changes
                da.Update(virtdb, "bus");        //Updates the DB with the new information added
            }
            catch (Exception ex)
            {
                ex.ToString();      //In case of an error it is printed here
                Console.WriteLine("ERROR: Delete bus");
            }
            finally
            {
                c.Close();      //Closes the connection to the DB
            }
            return virtdb;              //It returns the virtual DB with all the information asked inside
        }
        //Updates the information available in the DB
        public DataSet updateBus(BusEN b, int i)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString(); //String where it's stored the instructions for the connecton for the DB
            DataSet virtdb = new DataSet();         //Created the DataSet that is going to be returned with the information asked
            SqlConnection c = new SqlConnection(s); //The connection is effectuated
            try
            {                     //The select in SQL language that is processed in the DB which will return all the rows from the table "Bus"
                SqlDataAdapter da = new SqlDataAdapter("select * from Bus", c);
                da.Fill(virtdb, "bus");     //It introduces the information returned from the select into this virtual DB 
                DataTable t = new DataTable();  //Creates a table
                t = virtdb.Tables["bus"];   //Fills it with the information obtained from the select

                t.Rows[i]["Id"] = b.id;
                t.Rows[i]["departureTime"] = b.DepartureTime;
                t.Rows[i]["arrivaldTime"] = b.ArrivaldTime;
                t.Rows[i]["departureCity"] = b.DepartureCity;
                t.Rows[i]["destinationCity"] = b.DestinationCity;   //Updates the atributes of the DB
                t.Rows[i]["price"] = b.Price;
                t.Rows[i]["company"] = b.Company;
                t.Rows[i]["extras"] = b.Extras;
                t.Rows[i]["image"] = b.Image;


                SqlCommandBuilder cbuilder = new SqlCommandBuilder(da); //Elaborates the SQL command needed to make the changes
                da.Update(virtdb, "bus");        //Updates the DB with the new information added
            }
            catch (Exception ex)
            {
                ex.ToString();      //In case of an error it is printed here
                Console.WriteLine("ERROR: Delete bus");
            }
            finally
            {
                c.Close();      //Closes the connection to the DB
            }
            return virtdb;              //It returns the virtual DB with all the information asked inside


        }
      
    }
}