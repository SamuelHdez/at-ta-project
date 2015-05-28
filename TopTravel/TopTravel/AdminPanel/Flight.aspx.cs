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
    public partial class FlightAdmin : Page
    {
        FlightEN f = new FlightEN();
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
                    d = f.showAllFlights();
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
            depTime.Text = GridView1.SelectedRow.Cells[2].Text;
            arTime.Text = GridView1.SelectedRow.Cells[3].Text;
            depCi.Text = GridView1.SelectedRow.Cells[4].Text;
            destination.Text = GridView1.SelectedRow.Cells[5].Text;
            classF.Text = GridView1.SelectedRow.Cells[6].Text;
            priceF.Text = GridView1.SelectedRow.Cells[7].Text;
            companyF.Text = GridView1.SelectedRow.Cells[8].Text;
            extrasF.Text = GridView1.SelectedRow.Cells[9].Text;
            imageF.Text = GridView1.SelectedRow.Cells[10].Text;
            idH.Enabled = false;

            EditButton.Visible = true; //change visibility of the buttons
            InsertButton.Visible = false;
        }

        protected void GridView1_sendUpdate(object sender, EventArgs e) //update a product
        {
            f.id = int.Parse(idH.Text);
            f.DepartureTime = depTime.Text;
            f.ArrivalTime = arTime.Text;
            f.DepartureCity = depCi.Text;
            f.DestinationCity = destination.Text;
            f.classFlight = classF.Text;
            f.Price = int.Parse(priceF.Text);
            f.Company = int.Parse(companyF.Text);
            f.Extras = int.Parse(extrasF.Text);
            f.Image = imageF.Text;

            d = f.update_Flight(GridView1.SelectedIndex);
            Response.Redirect("Flight.aspx");
        }

        protected void sendInsert(object sender, EventArgs e) //insert a new product
        {
            f.id = int.Parse(idH.Text);
            f.DepartureTime = depTime.Text;
            f.ArrivalTime = arTime.Text;
            f.DepartureCity = depCi.Text;
            f.DestinationCity = destination.Text;
            f.classFlight = classF.Text;
            f.Price = int.Parse(priceF.Text);
            f.Company = int.Parse(companyF.Text);
            f.Extras = int.Parse(extrasF.Text);
            f.Image = imageF.Text;

            d = f.add_Flight();
            GridView1.DataSource = d;
            GridView1.DataBind();

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e) //delete a product
        {
            d = f.delete_Flight(e.RowIndex);
            GridView1.DataSource = d;
            GridView1.DataBind();
        }
    }
}