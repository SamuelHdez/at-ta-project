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
    public partial class CruiseAdmin : Page
    {
        CruiseEN c = new CruiseEN();
        AdminEN A = new AdminEN();
        DataSet d = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login"] != null) //not user logged = redirect to login page
            {
                d = A.searchAdmin(Session["login"].ToString());
                int encontrado = Convert.ToInt32(d.Tables[0].Rows[0][0]); //if there is a admin , we return 1

                if (encontrado == 1) //admin has access, client will be redirect to the default page
                {
                    d = c.showAllCruises();
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
            idC.Text = GridView1.SelectedRow.Cells[1].Text;
            depTime.Text = GridView1.SelectedRow.Cells[2].Text;
            arTime.Text = GridView1.SelectedRow.Cells[3].Text;
            depCi.Text = GridView1.SelectedRow.Cells[4].Text;
            ruta.Text = GridView1.SelectedRow.Cells[5].Text;
            priceC.Text = GridView1.SelectedRow.Cells[6].Text;
            companyC.Text = GridView1.SelectedRow.Cells[7].Text;
            extrasC.Text = GridView1.SelectedRow.Cells[8].Text;
            imageT.Text = GridView1.SelectedRow.Cells[9].Text;
            idC.Enabled = false;

            EditButton.Visible = true; //change visibility of the buttons
            InsertButton.Visible = false;
        }

        protected void GridView1_sendUpdate(object sender, EventArgs e) //update a product
        {
            c.id = int.Parse(idC.Text);
            c.DepartureTime = depTime.Text;
            c.ArrivalTime = arTime.Text;
            c.city = depCi.Text;
            c.route = ruta.Text;
            c.Price = int.Parse(priceC.Text);
            c.Company = int.Parse(companyC.Text);
            c.Extras = int.Parse(extrasC.Text);
            c.Image = imageT.Text;

            d = c.update_Cruise(GridView1.SelectedIndex);
            Response.Redirect("Cruise.aspx");
        }

        protected void sendInsert(object sender, EventArgs e) //insert a new product
        {
            c.id = int.Parse(idC.Text);
            c.DepartureTime = depTime.Text;
            c.ArrivalTime = arTime.Text;
            c.city = depCi.Text;
            c.route = ruta.Text;
            c.Price = int.Parse(priceC.Text);
            c.Company = int.Parse(companyC.Text);
            c.Extras = int.Parse(extrasC.Text);
            c.Image = imageT.Text;

            d = c.add_Cruise();
            GridView1.DataSource = d;
            GridView1.DataBind();

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e) //delete a product
        {
            d = c.delete_Cruise(e.RowIndex);
            GridView1.DataSource = d;
            GridView1.DataBind();
        }

    }
}