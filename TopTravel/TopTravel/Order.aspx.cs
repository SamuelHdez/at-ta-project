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
using ClassLibrary1;
using Microsoft.AspNet.Membership.OpenAuth;

namespace TopTravel
{
    public partial class Order : Page
    {
        OrderEN o = new OrderEN();
        DataSet d = new DataSet();
        DataSet d2 = new DataSet();
        DataSet d3 = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Login"] != null)
            {
                d = o.searchOrders(Session["Login"].ToString());
                GridView1.DataSource = d;
                GridView1.DataBind();

               // d = o.searchHistory(Session["Login"].ToString());
               // GridView2.DataSource = d;
               // GridView2.DataBind();
            }
            else
            {
                Response.Redirect("/Login.aspx");
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            d = o.delete_Order(e.RowIndex);
            GridView1.DataSource = d;
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            o.buy = 1;
            d = o.buy_Order(GridView1.SelectedIndex);

            Response.Redirect("Order.aspx");
        }
    }
}