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

namespace TopTravel
{
    public partial class CarRental : Page
    {
        CarRentalEN car = new CarRentalEN();
        CompanyEN c = new CompanyEN();
        ExtrasEN x = new ExtrasEN();
        OrderEN O = new OrderEN();
        DataSet d = new DataSet();
        DataSet count = new DataSet();



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                d = car.showAllCarRental();
                GridView1.DataSource = d;
                GridView1.DataBind();
                ButtonLogin.Visible = false;
                ButtonBuy.Visible = false;

            }
        }

        protected void send(object sender, EventArgs e)
        {
            d = car.searchAllCarRental(from.Text, brandcar.Text);
            GridView1.DataSource = d;
            GridView1.DataBind();

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridView1.PageIndex = e.NewPageIndex;
            //LLenarDatosConsejera();
            d = car.showAllCarRental();
            GridView1.DataSource = d;
            this.GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Session["login"] != null)
            {
                ButtonLogin.Visible = false;
                ButtonBuy.Visible = true;
            }
            else
            {
                ButtonLogin.Visible = true;
                ButtonBuy.Visible = false;
            }
            d = car.searchIDCarRental(GridView1.SelectedRow.Cells[6].Text);

            GridView2.DataSource = d;
            GridView2.DataBind();

            GridView3.DataSource = d;
            GridView3.DataBind();

            d = c.searchCompanyID(GridView1.SelectedRow.Cells[4].Text);
            GridView4.DataSource = d;
            GridView4.DataBind();

            d = x.searchExtrasID(GridView1.SelectedRow.Cells[5].Text);
            GridView5.DataSource = d;
            GridView5.DataBind();

            Label10.Visible = true;
            Label11.Visible = true;
        }

        protected void SendButtonLogin(object sender, EventArgs e)
        {
            Response.Redirect("/Login.aspx");
        }

        protected void SendButtonBuy(object sender, EventArgs e)
        {
           // int rowIndex = Convert.ToInt32(e.CommandArgument);
            count = O.countOrders();
            O.id = Convert.ToInt32(count.Tables[0].Rows[0][0]);
            O.product = int.Parse(GridView2.Rows[0].Cells[4].Text);
            O.productName = "Car Rental";
            O.price = int.Parse(GridView2.Rows[0].Cells[5].Text);
            O.userN = Session["Login"].ToString();
            O.adults = 1;
            O.children = 0;
            O.buy = 0;
            O.totalPrice = int.Parse(GridView2.Rows[0].Cells[5].Text);
            d = O.add_Order();

            Response.Redirect("Order.aspx");
        }

    }
}