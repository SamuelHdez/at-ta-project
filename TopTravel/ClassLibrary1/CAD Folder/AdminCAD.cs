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
        //method for check that the user is an administrator
        public DataSet searchAdmin(String nameAd)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString(); //String where it's stored the instructions for the connecton for the DB
            DataSet virtdb = new DataSet(); //Created the DataSet that is going to be returned with the information asked
            SqlConnection c = new SqlConnection(s); //The connection is effectuated

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select count(*) from Admin where Id = '" + nameAd + "'", c); //select statement
                da.Fill(virtdb, "admin"); //It introduces the information returned from the select into this virtual DB 

            }
            catch (Exception ex) //exception management
            {
                ex.ToString();
                Console.WriteLine("ERROR: show admin");
            }
            finally
            {
                c.Close();  //Closes the connection to the DB
            }
            return virtdb; //return the solution
        }
    }
}
