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
    //This class represents the entity of the Train
    public class TrainCAD
    {
        //Show all the information about all the trains of the DB
        public DataSet showTrains(TrainEN t)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString(); //String where it's stored the instructions for the connecton for the DB
            SqlConnection c = new SqlConnection(s); //The connection is effectuated
            DataSet virtdb = new DataSet();         //Created the DataSet that is going to be returned with the information asked

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from Train", c); //The select in SQL language that is processed in the DB which will return all the rows from the table "Train"
                da.Fill(virtdb, "train");      //It introduces the information returned from the select into this virtual DB 

            }
            catch (Exception ex)
            {
                ex.ToString();      //In case of an error it is printed here
                Console.WriteLine("ERROR: show train");
            }
            finally
            {
                c.Close();      //Closes the connection to the DB
            }
            return virtdb;              //It returns the virtual DB with all the information needed inside

        }

        public DataSet searchTrains(String t1, String t2)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString(); //String where it's stored the instructions for the connecton for the DB
            SqlConnection c = new SqlConnection(s); //The connection is effectuated
            DataSet virtdb = new DataSet();         //Created the DataSet that is going to be returned with the information asked

            try
            {                   //The select in SQL language that is processed in the DB which will return all the rows from the table "Train"
                SqlDataAdapter da = new SqlDataAdapter("Select * from Train where departureCity LIKE '%" + t1 + "%' and destinationCity LIKE '%" + t2 + "%'", c); //select statement filter by departure and destination cities
                da.Fill(virtdb, "train");      //It introduces the information returned from the select into this virtual DB 

            }
            catch (Exception ex)
            {
                ex.ToString();      //In case of an error it is printed here
                Console.WriteLine("ERROR: show train");
            }
            finally
            {
                c.Close();      //Closes the connection to the DB
            }
            return virtdb;              //It returns the virtual DB with all the information needed inside

        }

        public DataSet searchIDTrains(String IDT)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString(); //String where it's stored the instructions for the connecton for the DB
            SqlConnection c = new SqlConnection(s); //The connection is effectuated
            DataSet virtdb = new DataSet();         //Created the DataSet that is going to be returned with the information asked

            try
            {                   //The select in SQL language that is processed in the DB which will return all the rows from the table "Train"
                SqlDataAdapter da = new SqlDataAdapter("Select * from Train where Id = '" + IDT + "'", c); //select statement filter by id
                da.Fill(virtdb, "train");      //It introduces the information returned from the select into this virtual DB 

            }
            catch (Exception ex)
            {
                ex.ToString();      //In case of an error it is printed here
                Console.WriteLine("ERROR: show train");
            }
            finally
            {
                c.Close();      //Closes the connection to the DB
            }
            return virtdb;              //It returns the virtual DB with all the information needed inside

        }


        public DataSet addTrain(TrainEN t)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString(); //String where it's stored the instructions for the connecton for the DB
            SqlConnection c = new SqlConnection(s); //The connection is effectuated
            DataSet virtdb = new DataSet();         //Created the DataSet that is going to be returned with the information asked
            try
            {                   //The select in SQL language that is processed in the DB which will return all the rows from the table "Train"
                SqlDataAdapter da = new SqlDataAdapter("select * from Train", c);
                da.Fill(virtdb, "train");       //It introduces the information returned from the select into this virtual DB 
                DataTable dt = new DataTable(); //Creates a table
                dt = virtdb.Tables["train"];    //Fills it wwith the select
                DataRow newRow = dt.NewRow();   //Creates a new row
                newRow[0] = t.id;
                newRow[1] = t.DepartureTime;
                newRow[2] = t.ArrivalTime;      //Fills the row with the information of the new train
                newRow[3] = t.DepartureCity;
                newRow[4] = t.DestinationCity;
                newRow[5] = t.Price;
                newRow[6] = t.Company;
                newRow[7] = t.Extras;
                newRow[8] = t.Images;
                dt.Rows.Add(newRow);
                SqlCommandBuilder cbuilder = new SqlCommandBuilder(da); //Elaborates the SQL command needed to make the changes
                da.Update(virtdb, "train");     //Updates the DB with the new information added
            }
            catch (Exception ex)
            {
                ex.ToString();      //In case of an error it is printed here
                Console.WriteLine("ERROR: Add train");
            }
            finally
            {
                c.Close();      //Closes the connection to the DB
            }

            return virtdb;              //It returns the virtual DB with all the information needed inside
        }

        public DataSet deleteTrain(TrainEN tr, int i) // It will delete the index passed in the view
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString(); //String where it's stored the instructions for the connecton for the DB
            SqlConnection c = new SqlConnection(s); //The connection is effectuated
            DataSet virtdb = new DataSet();         //Created the DataSet that is going to be returned with the information asked
            try
            {                   //The select in SQL language that is processed in the DB which will return all the rows from the table "Train"
                SqlDataAdapter da = new SqlDataAdapter("select * from Train", c); //Select statement
                da.Fill(virtdb, "train");      //It introduces the information returned from the select into this virtual DB 
                DataTable t = new DataTable();
                t = virtdb.Tables["train"];

                t.Rows[i].Delete();         //Removes the row with the information of the train

                SqlCommandBuilder cbuilder = new SqlCommandBuilder(da); //Elaborates the SQL command needed to make the changes
                da.Update(virtdb, "train");        //Updates the DB with the new information added
            }
            catch (Exception ex)
            {
                ex.ToString();      //In case of an error it is printed here
                Console.WriteLine("ERROR: Delete train");
            }
            finally
            {
                c.Close();      //Closes the connection to the DB
            }
            return virtdb;              //It returns the virtual DB with all the information needed inside
        }

        public DataSet updateTrain(TrainEN tr, int i)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString(); //String where it's stored the instructions for the connecton for the DB
            SqlConnection c = new SqlConnection(s); //The connection is effectuated
            DataSet virtdb = new DataSet();         //Created the DataSet that is going to be returned with the information asked
            try
            {                   //The select in SQL language that is processed in the DB which will return all the rows from the table "Train"
                SqlDataAdapter da = new SqlDataAdapter("select * from Train", c); //select statement
                da.Fill(virtdb, "train");       //It introduces the information returned from the select into this virtual DB 
                DataTable t = new DataTable();  //Creates a table
                t = virtdb.Tables["train"];     //Fills it with the select

                t.Rows[i]["Id"] = tr.id;        //Updates the values
                t.Rows[i]["departureTime"] = tr.DepartureTime;
                t.Rows[i]["arrivalTime"] = tr.ArrivalTime;
                t.Rows[i]["departureCity"] = tr.DepartureCity;
                t.Rows[i]["destinationCity"] = tr.DestinationCity;
                t.Rows[i]["price"] = tr.Price;
                t.Rows[i]["company"] = tr.Company;
                t.Rows[i]["extras"] = tr.Extras;
                t.Rows[i]["images"] = tr.Images;


                SqlCommandBuilder cbuilder = new SqlCommandBuilder(da); //Elaborates the SQL command needed to make the changes
                da.Update(virtdb, "train");         //Updates the DB with the new information added
            }
            catch (Exception ex)
            {
                ex.ToString();      //In case of an error it is printed here
                Console.WriteLine("ERROR: Delete train");
            }
            finally
            {
                c.Close();      //Closes the connection to the DB
            }
            return virtdb;              //It returns the virtual DB with all the information needed inside
        }
      
    }
         
}