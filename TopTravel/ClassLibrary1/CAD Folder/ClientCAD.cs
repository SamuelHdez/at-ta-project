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
    public class ClientCAD
    {
        public DataSet showClient(ClientEN CL)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString(); //String where it's stored the instructions for the connecton for the DB
            SqlConnection c = new SqlConnection(s); //The connection is effectuated
            DataSet virtdb = new DataSet();         //Created the DataSet that is going to be returned with the information asked

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from Client", c); //The select in SQL language that is processed in the DB which will return all the rows from the table "Client"
                da.Fill(virtdb, "client");      //It introduces the information returned from the select into this virtual DB 

            }
            catch (Exception ex)
            {
                ex.ToString();      //In case of an error it is printed here
                Console.WriteLine("ERROR: show client");
            }
            finally
            {
                c.Close();      //Closes the connection to the DB
            }
            return virtdb; //It returns the virtual DB with all the information needed inside

        }

        public DataSet searchClients(String ID, String pass)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString(); //String where it's stored the instructions for the connecton for the DB
            SqlConnection c = new SqlConnection(s); //The connection is effectuated
            DataSet virtdb = new DataSet();         //Created the DataSet that is going to be returned with the information asked

            try
            {                   //The select in SQL language that is processed in the DB which will return all the rows from the table "Client"
                SqlDataAdapter da = new SqlDataAdapter("Select count(*) from Client where dni = '" + ID + "' and password = '" + pass + "'", c);
                da.Fill(virtdb, "client");      //It introduces the information returned from the select into this virtual DB 

            }
            catch (Exception ex)
            {
                ex.ToString();      //In case of an error it is printed here
                Console.WriteLine("ERROR: show client");
            }
            finally
            {
                c.Close();      //Closes the connection to the DB
            }
            return virtdb; //It returns the virtual DB with all the information needed inside
        }

        public DataSet showClientInfo(String ID)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString(); //String where it's stored the instructions for the connecton for the DB
            SqlConnection c = new SqlConnection(s); //The connection is effectuated
            DataSet virtdb = new DataSet();         //Created the DataSet that is going to be returned with the information asked

            try
            {                   //The select in SQL language that is processed in the DB which will return all the rows from the table "Client"
                SqlDataAdapter da = new SqlDataAdapter("Select * from Client where dni = '" + ID + "'", c); //select method filter by dni
                da.Fill(virtdb, "client");      //It introduces the information returned from the select into this virtual DB 

            }
            catch (Exception ex)
            {
                ex.ToString();      //In case of an error it is printed here
                Console.WriteLine("ERROR: show client");
            }
            finally
            {
                c.Close();      //Closes the connection to the DB
            }
            return virtdb; //It returns the virtual DB with all the information needed inside
        }

        public DataSet addClient(ClientEN CL)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString(); //String where it's stored the instructions for the connecton for the DB
            SqlConnection c = new SqlConnection(s); //The connection is effectuated
            DataSet virtdb = new DataSet();         //Created the DataSet that is going to be returned with the information asked
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from Client", c);  //The select in SQL language that is processed in the DB which will return all the rows from the table "Client" 
                da.Fill(virtdb, "client");      //It introduces the information returned from the select into this virtual DB 
                DataTable dt = new DataTable(); //Creates a table
                dt = virtdb.Tables["client"];   //Fills it with the select
                DataRow newRow = dt.NewRow(); //insert new values in the new row
                newRow[0] = CL.Dni;
                newRow[1] = CL.Name;
                newRow[2] = CL.Surname;     //Inserts the information of the new client
                newRow[3] = CL.Phone;
                newRow[4] = CL.Address;
                newRow[5] = CL.Gender;
                newRow[6] = CL.CreditCard;
                newRow[7] = CL.Admin;
                newRow[8] = CL.Password;
                newRow[9] = CL.Avatar;
                dt.Rows.Add(newRow);
                SqlCommandBuilder cbuilder = new SqlCommandBuilder(da); //Elaborates the SQL command needed to make the changes
                da.Update(virtdb, "client");        //Updates the DB with the new information added
            }
            catch (Exception ex)
            {
                ex.ToString();      //In case of an error it is printed here
                Console.WriteLine("ERROR: Add client");
            }
            finally
            {
                c.Close();      //Closes the connection to the DB
            }

            return virtdb; //It returns the virtual DB with all the information needed inside
        }


        public DataSet deleteClient(ClientEN CL, int i) // It will delete the index passed in the view
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString(); //String where it's stored the instructions for the connecton for the DB
            SqlConnection c = new SqlConnection(s); //The connection is effectuated
            DataSet virtdb = new DataSet();         //Created the DataSet that is going to be returned with the information asked
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from Client", c); //The select in SQL language that is processed in the DB which will return all the rows from the table "Client"
                da.Fill(virtdb, "client");      //It introduces the information returned from the select into this virtual DB 
                DataTable t = new DataTable();  //Creates a table
                t = virtdb.Tables["client"];    //Fills it with the select

                t.Rows[i].Delete(); //Deletes the row that has the information of the client

                SqlCommandBuilder cbuilder = new SqlCommandBuilder(da); //Elaborates the SQL command needed to make the changes
                da.Update(virtdb, "client");        //Updates the DB with the new information added
            }
            catch (Exception ex)
            {
                ex.ToString();      //In case of an error it is printed here
                Console.WriteLine("ERROR: Delete client");
            }
            finally
            {
                c.Close();      //Closes the connection to the DB
            }
            return virtdb; //It returns the virtual DB with all the information needed inside
        }

        public void updateClient2(ClientEN b, string ID)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString(); //String where it's stored the instructions for the connecton for the DB
            SqlConnection c = new SqlConnection(s); //The connection is effectuated
            try
            {
                c.Open();   //The select in SQL language that is processed in the DB which will return all the rows from the table "Client"
                SqlCommand com = new SqlCommand("Update Client Set name = '" + b.Name + "', surname ='" +b.Surname + "', phone = '" + b.Phone + "', address = '" + b.Address + "', creditCard = '" +b.CreditCard + "', admin = '" + 0 + "', avatar = '"+ b.Avatar +"', password = '"+ b.Password +"' Where dni = '" + ID + "'", c);

                com.ExecuteNonQuery();      //Executes the SQL statement
            }
            catch (Exception ex)
            {
                ex.ToString();      //In case of an error it is printed here
                Console.WriteLine("ERROR: Update Client");
            }
            finally
            {
                c.Close();      //Closes the connection to the DB
            }
        }

        public DataSet updateClient(ClientEN CL, int i)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString(); //String where it's stored the instructions for the connecton for the DB
            SqlConnection c = new SqlConnection(s); //The connection is effectuated
            DataSet virtdb = new DataSet();         //Created the DataSet that is going to be returned with the information asked
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from Client'", c); //The select in SQL language that is processed in the DB which will return all the rows from the table 
                da.Fill(virtdb, "client");      //It introduces the information returned from the select into this virtual DB 
                DataTable t = new DataTable();  //Creates a table
                t = virtdb.Tables["client"];    //Fills it with the select

                t.Rows[i]["dni"] = CL.Dni;                  //Updates the informationin the rows
                t.Rows[i]["name"] = CL.Name;
                t.Rows[i]["surname"] = CL.Surname;
                t.Rows[i]["phone"] = CL.Phone;
                t.Rows[i]["address"] = CL.Address;
                t.Rows[i]["gender"] = CL.Gender;
                t.Rows[i]["creditCard"] = CL.CreditCard;
                t.Rows[i]["admin"] = CL.Admin;
                t.Rows[i]["password"] = CL.Password;
                t.Rows[i]["avatar"] = CL.Avatar;


                SqlCommandBuilder cbuilder = new SqlCommandBuilder(da); //Elaborates the SQL command needed to make the changes
                da.Update(virtdb, "client");        //Updates the DB with the new information added
            }
            catch (Exception ex)
            {
                ex.ToString();      //In case of an error it is printed here
                Console.WriteLine("ERROR: Delete client");
            }
            finally
            {
                c.Close();      //Closes the connection to the DB
            }
            return virtdb;              //It returns the virtual DB with all the information asked inside


        }
    }
}