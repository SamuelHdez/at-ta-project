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
    class ProductCAD
    {
        public DataSet showProducts(ProductEN h)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            DataSet virtdb = new DataSet();
            SqlConnection c = new SqlConnection(s);

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from Product", c);
                da.Fill(virtdb, "product");

            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: show product");
            }
            finally
            {
                c.Close();
            }
            return virtdb;

        }

        public DataSet searchProducts(String ty)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            DataSet virtdb = new DataSet();
            SqlConnection c = new SqlConnection(s);

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * from Product where Id Like '%" + ty + "%'", c);
                da.Fill(virtdb, "product");

            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: show product");
            }
            finally
            {
                c.Close();
            }
            return virtdb;

        }

        public void addProduct(ProductEN h)
        {
            string s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            DataSet virtdb = new DataSet();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                da.Fill(virtdb, "product");
                DataTable t = new DataTable();
                t = virtdb.Tables["product"];
                DataRow newRow = t.NewRow();
                newRow[0] = h.Id;
                newRow[1] = h.Company;
                newRow[2] = h.Extras;

                t.Rows.Add(newRow);
                SqlCommandBuilder cbuilder = new SqlCommandBuilder(da);
                da.Update(virtdb, "product");
            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: Add product");
            }
            finally
            {
                c.Close();
            }
        }

        public DataSet deleteProduct(ProductEN h, int i) // It will delete the index passed in the view
        {
            string s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            DataSet virtdb = new DataSet();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                da.Fill(virtdb, "product");
                DataTable t = new DataTable();
                t = virtdb.Tables["product"];

                t.Rows[i].Delete();

                SqlCommandBuilder cbuilder = new SqlCommandBuilder(da);
                da.Update(virtdb, "product");
            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: Delete product");
            }
            finally
            {
                c.Close();
            }
            return virtdb;
        }

        public DataSet updateProduct(ProductEN h, int i)
        {
            string s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            DataSet virtdb = new DataSet();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                da.Fill(virtdb, "product");
                DataTable t = new DataTable();
                t = virtdb.Tables["product"];

                t.Rows[i]["Id"] = h.Id;

                t.Rows[i]["Id"] = h.Id;
                t.Rows[i]["Company"] = h.Company;
                t.Rows[i]["Extras"] = h.Extras;


                SqlCommandBuilder cbuilder = new SqlCommandBuilder(da);
                da.Update(virtdb, "product");
            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: Delete product");
            }
            finally
            {
                c.Close();
            }
            return virtdb;


        }
    }
}
        /*
        public void addProduct(ProductEN p)
        {
            string s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Insert Into Product (Id,Price,Company,Extras) VALUES ('" + p.Id + "','" + p.Price + "','" + p.Company + "','" +
                    p.Extras + "')", c);

                com.ExecuteNonQuery();
            }
            catch (Exception exc)
            {
                exc.ToString();
                Console.WriteLine("ERROR: Add Product");
            }
            finally
            {
                c.Close();
            }
        }

        public void deleteProduct(ProductEN p)
        {
            string s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Delete From Product Where Id = " + p.Id, c);
                com.ExecuteNonQuery();
            }
            catch (Exception exc)
            {
                exc.ToString();
                Console.WriteLine("ERROR: Delete Product");
            }
            finally
            {
                c.Close();
            }
        }

        public void updateProduct(ProductEN p)
        {
            string s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Update Product Set Price = '" + p.Price + "', Company = '" + p.Company + "', Extras ='" +
                    p.Extras + "' Where Id = " + p.Id, c);
                com.ExecuteNonQuery();
            }
            catch (Exception exc)
            {
                exc.ToString();
                Console.WriteLine("ERROR: Update Product");
            }
            finally
            {
                c.Close();
            }
        }

        public DataSet showProduct(ProductEN p)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            DataSet virtdb = new DataSet();
            SqlConnection c = new SqlConnection(s);

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from Product", c);
                da.Fill(virtdb, "product");

            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine("ERROR: show product");
            }
            finally
            {
                c.Close();
            }
            return virtdb;

        }

        public ArrayList searchProduct(ProductEN p)
        {
            ArrayList a = new ArrayList();
            string s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            SqlConnection c = new SqlConnection(s);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Select * from Product where Id = " + p.Id, c);
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
                Console.WriteLine("ERROR: Show Product");
            }
            finally
            {
                c.Close();
            }
            return a;
        }
    }
}
*/