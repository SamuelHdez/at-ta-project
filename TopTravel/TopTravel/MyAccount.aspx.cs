﻿using System;
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

                    nameChange.Text = GridView1.Rows[0].Cells[2].Text; //change values
                    surnameChange.Text = GridView1.Rows[0].Cells[3].Text;
                    phoneChange.Text = GridView1.Rows[0].Cells[4].Text;
                    addressChange.Text = GridView1.Rows[0].Cells[5].Text;
                    creditCardChange.Text = GridView1.Rows[0].Cells[7].Text;
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
            CL.CreditCard = int.Parse(creditCardChange.Text);
            CL.Password = passwordConfirm.Text;

            CL.update_Client2(GridView1.Rows[0].Cells[1].Text, CL.Password); //update the fields
            Response.Redirect("/MyAccount.aspx"); //redirect
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

    }
}