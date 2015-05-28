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
        ClientEN CL = new ClientEN(); //client entity
        DataSet d = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
           if (!Page.IsPostBack)
            {
                if (Session["Login"] != null) //if user is logged
                {
                    d = CL.showClientData(Session["Login"].ToString()); //show info
                    GridView1.DataSource = d;
                    GridView1.DataBind();

                    GridView2.DataSource = d;
                    GridView2.DataBind();

                    nameChange.Text = GridView1.Rows[0].Cells[1].Text; //change values
                    surnameChange.Text = GridView1.Rows[0].Cells[2].Text;
                    phoneChange.Text = GridView1.Rows[0].Cells[3].Text;
                    addressChange.Text = GridView1.Rows[0].Cells[4].Text;
                    creditCardChange.Text = GridView1.Rows[0].Cells[6].Text;
                    imageChange.Text = GridView1.Rows[0].Cells[7].Text;
                    passwordChange.Text = GridView1.Rows[0].Cells[8].Text;
                    passwordChangeConfirm.Text = GridView1.Rows[0].Cells[8].Text;
                }
                else
                {
                    Response.Redirect("Login.aspx"); //else redirect
                }
           }
        }

        protected void send(object sender, EventArgs e) //send button
        {
            CL.Name = nameChange.Text;
            CL.Surname = surnameChange.Text;
            CL.Phone = phoneChange.Text;
            CL.Address = addressChange.Text;
            CL.CreditCard = creditCardChange.Text;
            CL.Avatar = imageChange.Text;
            CL.Password = passwordChange.Text;

            CL.update_Client2(GridView1.Rows[0].Cells[0].Text); //update the fields
            //Response.Redirect("/MyAccount.aspx"); //redirect
            d = CL.showClientData(Session["Login"].ToString()); //show info
            GridView1.DataSource = d;
            GridView1.DataBind();
            success.Visible = true;
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

    }
}