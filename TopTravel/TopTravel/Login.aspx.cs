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
    public partial class prueba : System.Web.UI.Page
    {
        ClientEN CL = new ClientEN();
        DataSet DS = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void send(object sender, EventArgs e)
        {
            DS = CL.searchDNIClient(UserName.Text, pass.Text);
            int encontrado = Convert.ToInt32(DS.Tables[0].Rows[0][0]); //if there is a client, we return 1
            if (encontrado == 1)
            {
                Session["login"] = UserName.Text; //store in the Session the dni of the user
                Session.Timeout = 30; //30 minutes 
                Response.Redirect("Default.aspx"); 
            }
        }

        protected void sendR(object sender, EventArgs e)
        {
            CL.Dni = dniR.Text;
            CL.Name = nameR.Text;
            CL.Surname = surnameR.Text;
            CL.Phone = phoneR.Text;
            CL.Address = addressR.Text;
            CL.Gender = gender.Text;
            CL.CreditCard = int.Parse(cardR.Text);
            CL.Admin = 0;
            CL.Password = passR.Text;
            CL.Avatar = avatarR.Text;

            DS = CL.add_Client();
            
        }
    }
}