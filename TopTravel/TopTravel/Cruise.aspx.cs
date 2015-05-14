using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TopTravel
{
    public partial class Cruise : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void send(object sender, EventArgs e)
        {
            ProcessCruise.Text = "We are processing your search request";
            //ProcessCruise.Text = Departure.SelectedDate.ToShortDateString();
            ProcessCruise.Text = Departure.SelectedDate.Day.ToString();
        }
    }
}