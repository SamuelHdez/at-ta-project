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
    class SpaceTravelCAD
    {
        public DataSet showSpaceTravels(SpaceTravelEN SP)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            DataSet virtdb = new DataSet();
            SqlConnection c = new SqlConnection(s);

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from SpaceTravel", c);
                da.Fill(virtdb, "spaceTravel");

            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: show spaceTravel");
            }
            finally
            {
                c.Close();
            }
            return virtdb;

        }

        public DataSet searchSpaceTravels(String DP)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            DataSet virtdb = new DataSet();
            SqlConnection c = new SqlConnection(s);

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * from SpaceTravel where departureCity LIKE '%" + DP + "%'", c);
                da.Fill(virtdb, "spaceTravel");

            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: show spaceTravel");
            }
            finally
            {
                c.Close();
            }
            return virtdb;

        }

        public DataSet searchIDSpaceTravels(String IDsp)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            DataSet virtdb = new DataSet();
            SqlConnection c = new SqlConnection(s);

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * from SpaceTravel where Id = '" + IDsp + "'", c);
                da.Fill(virtdb, "spaceTravel");

            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: show spaceTravel");
            }
            finally
            {
                c.Close();
            }
            return virtdb;

        }


        public DataSet addSpaceTravel(SpaceTravelEN SP)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            DataSet virtdb = new DataSet();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from SpaceTravel", c);
                da.Fill(virtdb, "spaceTravel");
                DataTable dt = new DataTable();
                dt = virtdb.Tables["spaceTravel"];
                DataRow newRow = dt.NewRow();
                newRow[0] = SP.id;
                newRow[1] = SP.DepartureDate;
                newRow[2] = SP.ArrivalDate;
                newRow[3] = SP.DepartureCity;
                newRow[4] = SP.preparationCenter;
                newRow[5] = SP.Price;
                newRow[6] = SP.Company;
                newRow[7] = SP.Extras;
                newRow[8] = SP.Images;
                dt.Rows.Add(newRow);
                SqlCommandBuilder cbuilder = new SqlCommandBuilder(da);
                da.Update(virtdb, "spaceTravel");
            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: Add spaceTravel");
            }
            finally
            {
                c.Close();
            }

            return virtdb;
        }


        public DataSet deleteSpaceTravel(SpaceTravelEN SP, int i) // It will delete the index passed in the view
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            DataSet virtdb = new DataSet();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from SpaceTravel", c);
                da.Fill(virtdb, "spaceTravel");
                DataTable t = new DataTable();
                t = virtdb.Tables["spaceTravel"];

                t.Rows[i].Delete();

                SqlCommandBuilder cbuilder = new SqlCommandBuilder(da);
                da.Update(virtdb, "spaceTravel");
            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: Delete spaceTravel");
            }
            finally
            {
                c.Close();
            }
            return virtdb;
        }

        public DataSet updateSpaceTravel(SpaceTravelEN SP, int i)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            DataSet virtdb = new DataSet();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from SpaceTravel", c);
                da.Fill(virtdb, "spaceTravel");
                DataTable t = new DataTable();
                t = virtdb.Tables["spaceTravel"];

                t.Rows[i]["Id"] = SP.id;
                t.Rows[i]["departureDate"] = SP.DepartureDate;
                t.Rows[i]["arrivalDate"] = SP.ArrivalDate;
                t.Rows[i]["departureCity"] = SP.DepartureCity;
                t.Rows[i]["Preparation Center"] = SP.preparationCenter;
                t.Rows[i]["price"] = SP.Price;
                t.Rows[i]["company"] = SP.Company;
                t.Rows[i]["extras"] = SP.Extras;
                t.Rows[i]["images"] = SP.Images;


                SqlCommandBuilder cbuilder = new SqlCommandBuilder(da);
                da.Update(virtdb, "spaceTravel");
            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: Delete spaceTravel");
            }
            finally
            {
                c.Close();
            }
            return virtdb;


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
                ex.ToString();
                Console.WriteLine("ERROR: Add SpaceTravel");
            }
            finally
            {
                c.Close();
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
                ex.ToString();
                Console.WriteLine("ERROR: Delete SpaceTravel");
            }
            finally
            {
                c.Close();
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
                ex.ToString();
                Console.WriteLine("ERROR: Update SpaceTravel");
            }
            finally
            {
                c.Close();
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
                ex.ToString();
                Console.WriteLine("ERROR: Show SpaceTravel");
            }
            finally
            {
                c.Close();
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
                ex.ToString();
                Console.WriteLine("ERROR: Search SpaceTravel");
            }
            finally
            {
                c.Close();
            }
            return a;
        } */
    }
}
