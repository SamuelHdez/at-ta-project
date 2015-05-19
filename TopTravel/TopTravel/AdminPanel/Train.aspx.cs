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
    public partial class TrainAdmin : Page
    {
        TrainEN t = new TrainEN();
        DataSet d = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            SqlConnection c = new SqlConnection(s);

            SqlDataAdapter sda = new SqlDataAdapter("Select count(*) FROM Admin WHERE name = '" + User.Identity.Name + "'", c);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows[0][0].ToString() == "1")
            {
                d = t.showAllTrains();
                GridView1.DataSource = d;
                GridView1.DataBind();
            }
            else
            {
                Response.Redirect("../Default.aspx");
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
                
            }
            else if (typeAdmin.Text == "SpaceTravel")
            {
                Response.Redirect("../AdminPanel/SpaceTravel.aspx");
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            idT.Text = GridView1.SelectedRow.Cells[1].Text;
            depTimeT.Text = GridView1.SelectedRow.Cells[2].Text;
            arTimeT.Text = GridView1.SelectedRow.Cells[3].Text;
            depCiT.Text = GridView1.SelectedRow.Cells[4].Text;
            destinationT.Text = GridView1.SelectedRow.Cells[5].Text;
            priceT.Text = GridView1.SelectedRow.Cells[6].Text;
            companyT.Text = GridView1.SelectedRow.Cells[7].Text;
            extrasT.Text = GridView1.SelectedRow.Cells[8].Text;
            imageT.Text = GridView1.SelectedRow.Cells[9].Text;
            idT.Enabled = false;
        }

        protected void GridView1_sendUpdate(object sender, EventArgs e)
        {
            t.id = int.Parse(idT.Text);
            t.DepartureTime = depTimeT.Text;
            t.ArrivalTime = arTimeT.Text;
            t.DepartureCity = depCiT.Text;
            t.DestinationCity = destinationT.Text;
            t.Price = int.Parse(priceT.Text);
            t.Company = int.Parse(companyT.Text);
            t.Extras = int.Parse(extrasT.Text);
            t.Images = imageT.Text;

            d = t.update_train(GridView1.SelectedIndex);
            GridView1.DataSource = d;
            GridView1.DataBind();
        }

        protected void sendInsert(object sender, EventArgs e)
        {
            t.id = int.Parse(idT.Text);
            t.DepartureTime = depTimeT.Text;
            t.ArrivalTime = arTimeT.Text;
            t.DepartureCity = depCiT.Text;
            t.DestinationCity = destinationT.Text;
            t.Price = int.Parse(priceT.Text);
            t.Company = int.Parse(companyT.Text);
            t.Extras = int.Parse(extrasT.Text);
            t.Images = imageT.Text;

            d = t.add_Train();
            GridView1.DataSource = d;
            GridView1.DataBind();

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            d = t.delete_train(e.RowIndex);
            GridView1.DataSource = d;
            GridView1.DataBind();
        }
    }
}