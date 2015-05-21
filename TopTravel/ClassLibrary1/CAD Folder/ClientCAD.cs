﻿using System;
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
            DataSet virtdb = new DataSet();
            SqlConnection c = new SqlConnection(s);

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from Client", c); //The select in SQL language that is processed in the DB which will return all the rows from the table 
                da.Fill(virtdb, "client");

            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: show client");
            }
            finally
            {
                c.Close();
            }
            return virtdb; //It returns the virtual DB with all the information needed inside

        }

        public DataSet searchClients(String ID, String pass)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString(); //String where it's stored the instructions for the connecton for the DB
            DataSet virtdb = new DataSet();
            SqlConnection c = new SqlConnection(s);

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select count(*) from Client where dni = '" + ID + "' and password = '" + pass + "'", c); //select method filter by dni and pass
                da.Fill(virtdb, "client");

            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: show client");
            }
            finally
            {
                c.Close();
            }
            return virtdb; //It returns the virtual DB with all the information needed inside
        }

        public DataSet showClientInfo(String ID)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString(); //String where it's stored the instructions for the connecton for the DB
            DataSet virtdb = new DataSet();
            SqlConnection c = new SqlConnection(s);

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * from Client where dni = '" + ID + "'", c); //select method filter by dni
                da.Fill(virtdb, "client");

            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: show client");
            }
            finally
            {
                c.Close();
            }
            return virtdb; //It returns the virtual DB with all the information needed inside
        }

        public DataSet addClient(ClientEN CL)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString(); //String where it's stored the instructions for the connecton for the DB
            SqlConnection c = new SqlConnection(s);
            DataSet virtdb = new DataSet();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from Client", c); //The select in SQL language that is processed in the DB which will return all the rows from the table 
                da.Fill(virtdb, "client");
                DataTable dt = new DataTable();
                dt = virtdb.Tables["client"];
                DataRow newRow = dt.NewRow(); //insert new values in the new row
                newRow[0] = CL.Dni;
                newRow[1] = CL.Name;
                newRow[2] = CL.Surname;
                newRow[3] = CL.Phone;
                newRow[4] = CL.Address;
                newRow[5] = CL.Gender;
                newRow[6] = CL.CreditCard;
                newRow[7] = CL.Admin;
                newRow[8] = CL.Password;
                newRow[9] = CL.Avatar;
                dt.Rows.Add(newRow);
                SqlCommandBuilder cbuilder = new SqlCommandBuilder(da);
                da.Update(virtdb, "client");
            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: Add client");
            }
            finally
            {
                c.Close();
            }

            return virtdb; //It returns the virtual DB with all the information needed inside
        }


        public DataSet deleteClient(ClientEN CL, int i) // It will delete the index passed in the view
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            DataSet virtdb = new DataSet();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from Client", c); //The select in SQL language that is processed in the DB which will return all the rows from the table 
                da.Fill(virtdb, "client");
                DataTable t = new DataTable();
                t = virtdb.Tables["client"];

                t.Rows[i].Delete(); //delete row

                SqlCommandBuilder cbuilder = new SqlCommandBuilder(da);
                da.Update(virtdb, "client");
            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: Delete client");
            }
            finally
            {
                c.Close();
            }
            return virtdb; //It returns the virtual DB with all the information needed inside
        }

        public void updateClient2(ClientEN b, string ID, String pass)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString(); //String where it's stored the instructions for the connecton for the DB
            SqlConnection c = new SqlConnection(s);
            try
            {
                c.Open(); //update row, connected method
                SqlCommand com = new SqlCommand("Update Client Set name = '" + b.Name + "', surname ='" +b.Surname + "', phone = '" + b.Phone + "', address = '" + b.Address + "', creditCard = '" +b.CreditCard + "', admin = '" + 0 + "' Where dni = '" + ID + "' and password = '" + b.Password + "'", c);

                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: Update Client");
            }
            finally
            {
                c.Close();
            }
        }

        public DataSet updateClient(ClientEN CL, int i)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString(); //String where it's stored the instructions for the connecton for the DB
            SqlConnection c = new SqlConnection(s);
            DataSet virtdb = new DataSet();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from Client'", c); //The select in SQL language that is processed in the DB which will return all the rows from the table 
                da.Fill(virtdb, "client");
                DataTable t = new DataTable();
                t = virtdb.Tables["client"];

                t.Rows[i]["dni"] = CL.Dni;                  //update rows
                t.Rows[i]["name"] = CL.Name;
                t.Rows[i]["surname"] = CL.Surname;
                t.Rows[i]["phone"] = CL.Phone;
                t.Rows[i]["address"] = CL.Address;
                t.Rows[i]["gender"] = CL.Gender;
                t.Rows[i]["creditCard"] = CL.CreditCard;
                t.Rows[i]["admin"] = CL.Admin;
                t.Rows[i]["password"] = CL.Password;
                t.Rows[i]["avatar"] = CL.Avatar;


                SqlCommandBuilder cbuilder = new SqlCommandBuilder(da);
                da.Update(virtdb, "client");
            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: Delete client");
            }
            finally
            {
                c.Close();
            }
            return virtdb; //It returns the virtual DB with all the information needed inside


        }
    }
}