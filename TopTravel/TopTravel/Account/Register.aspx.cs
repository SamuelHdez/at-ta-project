using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Membership.OpenAuth;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;
using TopTravel;

namespace TopTravel.Account
{
    public partial class Register : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterUser.ContinueDestinationPageUrl = Request.QueryString["ReturnUrl"];
        }

        protected void RegisterUser_CreatedUser(object sender, EventArgs e)
        {
            // Get the UserId of the just-added user
            MembershipUser newUser = Membership.GetUser(RegisterUser.UserName);

            Guid newUserId = (Guid)newUser.ProviderUserKey;

            //Get Profile Data Entered by user in CUW control
            String dni = ((TextBox)RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("dni")).Text;
            String name = ((TextBox)RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("name")).Text;
            String surname = ((TextBox)RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("surname")).Text;
            String phone = ((TextBox)RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("phone")).Text;
            String address = ((TextBox)RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("address")).Text;
            String gender = ((RadioButtonList)RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("gender")).Text;

            // Get your Connection String from the web.config. MembershipConnectionString is the name I have in my web.config
            string connectionString;
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();

            string insertSql = "INSERT INTO Client(Id,name,surname,dni,phone,address,gender) VALUES(@UserId, @name, @surname, @dni, @phone, @address, @gender)";

            using (SqlConnection myConnection = new SqlConnection(connectionString))
            {

                myConnection.Open();

                SqlCommand myCommand = new SqlCommand(insertSql, myConnection);

                myCommand.Parameters.AddWithValue("@UserId", newUserId);
                myCommand.Parameters.AddWithValue("@name", name);
                myCommand.Parameters.AddWithValue("@surname", surname);
                myCommand.Parameters.AddWithValue("@dni", dni);
                myCommand.Parameters.AddWithValue("@phone", phone);
                myCommand.Parameters.AddWithValue("@address", address);
                myCommand.Parameters.AddWithValue("@gender", gender);
                myCommand.ExecuteNonQuery();

                myConnection.Close();

            }

            FormsAuthentication.SetAuthCookie(RegisterUser.UserName, createPersistentCookie: false);

            string continueUrl = RegisterUser.ContinueDestinationPageUrl;
            if (!OpenAuth.IsLocalUrl(continueUrl))
            {
                continueUrl = "~/";
            }
            Response.Redirect(continueUrl);
        }
    }
}