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
using Microsoft.AspNet.Membership.OpenAuth;

namespace TopTravel
{
    public partial class HotelAdmin : Page
    {
        HotelEN h = new HotelEN();
        AdminEN A = new AdminEN();
        DataSet d = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                d = A.searchAdmin(User.Identity.Name);
                int AdminID = Convert.ToInt32(d.Tables[0].Rows[0][0]);

                if (AdminID == 1)
                {
                    d = h.showAllHotels();
                    GridView1.DataSource = d;
                    GridView1.DataBind();
                }
                else
                {
                    Response.Redirect("../Default.aspx");
                }
            }
        }


        protected void radioChange(object sender, EventArgs e)
        {
            if (typeAdmin.Text == "Hotel")
            {

            }
            else if (typeAdmin.Text == "Flight")
            {
                Response.Redirect("../AdminPanel/Flight.aspx");
            }
            else if (typeAdmin.Text == "Cruise")
            {
                Response.Redirect("../AdminPanel/Cruise.aspx");
            }
            else if (typeAdmin.Text == "Bus")
            {
                Response.Redirect("../AdminPanel/Bus.aspx");
            }
            else if (typeAdmin.Text == "CarRental")
            {
                Response.Redirect("../AdminPanel/CarRental.aspx");
            }
            else if (typeAdmin.Text == "Train")
            {
                Response.Redirect("../AdminPanel/Train.aspx");
            }
            else if (typeAdmin.Text == "SpaceTravel")
            {
                Response.Redirect("../AdminPanel/SpaceTravel.aspx");
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            idH.Text = GridView1.SelectedRow.Cells[1].Text;
            nameH.Text = GridView1.SelectedRow.Cells[2].Text;
            cityH.Text = GridView1.SelectedRow.Cells[3].Text;
            phoneH.Text = GridView1.SelectedRow.Cells[4].Text;
            addressH.Text = GridView1.SelectedRow.Cells[5].Text;
            emailH.Text = GridView1.SelectedRow.Cells[6].Text;
            starsH.Text = GridView1.SelectedRow.Cells[7].Text;
            bedroomsH.Text = GridView1.SelectedRow.Cells[8].Text;
            priceH.Text = GridView1.SelectedRow.Cells[9].Text;
            companyH.Text = GridView1.SelectedRow.Cells[10].Text;
            extrasH.Text = GridView1.SelectedRow.Cells[11].Text;

            idH.Enabled = false;
        }

        protected void GridView1_sendUpdate(object sender, EventArgs e)
        {
            h.Id = int.Parse(idH.Text);
            h.Name = nameH.Text;
            h.City = cityH.Text;
            h.Phone = int.Parse(phoneH.Text);
            h.Address = addressH.Text;
            h.Email = emailH.Text;
            h.Stars = int.Parse(starsH.Text);
            h.Bedrooms = bedroomsH.Text;
            h.Price = int.Parse(priceH.Text);
            h.Company = int.Parse(companyH.Text);
            h.Extras = int.Parse(extrasH.Text);

            d = h.update_hotel(GridView1.SelectedIndex);
            GridView1.DataSource = d;
            GridView1.DataBind();
        }

        protected void sendInsert(object sender, EventArgs e)
        {
            HotelEN h = new HotelEN();
            h.Id = int.Parse(idH.Text);
            h.Name = nameH.Text;
            h.City = cityH.Text;
            h.Phone = int.Parse(phoneH.Text);
            h.Address = addressH.Text;
            h.Email = emailH.Text;
            h.Stars = int.Parse(starsH.Text);
            h.Bedrooms = bedroomsH.Text;
            h.Price = int.Parse(priceH.Text);
            h.Company = int.Parse(companyH.Text);
            h.Extras = int.Parse(extrasH.Text);

            d = h.add_hotel();
            GridView1.DataSource = d;
            GridView1.DataBind();
            
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridView1.PageIndex = e.NewPageIndex;
            //LLenarDatosConsejera();
            this.GridView1.DataBind();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            d = h.delete_hotel(e.RowIndex);
            GridView1.DataSource = d;
            GridView1.DataBind();
        }
    }
}