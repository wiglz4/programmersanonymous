using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using webapp.SOURCE;

namespace webapp.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        
        {
        } 
            
        protected void LoginUser_Authenticate(object sender, AuthenticateEventArgs e)
        {

            //verify what was in username box to data set

            TextBox username = (TextBox)LoginUser.FindControl("UserName");
            string uName = username.Text;
            TextBox password = (TextBox)LoginUser.FindControl("Password");
            string pWord = password.Text;
            TextBox compID = (TextBox)LoginUser.FindControl("CompanyID");
            string cID = compID.Text;

            if (SOURCE.User.Login(uName, pWord, cID)) 
            {
                e.Authenticated = true;
            } 
            else 
            {
                e.Authenticated = false;
            }
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {

        }
    }
}
