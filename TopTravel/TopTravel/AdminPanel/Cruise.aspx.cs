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
        DataSet d = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            string s;
            s = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            SqlConnection con = new SqlConnection(s);

            SqlDataAdapter sda = new SqlDataAdapter("Select count(*) FROM Admin WHERE name = '" + User.Identity.Name + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows[0][0].ToString() == "1")
            {
                d = c.showAllCruises();
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
            idC.Enabled = false;
        }

        protected void GridView1_sendUpdate(object sender, EventArgs e)
        {
            c.id = int.Parse(idC.Text);
            c.DepartureTime = depTime.Text;
            c.ArrivalTime = arTime.Text;
            c.city = depCi.Text;
            c.route = ruta.Text;
            c.Price = int.Parse(priceC.Text);
            c.Company = int.Parse(companyC.Text);
            c.Extras = int.Parse(extrasC.Text);

            d = c.update_Cruise(GridView1.SelectedIndex);
            GridView1.DataSource = d;
            GridView1.DataBind();
        }

        protected void sendInsert(object sender, EventArgs e)
        {
            c.id = int.Parse(idC.Text);
            c.DepartureTime = depTime.Text;
            c.ArrivalTime = arTime.Text;
            c.city = depCi.Text;
            c.route = ruta.Text;
            c.Price = int.Parse(priceC.Text);
            c.Company = int.Parse(companyC.Text);
            c.Extras = int.Parse(extrasC.Text);

            d = c.add_Cruise();
            GridView1.DataSource = d;
            GridView1.DataBind();

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            d = c.delete_Cruise(e.RowIndex);
            GridView1.DataSource = d;
            GridView1.DataBind();
        }

    }
}