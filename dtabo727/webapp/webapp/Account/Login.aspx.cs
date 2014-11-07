using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Configuration;

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

            e.Authenticated = verifyLogin(uName, pWord, cID);
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {


        }

        public bool verifyLogin(string uName, string pWord, string cID)
        {
            //get data from database
            String connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            DataSet ds = new DataSet();

            // Connect to the database and run the query.
            OleDbConnection connection = new OleDbConnection(connectionString);
            string query = "Select * From [User] Where (Username = '" + uName + "') And (Password = '" + pWord + "') And ([Company ID] = '" + cID + "')";
            OleDbCommand cmd = new OleDbCommand(query, connection);
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);

            // Fill the DataSet.
            adapter.Fill(ds);

            // verify username and password
            if (ds.Tables[0].Rows.Count == 0)
            {
                //credentials were wrong
                return false;
            }
            else if (ds.Tables[0].Rows.Count == 1)
            {
                //congratulations login is succesfull
                return true;
            }
            else
            {
                //error more than one record of this user exists. please contact system administrator
                return false;
            }
        }
    }
}
