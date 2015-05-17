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
                d = f.showAllFlights();
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
            idH.Enabled = false;
        }

        protected void GridView1_sendUpdate(object sender, EventArgs e)
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

            d = f.update_Flight(GridView1.SelectedIndex);
            GridView1.DataSource = d;
            GridView1.DataBind();
        }

        protected void sendInsert(object sender, EventArgs e)
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

            d = f.add_Flight();
            GridView1.DataSource = d;
            GridView1.DataBind();

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            d = f.delete_Flight(e.RowIndex);
            GridView1.DataSource = d;
            GridView1.DataBind();
        }
    }
}