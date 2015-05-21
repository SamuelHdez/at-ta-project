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
    //This class represents the entiti of Hotel with its methods and atributes below
    public class HotelCAD
    {
        //It provides with the information of all the hotels contained in the DB
        public DataSet showHotels(HotelEN h)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString(); //String where it's stored the instructions for the connecton for the DB
            DataSet virtdb = new DataSet();         //Created the DataSet that is going to be returned with the information asked
            SqlConnection c = new SqlConnection(s); //The connection is effectuated

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from Hotel", c);  //The select in SQL language that is processed in the DB which will return all the rows from the table "Hotel"
                da.Fill(virtdb, "hotel");      //It introduces the information returned from the select into this virtual DB 

            }
            catch (Exception ex)
            {
                ex.ToString();      //In case of an error it is printed here
                Console.WriteLine("ERROR: show hotel");
            }
            finally
            {
                c.Close();      //Closes the connection to the DB
            }
            return virtdb;              //It returns the virtual DB with all the information needed inside

        }

        public DataSet searchHotels(String h)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString(); //String where it's stored the instructions for the connecton for the DB
            DataSet virtdb = new DataSet();         //Created the DataSet that is going to be returned with the information asked
            SqlConnection c = new SqlConnection(s); //The connection is effectuated

            try
            {                       //The select in SQL language that is processed in the DB which will return all the rows from the table "Hotel"
                SqlDataAdapter da = new SqlDataAdapter("Select * from Hotel where City Like '%" + h + "%'", c);
                da.Fill(virtdb, "hotel");      //It introduces the information returned from the select into this virtual DB 

            }
            catch (Exception ex)
            {
                ex.ToString();      //In case of an error it is printed here
                Console.WriteLine("ERROR: show hotel");
            }
            finally
            {
                c.Close();      //Closes the connection to the DB
            }
            return virtdb;              //It returns the virtual DB with all the information needed inside

        }

        public DataSet searchIDHotels(String idH)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString(); //String where it's stored the instructions for the connecton for the DB
            DataSet virtdb = new DataSet();         //Created the DataSet that is going to be returned with the information asked
            SqlConnection c = new SqlConnection(s); //The connection is effectuated

            try
            {                       //The select in SQL language that is processed in the DB which will return all the rows from the table "Hotel"
                SqlDataAdapter da = new SqlDataAdapter("Select * from Hotel where Id = '" + idH + "'", c);
                da.Fill(virtdb, "hotel");      //It introduces the information returned from the select into this virtual DB 

            }
            catch (Exception ex)
            {
                ex.ToString();      //In case of an error it is printed here
                Console.WriteLine("ERROR: show hotel");
            }
            finally
            {
                c.Close();      //Closes the connection to the DB
            }
            return virtdb;              //It returns the virtual DB with all the information needed inside

        }


        public DataSet addHotel(HotelEN h)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString(); //String where it's stored the instructions for the connecton for the DB
            DataSet virtdb = new DataSet();         //Created the DataSet that is going to be returned with the information asked
            SqlConnection c = new SqlConnection(s); //The connection is effectuated
            try
            {                   //The select in SQL language that is processed in the DB which will return all the rows from the table "Hotel"
                SqlDataAdapter da = new SqlDataAdapter("select * from Hotel", c);
                da.Fill(virtdb, "hotel");      //It introduces the information returned from the select into this virtual DB 
                DataTable t = new DataTable();  //Creates a new table
                t = virtdb.Tables["hotel"];     //fills the DataTable with the information extrcted from the previous select

                DataRow newRow = t.NewRow();    //Creates a new row
                newRow[0] = h.Id;
                newRow[1] = h.Name;
                newRow[2] = h.City;
                newRow[3] = h.Phone;            //Introduces the information of the new hotel
                newRow[4] = h.Address;
                newRow[5] = h.Email;
                newRow[6] = h.Stars;
                newRow[7] = h.Bedrooms;
                newRow[8] = h.Price;
                newRow[9] = h.Company;
                newRow[10] = h.Extras;
                t.Rows.Add(newRow);             //Adds the row to the table
                SqlCommandBuilder cbuilder = new SqlCommandBuilder(da); //Elaborates the SQL command needed to make the changes
                da.Update(virtdb, "hotel");     //Updates the DB with the new information added
            }
            catch (Exception ex)
            {
                ex.ToString();      //In case of an error it is printed here
                Console.WriteLine("ERROR: Add hotel");
            }
            finally
            {
                c.Close();      //Closes the connection to the DB
            }
            return virtdb;              //It returns the virtual DB with all the information needed inside
        }

        public DataSet deleteHotel(HotelEN h, int i) // It will delete the index passed in the view
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString(); //String where it's stored the instructions for the connecton for the DB
            DataSet virtdb = new DataSet();         //Created the DataSet that is going to be returned with the information asked
            SqlConnection c = new SqlConnection(s); //The connection is effectuated
            try
            {                   //The select in SQL language that is processed in the DB which will return all the rows from the table "Hotel"
                SqlDataAdapter da = new SqlDataAdapter("select * from Hotel", c);
                da.Fill(virtdb, "hotel");       //It introduces the information returned from the select into this virtual DB 
                DataTable t = new DataTable();  //Creates a new table
                t = virtdb.Tables["hotel"];     //Fills it with the information gathered by the select

                t.Rows[i].Delete();             //Removes the row

                SqlCommandBuilder cbuilder = new SqlCommandBuilder(da); //Elaborates the SQL command needed to make the changes
                da.Update(virtdb, "hotel");     //Updates the DB with the new information
            }
            catch (Exception ex)
            {
                ex.ToString();      //In case of an error it is printed here
                Console.WriteLine("ERROR: Delete hotel");
            }
            finally
            {
                c.Close();      //Closes the connection to the DB
            }
            return virtdb;              //It returns the virtual DB with all the information needed inside
        }

        public DataSet updateHotel(HotelEN h, int i)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString(); //String where it's stored the instructions for the connecton for the DB
            DataSet virtdb = new DataSet();         //Created the DataSet that is going to be returned with the information asked
            SqlConnection c = new SqlConnection(s); //The connection is effectuated
            try
            {                   //The select in SQL language that is processed in the DB which will return all the rows from the table "Hotel"
                SqlDataAdapter da = new SqlDataAdapter("select * from Hotel", c);
                da.Fill(virtdb, "hotel");       //It introduces the information returned from the select into this virtual DB 
                DataTable t = new DataTable();  //Creates a new table
                t = virtdb.Tables["hotel"];     //Fills it with the information gathered by the select

                // t.Rows[i]["Id"] = h.Id;

                t.Rows[i]["Id"] = h.Id;
                t.Rows[i]["Name"] = h.Name;
                t.Rows[i]["City"] = h.City;
                t.Rows[i]["Phone"] = h.Phone;
                t.Rows[i]["Adress"] = h.Address;
                t.Rows[i]["Email"] = h.Email;           //Updates the new information
                t.Rows[i]["Stars"] = h.Stars;
                t.Rows[i]["Bedrooms"] = h.Bedrooms;
                t.Rows[i]["Price"] = h.Price;
                t.Rows[i]["company"] = h.Company;
                t.Rows[i]["extras"] = h.Extras;

                SqlCommandBuilder cbuilder = new SqlCommandBuilder(da); //Elaborates the SQL command needed to make the changes
                da.Update(virtdb, "hotel");     //Updates the DB with the new information added
            }
            catch (Exception ex)
            {
                ex.ToString();      //In case of an error it is printed here
                Console.WriteLine("ERROR: Delete hotel");
            }
            finally
            {
                c.Close();      //Closes the connection to the DB
            }
            return virtdb;              //It returns the virtual DB with all the information needed inside
        }
    }
}
