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
using Microsoft.AspNet.Membership.OpenAuth;

namespace TopTravel
{
    public partial class SpaceTravelAdmin : Page
    {
        SpaceTravelEN t = new SpaceTravelEN();
        AdminEN A = new AdminEN();
        DataSet d = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login"] != null)
            {
                d = A.searchAdmin(Session["login"].ToString());
                int encontrado = Convert.ToInt32(d.Tables[0].Rows[0][0]); //if there is a client, we return 1

                if (encontrado == 1)
                {
                    d = t.showAllSpaceTravels();
                    GridView1.DataSource = d;
                    GridView1.DataBind();
                }
                else
                {
                    Response.Redirect("../Default.aspx");
                }
            }
            else
            {
                Response.Redirect("../Login.aspx");
            }
        }


        protected void radioChange(object sender, EventArgs e)
        {
            if (typeAdmin.Text == "Hotel")
            {
                Response.Redirect("../AdminPanel/Hotel.aspx");
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
                
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            idS.Text = GridView1.SelectedRow.Cells[1].Text;
            depTimeS.Text = GridView1.SelectedRow.Cells[2].Text;
            arTimeS.Text = GridView1.SelectedRow.Cells[3].Text;
            depCiS.Text = GridView1.SelectedRow.Cells[4].Text;
            PrepCenterS.Text = GridView1.SelectedRow.Cells[5].Text;
            priceS.Text = GridView1.SelectedRow.Cells[6].Text;
            companyS.Text = GridView1.SelectedRow.Cells[7].Text;
            extrasS.Text = GridView1.SelectedRow.Cells[8].Text;
            imageS.Text = GridView1.SelectedRow.Cells[9].Text;
            idS.Enabled = false;
        }

        protected void GridView1_sendUpdate(object sender, EventArgs e)
        {
            t.id = int.Parse(idS.Text);
            t.DepartureDate = depTimeS.Text;
            t.ArrivalDate = arTimeS.Text;
            t.DepartureCity = depCiS.Text;
            t.preparationCenter = PrepCenterS.Text;
            t.Price = int.Parse(priceS.Text);
            t.Company = int.Parse(companyS.Text);
            t.Extras = int.Parse(extrasS.Text);
            t.Images = imageS.Text;

            d = t.update_SpaceTravels(GridView1.SelectedIndex);
            GridView1.DataSource = d;
            GridView1.DataBind();
        }

        protected void sendInsert(object sender, EventArgs e)
        {
            t.id = int.Parse(idS.Text);
            t.DepartureDate = depTimeS.Text;
            t.ArrivalDate = arTimeS.Text;
            t.DepartureCity = depCiS.Text;
            t.preparationCenter = PrepCenterS.Text;
            t.Price = int.Parse(priceS.Text);
            t.Company = int.Parse(companyS.Text);
            t.Extras = int.Parse(extrasS.Text);
            t.Images = imageS.Text;

            d = t.add_SpaceTravels();
            GridView1.DataSource = d;
            GridView1.DataBind();

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            d = t.delete_SpaceTravels(e.RowIndex);
            GridView1.DataSource = d;
            GridView1.DataBind();
        }
    }
}