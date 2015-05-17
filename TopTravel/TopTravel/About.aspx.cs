using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;

namespace TopTravel
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
               
        }

        protected void Button1_click(object sender, EventArgs e)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            SqlConnection c = new SqlConnection(s);

            SqlDataAdapter sda = new SqlDataAdapter("Select count(*) FROM Client WHERE Id = '" + TextBox1.Text + "' AND password = '" + TextBox2.Text + "'", c);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows[0][0].ToString() == "1")
            {
                Session["USER_ID"] = TextBox1.Text;
                Response.Redirect("Default.aspx");
            }
            else
            {
            }

        }

    }
}