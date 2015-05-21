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
        ClientEN CL = new ClientEN(); // client entity
        DataSet DS = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void send(object sender, EventArgs e) //send button
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
    }
}