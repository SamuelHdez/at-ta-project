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
    public partial class Companies : Page
    {
        CompanyEN h = new CompanyEN();
        DataSet d = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            d = h.showAllCompanies();
            GridView1.DataSource = d;
            GridView1.DataBind();
        }


        protected void radioChange(object sender, EventArgs e)
        {

            d = h.searchAllCompanies(typeCompany.Text);
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