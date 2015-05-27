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

namespace TopTravel
{
    public partial class Register : System.Web.UI.Page
    {
        ClientEN CL = new ClientEN(); //client entity
        DataSet DS = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void sendR(object sender, EventArgs e) //send button
        {
            CL.Dni = dniR.Text; //put data in the fields
            CL.Name = nameR.Text;
            CL.Surname = surnameR.Text;
            CL.Phone = phoneR.Text;
            CL.Address = addressR.Text;
            CL.Gender = gender.Text;
            CL.CreditCard = cardR.Text;
            CL.Admin = 0;
            CL.Password = passR.Text;
            CL.Avatar = avatarR.Text;

            DS = CL.add_Client(); //insert client

            Response.Redirect("/Login.aspx"); //redirect

        }
    }
}