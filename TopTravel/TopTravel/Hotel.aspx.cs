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
       
    public partial class Hotel : Page
    {
        HotelEN h = new HotelEN(); //hotel entity
        CompanyEN c = new CompanyEN(); //company entity
        ExtrasEN x = new ExtrasEN(); //extra entity
        DataSet count = new DataSet();
        OrderEN O = new OrderEN(); //order entity
        DataSet d = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
          if (!Page.IsPostBack)
            {
                d = h.showAllHotels(); //list of hotels
                GridView1.DataSource = d;
                GridView1.DataBind();
                ButtonLogin.Visible = false; //change visibilities
                ButtonBuy.Visible = false;
                
            }
        }

        protected void send(object sender, EventArgs e) //buttond send
        {

            d = h.searchAllHotels(Place2.Text); //filter by city
            GridView1.DataSource = d;
            GridView1.DataBind();
           
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e) //when the page changes
        {
            this.GridView1.PageIndex = e.NewPageIndex;
            d = h.showAllHotels();
            GridView1.DataSource = d;
            this.GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e) //when the row changes
        {
            if (Session["login"] != null) //check if user is logged
            {
                ButtonLogin.Visible = false;
                ButtonBuy.Visible = true;
            }
            else
            {
                ButtonLogin.Visible = true;
                ButtonBuy.Visible = false;
            }
            d = h.searchIDHotels(GridView1.SelectedRow.Cells[6].Text);
            //show info in grids
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
            Response.Redirect("/Login.aspx"); //redirect
        }

        protected void SendButtonBuy(object sender, EventArgs e) //buy button
        {
            int adults = int.Parse(Adults.Text);
            int children = int.Parse(Children.Text);
            int nights = int.Parse(Nights.Text);
            int price = int.Parse(GridView2.Rows[0].Cells[8].Text);
            count = O.countOrders(); //calculte id

            O.id = Convert.ToInt32(count.Tables[0].Rows[0][0]);
            O.product = int.Parse(GridView2.Rows[0].Cells[7].Text);
            O.productName = "Hotel";
            O.price = price;
            O.userN = Session["Login"].ToString();
            O.adults = adults;
            O.children = children;
            O.buy = 0;
            O.totalPrice = nights * (price * adults + price * children * 80 / 100); //calculate price
            d = O.add_Order(); //insert into the cart

            Response.Redirect("Order.aspx");
        }
    }
}