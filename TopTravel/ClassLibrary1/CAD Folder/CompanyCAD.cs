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
    //This class represents the entity Company
    public class CompanyCAD
    {
        // Shows the information of all the companies in the DB
        public DataSet showCompanies(CompanyEN b)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString(); //String where it's stored the instructions for the connecton for the DB
            SqlConnection c = new SqlConnection(s); //The connection is effectuated
            DataSet virtdb = new DataSet();         //Created the DataSet that is going to be returned with the information asked

            try
            {                   //The select in SQL language that is processed in the DB which will return all the rows from the table "Flight"
                SqlDataAdapter da = new SqlDataAdapter("select * from Company", c); //The select in SQL language that is processed in the DB which will return all the rows from the table 
                da.Fill(virtdb, "company");      //It introduces the information returned from the select into this virtual DB 

            }
            catch (Exception ex)
            {
                ex.ToString();      //In case of an error it is printed here
                Console.WriteLine("ERROR: show company");
            }
            finally
            {
                c.Close();      //Closes the connection to the DB
            }
            return virtdb;              //It returns the virtual DB with all the information asked inside

        }
        //Shearches the information of all the companies of the provided type
        public DataSet searchCompanies(String ty)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString(); //String where it's stored the instructions for the connecton for the DB
            SqlConnection c = new SqlConnection(s); //The connection is effectuated
            DataSet virtdb = new DataSet();         //Created the DataSet that is going to be returned with the information asked

            try
            {                   //The select in SQL language that is processed in the DB which will return all the rows from the table "Flight"
                SqlDataAdapter da = new SqlDataAdapter("Select * from Company where Type LIKE '%" + ty + "%'", c); //select statement filter by type
                da.Fill(virtdb, "company");      //It introduces the information returned from the select into this virtual DB 

            }
            catch (Exception ex)
            {
                ex.ToString();      //In case of an error it is printed here
                Console.WriteLine("ERROR: show company");
            }
            finally
            {
                c.Close();      //Closes the connection to the DB
            }
            return virtdb;              //It returns the virtual DB with all the information asked inside

        }
        //Shows the information of the company given ts id
        public DataSet searchCompanyID(string idC)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString(); //String where it's stored the instructions for the connecton for the DB
            SqlConnection c = new SqlConnection(s); //The connection is effectuated
            DataSet virtdb = new DataSet();         //Created the DataSet that is going to be returned with the information asked

            try
            {                   //The select in SQL language that is processed in the DB which will return all the rows from the table "Flight"
                SqlDataAdapter da = new SqlDataAdapter("Select * from Company where ID = '" + idC + "'", c);
                da.Fill(virtdb, "company");      //It introduces the information returned from the select into this virtual DB 

            }
            catch (Exception ex)
            {
                ex.ToString();      //In case of an error it is printed here
                Console.WriteLine("ERROR: show company");
            }
            finally
            {
                c.Close();      //Closes the connection to the DB
            }
            return virtdb;              //It returns the virtual DB with all the information asked inside

        }
        //Adds a new company to the DB
        public void addCompany(CompanyEN com)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString(); //String where it's stored the instructions for the connecton for the DB
            SqlConnection c = new SqlConnection(s); //The connection is effectuated
            DataSet virtdb = new DataSet();         //Created the DataSet that is going to be returned with the information asked
            try
            {                   //The select in SQL language that is processed in the DB which will return all the rows from the table "Flight"
                SqlDataAdapter da = new SqlDataAdapter();   //  **  Will be implemented soon  **  //
                da.Fill(virtdb, "company");         //It introduces the information returned from the select into this virtual DB
                DataTable dt = new DataTable();     //Creates a table
                dt = virtdb.Tables["company"];      //Fills it with the select
                DataRow newRow = dt.NewRow(); //insert new values in a new row
                newRow[0] = com.Id;
                newRow[1] = com.name;
                newRow[2] = com.type;
                newRow[3] = com.phone;
                newRow[4] = com.email;
                newRow[5] = com.country;
                newRow[5] = com.website;
                newRow[5] = com.description;
                dt.Rows.Add(newRow);
                SqlCommandBuilder cbuilder = new SqlCommandBuilder(da); //Elaborates the SQL command needed to make the changes
                da.Update(virtdb, "company");        //Updates the DB with the new information added
            }
            catch (Exception ex)
            {
                ex.ToString();      //In case of an error it is printed here
                Console.WriteLine("ERROR: Add company");
            }
            finally
            {
                c.Close();      //Closes the connection to the DB
            }
        }
        //Deletes a company from the DB provided its id
        public DataSet deleteCompany(CompanyEN com, int i) // It will delete the index passed in the view
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString(); //String where it's stored the instructions for the connecton for the DB
            SqlConnection c = new SqlConnection(s); //The connection is effectuated
            DataSet virtdb = new DataSet();         //Created the DataSet that is going to be returned with the information asked
            try
            {                   //The select in SQL language that is processed in the DB which will return all the rows from the table "Flight"
                SqlDataAdapter da = new SqlDataAdapter();   //  **  Will be implemented soon  **  //
                da.Fill(virtdb, "company");         //It introduces the information returned from the select into this virtual DB
                DataTable t = new DataTable();      //Creates a tble
                t = virtdb.Tables["company"];       //Fils it with the select

                t.Rows[i].Delete(); //delete row

                SqlCommandBuilder cbuilder = new SqlCommandBuilder(da); //Elaborates the SQL command needed to make the changes
                da.Update(virtdb, "company");        //Updates the DB with the new information added
            }
            catch (Exception ex)
            {
                ex.ToString();      //In case of an error it is printed here
                Console.WriteLine("ERROR: Delete company");
            }
            finally
            {
                c.Close();      //Closes the connection to the DB
            }
            return virtdb;              //It returns the virtual DB with all the information asked inside
        }
        //Updates the informacion of a company given its id
        public DataSet updateCompany(CompanyEN com, int i)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString(); //String where it's stored the instructions for the connecton for the DB
            SqlConnection c = new SqlConnection(s); //The connection is effectuated
            DataSet virtdb = new DataSet();         //Created the DataSet that is going to be returned with the information asked
            try
            {                   //The select in SQL language that is processed in the DB which will return all the rows from the table "Flight"
                SqlDataAdapter da = new SqlDataAdapter();       //  **  Will be implemented soon  **  //
                da.Fill(virtdb, "company");         //It introduces the information returned from the select into this virtual DB
                DataTable t = new DataTable();      //Creates a table
                t = virtdb.Tables["company"];       //Fills it with the select

                t.Rows[i]["ID"] = com.Id;   //update rows

                t.Rows[i]["ID"] = com.Id;
                t.Rows[i]["Name"] = com.name;
                t.Rows[i]["Type"] = com.type;
                t.Rows[i]["Phone"] = com.phone;
                t.Rows[i]["Email"] = com.email;
                t.Rows[i]["Country"] = com.country;
                t.Rows[i]["Website"] = com.website;
                t.Rows[i]["Country"] = com.country;
                t.Rows[i]["Description"] = com.description;


                SqlCommandBuilder cbuilder = new SqlCommandBuilder(da); //Elaborates the SQL command needed to make the changes
                da.Update(virtdb, "company");        //Updates the DB with the new information added
            }
            catch (Exception ex)
            {
                ex.ToString();      //In case of an error it is printed here
                Console.WriteLine("ERROR: Delete company");
            }
            finally
            {
                c.Close();      //Closes the connection to the DB
            }
            return virtdb;              //It returns the virtual DB with all the information asked inside
        }
    }
}