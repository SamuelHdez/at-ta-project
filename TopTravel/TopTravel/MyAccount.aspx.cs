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

namespace TopTravel
{
    public partial class MyAccount : Page
    {
        ClientEN h = new ClientEN();
        DataSet d = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Login"] != null)
            {
                d = h.showClientData(Session["Login"].ToString());
                GridView1.DataSource = d;
                GridView1.DataBind();
            }
        }

    }
}