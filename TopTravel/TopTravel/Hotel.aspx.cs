using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using TopTravelLibrary;


namespace TopTravel
{
       
    public partial class Hotel : Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {

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
            HotelEN h = new HotelEN();
             DataSet d = new DataSet();
            d = h.showAllHotels();
           GridView1.DataSource = d;
            GridView1.DataBind();
        }
    }
}