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
    public partial class Bus : Page
    {
        //Create the entities we are going to use
        BusEN B = new BusEN(); //bus entity
        CompanyEN c = new CompanyEN(); //company entity
        ExtrasEN x = new ExtrasEN(); //extras entity
        DataSet count = new DataSet();
        OrderEN O = new OrderEN(); //order entity
        DataSet d = new DataSet();



        protected void Page_Load(object sender, EventArgs e) 
        {
            if (!Page.IsPostBack)
            {
                d = B.showAllBuses(); //store in the dataset the info of the buses
                GridView1.DataSource = d; //store it in grid
                GridView1.DataBind();
                ButtonLogin.Visible = false; //change visibility of a button
                ButtonBuy.Visible = false;

            }
        }

        protected void send(object sender, EventArgs e) //when click on the button
        {
            d = B.searchAllBuses(from.Text, to.Text); //search the buses by origin and destination
            GridView1.DataSource = d;
            GridView1.DataBind();

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e) //when change of page
        {
            this.GridView1.PageIndex = e.NewPageIndex;
            //LLenarDatosConsejera();
            d = B.showAllBuses();
            GridView1.DataSource = d;
            this.GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e) //when select a row
        {
            if (Session["login"] != null) //if the user is login
            {
                ButtonLogin.Visible = false;
                ButtonBuy.Visible = true; //button buy visible
                Adults.Visible = true;
                LAdults.Visible = true;
                Children.Visible = true;
                LChildren.Visible = true;
            }
            else
            {
                ButtonLogin.Visible = true; //botton login visible
                ButtonBuy.Visible = false;
            }
            d = B.searchIDBuses(GridView1.SelectedRow.Cells[5].Text);

            //show info in different grids

            GridView2.DataSource = d;
            GridView2.DataBind();

            GridView3.DataSource = d;
            GridView3.DataBind();

            d = c.searchCompanyID(GridView1.SelectedRow.Cells[3].Text);
            GridView4.DataSource = d;
            GridView4.DataBind();

            d = x.searchExtrasID(GridView1.SelectedRow.Cells[4].Text);
            GridView5.DataSource = d;
            GridView5.DataBind();

            Label10.Visible = true;
            Label11.Visible = true;

            GridView1.Visible = false;
            FromText.Visible = false;
            from.Visible = false;
            to.Visible = false;
            toText.Visible = false;
            SendButton.Visible = false;
        }

        protected void SendButtonLogin(object sender, EventArgs e) //login button
        {
            Response.Redirect("/Login.aspx");
        }

        protected void SendButtonBuy(object sender, EventArgs e) //buy button
        {
            int adults = int.Parse(Adults.Text);
            int children = int.Parse(Children.Text);
            int price = int.Parse(GridView2.Rows[0].Cells[5].Text);
            count = O.countOrders(); //for calculate an ID

            O.id = Convert.ToInt32(count.Tables[0].Rows[0][0]);
            O.product = int.Parse(GridView2.Rows[0].Cells[4].Text);
            O.productName = "Bus";
            O.price = price;
            O.userN = Session["Login"].ToString();
            O.adults = adults;
            O.children = children;
            O.buy = 0;
            O.totalPrice = price * adults + price * children * 80 / 100; //calculate the price
            d = O.add_Order(); //introduce the data in the shopping cart

            Response.Redirect("Order.aspx"); //redirect
        }

    }
}