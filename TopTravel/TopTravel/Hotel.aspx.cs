using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TopTravel
{
    public partial class Hotel : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void send(object sender, EventArgs e)
        {
            ProcessHotel.Text = "We are processing your search request";
            ProcessHotel.Text += Place.Text;
            ProcessHotel.Text += Date.SelectedDate.Day.ToString();
            ProcessHotel.Text += System.Environment.NewLine;
            ProcessHotel.Text += Nights.Text;
        }
    }
}