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
    public partial class CarRentalAdmin : Page
    {
        CarRentalEN Cr = new CarRentalEN();
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
                    d = Cr.showAllCarRental();
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
            idCr.Text = GridView1.SelectedRow.Cells[1].Text;
            cCr.Text = GridView1.SelectedRow.Cells[2].Text;
            brandCr.Text = GridView1.SelectedRow.Cells[3].Text;
            modelCr.Text = GridView1.SelectedRow.Cells[4].Text;
            daysCr.Text = GridView1.SelectedRow.Cells[5].Text;
            priceCr.Text = GridView1.SelectedRow.Cells[6].Text;
            companyCr.Text = GridView1.SelectedRow.Cells[7].Text;
            extrasCr.Text = GridView1.SelectedRow.Cells[8].Text;
            imageCr.Text = GridView1.SelectedRow.Cells[9].Text;
            idCr.Enabled = false;
        }

        protected void GridView1_sendUpdate(object sender, EventArgs e)
        {
            Cr.id = int.Parse(idCr.Text);
            Cr.city = cCr.Text;
            Cr.brand = brandCr.Text;
            Cr.model = modelCr.Text;
            Cr.days = int.Parse(daysCr.Text);
            Cr.Price = int.Parse(priceCr.Text);
            Cr.Company = int.Parse(companyCr.Text);
            Cr.Extras = int.Parse(extrasCr.Text);
            Cr.Image = imageCr.Text;

            d = Cr.update_CarRental(GridView1.SelectedIndex);
            GridView1.DataSource = d;
            GridView1.DataBind();
        }

        protected void sendInsert(object sender, EventArgs e)
        {
            Cr.id = int.Parse(idCr.Text);
            Cr.city = cCr.Text;
            Cr.brand = brandCr.Text;
            Cr.model = modelCr.Text;
            Cr.days = int.Parse(daysCr.Text);
            Cr.Price = int.Parse(priceCr.Text);
            Cr.Company = int.Parse(companyCr.Text);
            Cr.Extras = int.Parse(extrasCr.Text);
            Cr.Image = imageCr.Text;

            d = Cr.add_CarRental();
            GridView1.DataSource = d;
            GridView1.DataBind();

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            d = Cr.delete_CarRental(e.RowIndex);
            GridView1.DataSource = d;
            GridView1.DataBind();
        }
    }
}