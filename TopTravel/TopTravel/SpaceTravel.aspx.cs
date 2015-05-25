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
    public partial class SpaceTravel : Page
    {
        SpaceTravelEN SP = new SpaceTravelEN(); //space travel entity
        CompanyEN c = new CompanyEN(); //company entity
        ExtrasEN x = new ExtrasEN(); //extras entity
        OrderEN O = new OrderEN();//order entity
        DataSet d = new DataSet();
        DataSet count = new DataSet();



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                d = SP.showAllSpaceTravels(); //show
                GridView1.DataSource = d;
                GridView1.DataBind();
                ButtonLogin.Visible = false; //change visibility
                ButtonBuy.Visible = false;

            }
        }

        protected void send(object sender, EventArgs e) //send button
        {
            d = SP.searchAllSpaceTravels(from.Text); //filter by city
            GridView1.DataSource = d;
            GridView1.DataBind();

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e) //when page change
        {
            this.GridView1.PageIndex = e.NewPageIndex;
            //LLenarDatosConsejera();
            d = SP.showAllSpaceTravels();
            GridView1.DataSource = d;
            this.GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e) //when row changes
        {
            if (Session["login"] != null) //if user is logged
            {
                ButtonLogin.Visible = false; //change visibily 
                ButtonBuy.Visible = true;
                Adults.Visible = true;
                LAdults.Visible = true;
                Children.Visible = true;
                LChildren.Visible = true;
            }
            else
            {
                ButtonLogin.Visible = true;
                ButtonBuy.Visible = false;
            }
            d = SP.searchIDSpaceTravels(GridView1.SelectedRow.Cells[5].Text);
            //show info in grids
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
            City.Visible = false;
            from.Visible = false;
            SendButton.Visible = false;
        }

        protected void SendButtonLogin(object sender, EventArgs e) //login button
        {
            Response.Redirect("/Login.aspx"); //redirect
        }

        protected void SendButtonBuy(object sender, EventArgs e) //buy button
        {
                int adults = int.Parse(Adults.Text);
                int children = int.Parse(Children.Text);
                int price = int.Parse(GridView2.Rows[0].Cells[5].Text);
                count = O.countOrders(); //calculate id

                O.id = Convert.ToInt32(count.Tables[0].Rows[0][0]);
                O.product = int.Parse(GridView2.Rows[0].Cells[4].Text);
                O.productName = "Space Travel";
                O.price = price;
                O.userN = Session["Login"].ToString();
                O.adults = adults;
                O.children = children;
                O.buy = 0;
                O.totalPrice = price * adults + price * children * 80 / 100; //calculate price
                d = O.add_Order(); //insert into the history

                Response.Redirect("Order.aspx"); //redirect
        }

    }
}