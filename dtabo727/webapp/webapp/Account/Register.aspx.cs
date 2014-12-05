using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webapp.Account
{
    public partial class Register : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //RegisterUser.ContinueDestinationPageUrl = Request.QueryString["ReturnUrl"];
            CreateUserButton.Click += new EventHandler(this.RegisterUser_CreatedUser);
        }

        protected void RegisterUser_CreatedUser(object sender, EventArgs e)
        {
            string script;

            TextBox StoreID = (TextBox)webapp.WebForm1.FindControlRecursive(this.Master, "StoreID");
            TextBox FirstName = (TextBox)webapp.WebForm1.FindControlRecursive(this.Master, "FirstName");
            TextBox LastName = (TextBox)webapp.WebForm1.FindControlRecursive(this.Master, "LastName");
            TextBox UserName = (TextBox)webapp.WebForm1.FindControlRecursive(this.Master, "UserName");
            TextBox Password = (TextBox)webapp.WebForm1.FindControlRecursive(this.Master, "Password");
            TextBox CompID = (TextBox)webapp.WebForm1.FindControlRecursive(this.Master, "CompID");

            if (webapp.SOURCE.User.Insert(StoreID.Text, CompID.Text, FirstName.Text, LastName.Text, UserName.Text, Password.Text, 2))
            {
                //YAY!!!
                script = "alert('Successfully added " + FirstName.Text + " " + LastName.Text + ".');";
            }
            else
            {
                script = "alert('Invalid data. Please modify data and try again.');";
                //BOOM
            }
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", script, true);
        }

    }
}
