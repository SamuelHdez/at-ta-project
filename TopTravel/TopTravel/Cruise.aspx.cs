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
    public partial class Cruise : Page
    {
        CruiseEN h = new CruiseEN();
        DataSet d = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            d = h.showAllCruises();
            GridView1.DataSource = d;
            GridView1.DataBind();
        }

        protected void send(object sender, EventArgs e)
        {
            d = h.searchAllCruises(region.Text, dep.Text);
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