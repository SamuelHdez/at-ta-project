using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary1;

namespace TopTravel
{
       
    public partial class Hotel : Page
    {
        HotelEN h = new HotelEN();
        DataSet d = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
           // if (!Page.IsPostBack)
            //{
                
                d = h.showAllHotels();
                GridView1.DataSource = d;
                GridView1.DataBind();
                 
            //}
        }

        protected void send(object sender, EventArgs e)
        {
            /*
            ProcessHotel.Text = "We are processing your search request";
            ProcessHotel.Text += Place.Text;
            ProcessHotel.Text += Date.SelectedDate.Day.ToString();
            ProcessHotel.Text += System.Environment.NewLine;
            ProcessHotel.Text += Nights.Text;
              */
            d = h.searchAllHotels(Place2.Text);
            GridView1.DataSource = d;
            GridView1.DataBind();
           
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridView1.PageIndex = e.NewPageIndex;
            //LLenarDatosConsejera();
            this.GridView1.DataBind();
        }
    }
}