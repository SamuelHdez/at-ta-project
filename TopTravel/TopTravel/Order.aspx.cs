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
            if (User.Identity.IsAuthenticated)
            {
                d = o.searchOrders(User.Identity.Name);
                GridView1.DataSource = d;
                GridView1.DataBind();
            }
            else
            {
                Response.Redirect("/Account/Login.aspx");
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            d = o.delete_Order(e.RowIndex);
            d = o.searchOrders(User.Identity.Name);
            GridView1.DataSource = d;
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            o.id = int.Parse(GridView1.SelectedRow.Cells[1].Text);
            o.product = int.Parse(GridView1.SelectedRow.Cells[4].Text);
            o.productName = GridView1.SelectedRow.Cells[5].Text;
            o.price = int.Parse(GridView1.SelectedRow.Cells[8].Text);
            o.userN = User.Identity.Name;
            o.adults = int.Parse(GridView1.SelectedRow.Cells[6].Text);
            o.children = int.Parse(GridView1.SelectedRow.Cells[7].Text);
            o.buy = 1;
            o.totalPrice = int.Parse(GridView1.SelectedRow.Cells[9].Text);

            d = o.update_Order(GridView1.SelectedIndex);
            GridView1.DataSource = d;
            GridView1.DataBind();

            Response.Redirect("Order.aspx");
        }
    }
}