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
        //Create the entities we are going to use
        CarRentalEN car = new CarRentalEN(); //car rental entity
        CompanyEN c = new CompanyEN(); //company entity
        ExtrasEN x = new ExtrasEN(); //extras entity
        OrderEN O = new OrderEN(); // order entity
        DataSet d = new DataSet();
        DataSet count = new DataSet();



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                d = car.showAllCarRental(); //store in the dataset the info of the car rentals
                GridView1.DataSource = d; //store it in the grid
                GridView1.DataBind();
                ButtonLogin.Visible = false; //change visibility of a button
                ButtonBuy.Visible = false;

            }
        }

        protected void send(object sender, EventArgs e) //when click on the send button
        {
            d = car.searchAllCarRental(from.Text, brandcar.Text); //search cars by city and brand
            GridView1.DataSource = d;
            GridView1.DataBind();

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e) //when change of page
        {
            this.GridView1.PageIndex = e.NewPageIndex;
            //LLenarDatosConsejera();
            d = car.showAllCarRental();
            GridView1.DataSource = d;
            this.GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e) //when a row is selected
        {
            if (Session["login"] != null) //if the user is login
            {
                ButtonLogin.Visible = false;
                ButtonBuy.Visible = true; //button buy visible
            }
            else
            {
                ButtonLogin.Visible = true; 
                ButtonBuy.Visible = false;
            }
            d = car.searchIDCarRental(GridView1.SelectedRow.Cells[6].Text);

            //show info in different grids
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

        protected void SendButtonLogin(object sender, EventArgs e) //login button
        {
            Response.Redirect("/Login.aspx");
        }

        protected void SendButtonBuy(object sender, EventArgs e) //buy button
        {
           // int rowIndex = Convert.ToInt32(e.CommandArgument);
            count = O.countOrders(); //calculate the id
            O.id = Convert.ToInt32(count.Tables[0].Rows[0][0]);
            O.product = int.Parse(GridView2.Rows[0].Cells[4].Text);
            O.productName = "Car Rental";
            O.price = int.Parse(GridView2.Rows[0].Cells[5].Text);
            O.userN = Session["Login"].ToString();
            O.adults = 1;
            O.children = 0;
            O.buy = 0;
            O.totalPrice = int.Parse(GridView2.Rows[0].Cells[5].Text); //calculta the price
            d = O.add_Order(); //add to the shopping cart

            Response.Redirect("Order.aspx"); // redirect
        }

    }
}