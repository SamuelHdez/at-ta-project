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
    //THis class represents the entity Space Travel
    class SpaceTravelCAD
    {
        //Shows all the information about all the space travels in the DB
        public DataSet showSpaceTravels(SpaceTravelEN SP)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString(); //String where it's stored the instructions for the connecton for the DB
            SqlConnection c = new SqlConnection(s); //The connection is effectuated
            DataSet virtdb = new DataSet();         //Created the DataSet that is going to be returned with the information asked

            try
            {                   //The select in SQL language that is processed in the DB which will return all the rows from the table "SpaceTravel"
                SqlDataAdapter da = new SqlDataAdapter("select * from SpaceTravel", c);
                da.Fill(virtdb, "spaceTravel");      //It introduces the information returned from the select into this virtual DB

            }
            catch (Exception ex)
            {
                ex.ToString();      //In case of an error it is printed here
                Console.WriteLine("ERROR: show spaceTravel");
            }
            finally
            {
                c.Close();      //Closes the connection to the DB
            }
            return virtdb;              //It returns the virtual DB with all the information needed inside

        }
        //Searches for space travels matching the departure city provided
        public DataSet searchSpaceTravels(String DP)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString(); //String where it's stored the instructions for the connecton for the DB
            SqlConnection c = new SqlConnection(s); //The connection is effectuated
            DataSet virtdb = new DataSet();         //Created the DataSet that is going to be returned with the information asked

            try
            {                   //The select in SQL language that is processed in the DB which will return all the rows from the table "SpaceTravel"
                SqlDataAdapter da = new SqlDataAdapter("Select * from SpaceTravel where departureCity LIKE '%" + DP + "%'", c);
                da.Fill(virtdb, "spaceTravel");      //It introduces the information returned from the select into this virtual DB

            }
            catch (Exception ex)
            {
                ex.ToString();      //In case of an error it is printed here
                Console.WriteLine("ERROR: show spaceTravel");
            }
            finally
            {
                c.Close();      //Closes the connection to the DB
            }
            return virtdb;              //It returns the virtual DB with all the information needed inside

        }
        //Shearches for a specific space travel given its id
        public DataSet searchIDSpaceTravels(String IDsp)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString(); //String where it's stored the instructions for the connecton for the DB
            SqlConnection c = new SqlConnection(s); //The connection is effectuated
            DataSet virtdb = new DataSet();         //Created the DataSet that is going to be returned with the information asked

            try
            {                   //The select in SQL language that is processed in the DB which will return all the rows from the table "SpaceTravel"
                SqlDataAdapter da = new SqlDataAdapter("Select * from SpaceTravel where Id = '" + IDsp + "'", c);
                da.Fill(virtdb, "spaceTravel");      //It introduces the information returned from the select into this virtual DB

            }
            catch (Exception ex)
            {
                ex.ToString();      //In case of an error it is printed here
                Console.WriteLine("ERROR: show spaceTravel");
            }
            finally
            {
                c.Close();      //Closes the connection to the DB
            }
            return virtdb;              //It returns the virtual DB with all the information needed inside

        }
        //Adds a new space travel to the DB
        public DataSet addSpaceTravel(SpaceTravelEN SP)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString(); //String where it's stored the instructions for the connecton for the DB
            SqlConnection c = new SqlConnection(s); //The connection is effectuated
            DataSet virtdb = new DataSet();         //Created the DataSet that is going to be returned with the information asked
            try
            {                   //The select in SQL language that is processed in the DB which will return all the rows from the table "SpaceTravel"
                SqlDataAdapter da = new SqlDataAdapter("select * from SpaceTravel", c);
                da.Fill(virtdb, "spaceTravel");     //It introduces the information returned from the select into this virtual DB
                DataTable dt = new DataTable();     //Creates a table
                dt = virtdb.Tables["spaceTravel"];  //Fills it with the select
                DataRow newRow = dt.NewRow();       //Creates a new row
                newRow[0] = SP.id;
                newRow[1] = SP.DepartureDate;
                newRow[2] = SP.ArrivalDate;         //Fills the row with the new space travel
                newRow[3] = SP.DepartureCity;
                newRow[4] = SP.preparationCenter;
                newRow[5] = SP.Price;
                newRow[6] = SP.Company;
                newRow[7] = SP.Extras;
                newRow[8] = SP.Images;
                dt.Rows.Add(newRow);                //Inserts the row to the table
                SqlCommandBuilder cbuilder = new SqlCommandBuilder(da); //Elaborates the SQL command needed to make the changes
                da.Update(virtdb, "spaceTravel");        //Updates the DB with the new information added
            }
            catch (Exception ex)
            {
                ex.ToString();      //In case of an error it is printed here
                Console.WriteLine("ERROR: Add spaceTravel");
            }
            finally
            {
                c.Close();      //Closes the connection to the DB
            }

            return virtdb;              //It returns the virtual DB with all the information needed inside
        }
        //Removes the information of a space travel form the DB provided its id
        public DataSet deleteSpaceTravel(SpaceTravelEN SP, int i) // It will delete the index passed in the view
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString(); //String where it's stored the instructions for the connecton for the DB
            SqlConnection c = new SqlConnection(s); //The connection is effectuated
            DataSet virtdb = new DataSet();         //Created the DataSet that is going to be returned with the information asked
            try
            {                   //The select in SQL language that is processed in the DB which will return all the rows from the table "SpaceTravel"
                SqlDataAdapter da = new SqlDataAdapter("select * from SpaceTravel", c);
                da.Fill(virtdb, "spaceTravel");     //It introduces the information returned from the select into this virtual DB
                DataTable t = new DataTable();      //Creates a table
                t = virtdb.Tables["spaceTravel"];   //Fills it with the select

                t.Rows[i].Delete();                 //Removes the row with the information of the space travel

                SqlCommandBuilder cbuilder = new SqlCommandBuilder(da); //Elaborates the SQL command needed to make the changes
                da.Update(virtdb, "spaceTravel");        //Updates the DB with the new information added
            }
            catch (Exception ex)
            {
                ex.ToString();      //In case of an error it is printed here
                Console.WriteLine("ERROR: Delete spaceTravel");
            }
            finally
            {
                c.Close();      //Closes the connection to the DB
            }
            return virtdb;              //It returns the virtual DB with all the information needed inside
        }
        //Updates the infomation about a space travel given its id from the DB
        public DataSet updateSpaceTravel(SpaceTravelEN SP, int i)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString(); //String where it's stored the instructions for the connecton for the DB
            SqlConnection c = new SqlConnection(s); //The connection is effectuated
            DataSet virtdb = new DataSet();         //Created the DataSet that is going to be returned with the information asked
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from SpaceTravel", c); //The select in SQL language that is processed in the DB which will return all the rows from the table "SpaceTravel"
                da.Fill(virtdb, "spaceTravel");     //It introduces the information returned from the select into this virtual DB
                DataTable t = new DataTable();      //Creates the table
                t = virtdb.Tables["spaceTravel"];   //Fills it with the select

                t.Rows[i]["Id"] = SP.id;
                t.Rows[i]["departureDate"] = SP.DepartureDate;      //Updates the information of the space travel
                t.Rows[i]["arrivalDate"] = SP.ArrivalDate;
                t.Rows[i]["departureCity"] = SP.DepartureCity;
                t.Rows[i]["Preparation Center"] = SP.preparationCenter;
                t.Rows[i]["price"] = SP.Price;
                t.Rows[i]["company"] = SP.Company;
                t.Rows[i]["extras"] = SP.Extras;
                t.Rows[i]["images"] = SP.Images;


                SqlCommandBuilder cbuilder = new SqlCommandBuilder(da); //Elaborates the SQL command needed to make the changes
                da.Update(virtdb, "spaceTravel");        //Updates the DB with the new information added
            }
            catch (Exception ex)
            {
                ex.ToString();      //In case of an error it is printed here
                Console.WriteLine("ERROR: Delete spaceTravel");
            }
            finally
            {
                c.Close();      //Closes the connection to the DB
            }
            return virtdb;              //It returns the virtual DB with all the information needed inside


        }
        /*
        public void add_SpaceTravel(SpaceTravelEN b)
        {
            string s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Insert Into SpaceTravel (Id,departureDate,arrivalDate,departureCity,Preparation Center) VALUES ('" + b.Id + "','" + b.departureDate + "','" + b.arrivalDate + "','" +
                    b.departureCity + "','" + b.PreparationCenter + "')", c);

                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ex.ToString();      //In case of an error it is printed here
                Console.WriteLine("ERROR: Add SpaceTravel");
            }
            finally
            {
                c.Close();      //Closes the connection to the DB
            }
        }
        public void delete_SpaceTravel(SpaceTravelEN b)
        {
            string s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Delete From SpaceTravel Where Id = " + b.Id, c);
                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ex.ToString();      //In case of an error it is printed here
                Console.WriteLine("ERROR: Delete SpaceTravel");
            }
            finally
            {
                c.Close();      //Closes the connection to the DB
            }
        }
        public void update_SpaceTravel(SpaceTravelEN b)
        {
            string s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Update SpaceTravel Set departureDate = '" + b.departureDate + "', arrivalDate = '" + b.arrivalDate + "', departureCity ='" +
                    b.departureCity + ",' Preparation Center  '= " + b.PreparationCenter + "' Where ID = " + b.Id, c);
                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ex.ToString();      //In case of an error it is printed here
                Console.WriteLine("ERROR: Update SpaceTravel");
            }
            finally
            {
                c.Close();      //Closes the connection to the DB
            }
        }
        public ArrayList show_SpaceTravel()
        {
            ArrayList a = new ArrayList();
            string s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Select * from SpaceTravel", c);
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    a.Add(dr["Id"].ToString());
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                ex.ToString();      //In case of an error it is printed here
                Console.WriteLine("ERROR: Show SpaceTravel");
            }
            finally
            {
                c.Close();      //Closes the connection to the DB
            }
            return a;
        }
        public ArrayList search_SpaceTravel(SpaceTravelEN b)
        {
            ArrayList a = new ArrayList();
            string s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Select * from SpaceTravel where Id = " + b.Id, c);
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    a.Add(dr["Id"].ToString());
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                ex.ToString();      //In case of an error it is printed here
                Console.WriteLine("ERROR: Search SpaceTravel");
            }
            finally
            {
                c.Close();      //Closes the connection to the DB
            }
            return a;
        } */
    }
}
