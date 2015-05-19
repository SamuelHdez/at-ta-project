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
        BusEN B = new BusEN();
        CompanyEN c = new CompanyEN();
        ExtrasEN x = new ExtrasEN();
        DataSet d = new DataSet();



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                d = B.showAllBuses();
                GridView1.DataSource = d;
                GridView1.DataBind();

            }
        }

        protected void send(object sender, EventArgs e)
        {
            d = B.searchAllBuses(from.Text, to.Text);
            GridView1.DataSource = d;
            GridView1.DataBind();

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridView1.PageIndex = e.NewPageIndex;
            //LLenarDatosConsejera();
            d = B.showAllBuses();
            GridView1.DataSource = d;
            this.GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            d = B.searchIDBuses(GridView1.SelectedRow.Cells[5].Text);

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

            LoginView1.Visible = true;
            Label10.Visible = true;
            Label11.Visible = true;
        }

        protected void SendButtonLogin(object sender, EventArgs e)
        {
            Response.Redirect("/Account/Login.aspx");
        }

        protected void SendButtonBuy(object sender, EventArgs e)
        {
        }

    }
}