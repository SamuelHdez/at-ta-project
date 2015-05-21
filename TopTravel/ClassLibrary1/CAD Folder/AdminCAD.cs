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
    //This class represents the entity of a admin with its methods and atributes listed below
    class AdminCAD
    {
        //Method used to check wether the user is administrator
        public DataSet searchAdmin(String nameAd)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString(); //String where it's stored the instructions for the connecton for the DB
            DataSet virtdb = new DataSet(); //Created the DataSet that is going to be returned with the information asked
            SqlConnection c = new SqlConnection(s); //The connection is effectuated

            try
            {                   //The select in SQL language that is processed in the DB which will return all the rows from the table "Admin"
                SqlDataAdapter da = new SqlDataAdapter("select count(*) from Admin where Id = '" + nameAd + "'", c);
                da.Fill(virtdb, "admin"); //It introduces the information returned from the select into this virtual DB 

            }
            catch (Exception ex) //exception management
            {
                ex.ToString();      //In case of an error it is printed here
                Console.WriteLine("ERROR: show admin");
            }
            finally
            {
                c.Close();  //Closes the connection to the DB
            }
            return virtdb;              //It returns the virtual DB with all the information asked inside
        }
    }
}
