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
        OrderEN o = new OrderEN(); //order entity
        DataSet d = new DataSet();
        DataSet d2 = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["Login"] != null) //if user is logged
                {
                    d = o.searchOrders(Session["Login"].ToString()); //shopping cart
                    GridView1.DataSource = d;
                    GridView1.DataBind();

                    d2 = o.searchHistory(Session["Login"].ToString()); //history cart
                    GridView2.DataSource = d2;
                    GridView2.DataBind();
                }
                else
                {
                    Response.Redirect("/Login.aspx"); //else redirect
                }
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e) //delete shopping cart
        {
            d = o.delete_Order(e.RowIndex); //delete row
            GridView1.DataSource = d;
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e) //when row changes
        {
            o.id = int.Parse(GridView1.SelectedRow.Cells[1].Text);

            o.buy_Order(o.id); //add to the history cart
            d = o.searchOrders(Session["Login"].ToString());
            GridView1.DataSource = d;
            GridView1.DataBind();

            d2 = o.searchHistory(Session["Login"].ToString());
            GridView2.DataSource = d2;
            GridView2.DataBind();

        }
    }
}