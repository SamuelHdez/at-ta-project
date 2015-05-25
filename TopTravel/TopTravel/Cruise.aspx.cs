using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary1;

namespace TopTravel
{
    public partial class Cruise : Page
    {
        CruiseEN cr = new CruiseEN(); //cruise entity
        CompanyEN c = new CompanyEN(); //company entity
        ExtrasEN x = new ExtrasEN(); //extras entity
        DataSet d = new DataSet(); //dataset
        DataSet count = new DataSet();
        OrderEN O = new OrderEN(); //order entity

        protected void Page_Load(object sender, EventArgs e) //when page loads
        {
            if (!Page.IsPostBack)
            {
                d = cr.showAllCruises(); //list of the cruises
                GridView1.DataSource = d;
                GridView1.DataBind();
                ButtonLogin.Visible = false; //change buttons visibility
                ButtonBuy.Visible = false;
            }
        }

        protected void send(object sender, EventArgs e) //send button
        {
            d = cr.searchAllCruises(region.Text, dep.Text); //filter by region and city
            GridView1.DataSource = d;
            GridView1.DataBind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e) //when the page index changes
        {
            this.GridView1.PageIndex = e.NewPageIndex;
            d = cr.showAllCruises();
            GridView1.DataSource = d;
            this.GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e) //when the selected index changes
        {
            if (Session["login"] != null) //when the user is logged
            {
                ButtonLogin.Visible = false; //change the visibiliyy of the buttons
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
            d = cr.searchIDCruises(GridView1.SelectedRow.Cells[5].Text);

            //show diferent info in grids
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
            CityText.Visible = false;
            RegionText.Visible = false;
            SendButton.Visible = false;
            dep.Visible = false;
            region.Visible = false;
        }

        protected void SendButtonLogin(object sender, EventArgs e) //login button
        {
            Response.Redirect("/Login.aspx"); //redirect
        }

        protected void SendButtonBuy(object sender, EventArgs e) //send button
        {
            int adults = int.Parse(Adults.Text);
            int children = int.Parse(Children.Text);
            int price = int.Parse(GridView2.Rows[0].Cells[5].Text);
            count = O.countOrders(); //calculte the id

            O.id = Convert.ToInt32(count.Tables[0].Rows[0][0]);
            O.product = int.Parse(GridView2.Rows[0].Cells[4].Text);
            O.productName = "Cruise";
            O.price = price;
            O.userN = Session["Login"].ToString();
            O.adults = adults;
            O.children = children;
            O.buy = 0;
            O.totalPrice = price * adults + price * children * 80 / 100; //calculate the price
            d = O.add_Order(); //add to the shopping cart

            Response.Redirect("Order.aspx");
        }
    }
}