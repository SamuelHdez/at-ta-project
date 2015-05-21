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
        CompanyEN h = new CompanyEN(); //company entity
        DataSet d = new DataSet(); //dataset

        protected void Page_Load(object sender, EventArgs e)
        {
            d = h.showAllCompanies(); //show a list of companies
            GridView1.DataSource = d; //store it in the grid
            GridView1.DataBind();
        }


        protected void radioChange(object sender, EventArgs e) //when change the type of the company (radio button)
        {

            d = h.searchAllCompanies(typeCompany.Text); //filter by type of company: hotel, flight, ...
            GridView1.DataSource = d;
            GridView1.DataBind();

        }


        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e) //when change the index
        {
            this.GridView1.PageIndex = e.NewPageIndex; 
            //LLenarDatosConsejera();
            this.GridView1.DataBind();
        }

    }
}