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
            if (Session["login"] != null) //not user logged = redirect to login page
            {
                d = A.searchAdmin(Session["login"].ToString());
                int encontrado = Convert.ToInt32(d.Tables[0].Rows[0][0]); //if there is a admin, we return 1

                if (encontrado == 1) //admin has access, client will be redirect to the default page
                {
                    d = Cr.showAllCarRental();
                    GridView1.DataSource = d;
                    GridView1.DataBind();
                    EditButton.Visible = false;
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


        protected void radioChange(object sender, EventArgs e) //change the category of the admin panel
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

            EditButton.Visible = true; //change visibility of the buttons
            InsertButton.Visible = false;
        }

        protected void GridView1_sendUpdate(object sender, EventArgs e) //update a product
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
            Response.Redirect("CarRental.aspx");
        }

        protected void sendInsert(object sender, EventArgs e) //insert a new product
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

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e) //delete a product
        {
            d = Cr.delete_CarRental(e.RowIndex);
            GridView1.DataSource = d;
            GridView1.DataBind();
        }
    }
}