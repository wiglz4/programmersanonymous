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
        // destroy previous login session on pageload
        protected void Page_Load(object sender, EventArgs e)
        {
            bool loggedIn = System.Web.HttpContext.Current.User.Identity.IsAuthenticated;
            if (loggedIn)
            {
                System.Web.Security.FormsAuthentication.SignOut();
            }
        } 
            
        public void LoginUser_Authenticate(object sender, AuthenticateEventArgs e)
        {

            //verify what was in username box to data set
            TextBox username = (TextBox)LoginUser.FindControl("UserName");
            string uName = username.Text;
            TextBox password = (TextBox)LoginUser.FindControl("Password");
            string pWord = password.Text;
            TextBox compID = (TextBox)LoginUser.FindControl("CompanyID");
            string cID = compID.Text;

            Session["uName"] = uName;
            Session["pWord"] = pWord;
            Session["cID"] = cID;


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
