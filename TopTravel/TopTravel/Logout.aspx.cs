using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TopTravel
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login"] != null) // if there is a user
            {
                Session.Abandon(); //close the session
            }

            Response.Redirect("Default.aspx");
        }
    }
}