﻿using System;
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
        FlightEN F = new FlightEN(); //flight entity
        CompanyEN c = new CompanyEN(); //company entity
        ExtrasEN x = new ExtrasEN(); //extras entity
        DataSet d = new DataSet(); //dataset
        DataSet count = new DataSet();
        OrderEN O = new OrderEN(); //order entity
        
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                d = F.showAllFlights();
                GridView1.DataSource = d;
                GridView1.DataBind();
                ButtonLogin.Visible = false;
                ButtonBuy.Visible = false;

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

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e) //when selected row changes
        {
            if (Session["login"] != null) //if the user is logged
            {
                ButtonLogin.Visible = false; //change visibilities
                ButtonBuy.Visible = true;
            }
            else
            {
                ButtonLogin.Visible = true;
                ButtonBuy.Visible = false;
            }

            d = F.searchIDFlights(GridView1.SelectedRow.Cells[6].Text);
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
            Response.Redirect("/Login.aspx"); //redirect to loggin
        }

        protected void SendButtonBuy(object sender, EventArgs e) //buy button
        {
            int adults = int.Parse(Adults.Text);
            int children = int.Parse(Children.Text);
            int price = int.Parse(GridView2.Rows[0].Cells[6].Text);
            count = O.countOrders(); //calculate id

            O.id = Convert.ToInt32(count.Tables[0].Rows[0][0]); 
            O.product = int.Parse(GridView2.Rows[0].Cells[5].Text);
            O.productName = "Flight";
            O.price = price;
            O.userN = Session["Login"].ToString();
            O.adults = adults;
            O.children = children;
            O.buy = 0;
            O.totalPrice = price * adults + price * children * 80 / 100; //calculte price
            d = O.add_Order(); //insert data into the shopping cart

            Response.Redirect("Order.aspx");
        }

    }
}