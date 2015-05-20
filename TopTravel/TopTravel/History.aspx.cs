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
using ClassLibrary1;
using Microsoft.AspNet.Membership.OpenAuth;

namespace TopTravel
{
    public partial class History : Page
    {
        OrderEN o = new OrderEN();
        DataSet d = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated)
            {
                d = o.searchHistory(User.Identity.Name);
                GridView1.DataSource = d;
                GridView1.DataBind();
            }
            else
            {
                Response.Redirect("/Account/Login.aspx");
            }
        }
    }
}