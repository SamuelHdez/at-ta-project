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
    public partial class Flight : Page
    {
        FlightEN F = new FlightEN();
        CompanyEN c = new CompanyEN();
        ExtrasEN x = new ExtrasEN();
        DataSet d = new DataSet();
        DataSet count = new DataSet();
        OrderEN O = new OrderEN();
        
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                d = F.showAllFlights();
                GridView1.DataSource = d;
                GridView1.DataBind();

            }
        }

        protected void send(object sender, EventArgs e)
        {
            d = F.searchAllFlights(from.Text, to.Text);
            GridView1.DataSource = d;
            GridView1.DataBind();

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridView1.PageIndex = e.NewPageIndex;
            //LLenarDatosConsejera();
            d = F.showAllFlights();
            GridView1.DataSource = d;
            this.GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            d = F.searchIDFlights(GridView1.SelectedRow.Cells[6].Text);
           
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

            LoginView1.Visible =true;
            Label10.Visible = true;
            Label11.Visible = true;
        }

        protected void SendButtonLogin(object sender, EventArgs e)
        {
            Response.Redirect("/Account/Login.aspx");
        }

        protected void SendButtonBuy(object sender, EventArgs e)
        {
            int adults = int.Parse(Adults.Text);
            int children = int.Parse(Children.Text);
            int price = int.Parse(GridView2.Rows[0].Cells[6].Text);
            count = O.countOrders();

            O.id = Convert.ToInt32(count.Tables[0].Rows[0][0]);
            O.product = int.Parse(GridView2.Rows[0].Cells[5].Text);
            O.productName = "Flight";
            O.price = price;
            O.userN = User.Identity.Name;
            O.adults = adults;
            O.children = children;
            O.buy = 0;
            O.totalPrice = price * adults + price * children * 80 / 100;
            d = O.add_Order();

            Response.Redirect("Order.aspx");
        }

    }
}