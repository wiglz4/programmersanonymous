using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.OleDb;
using System.Configuration;
using webapp.SOURCE;

namespace webapp.Account
{
    public partial class Register : System.Web.UI.Page
    {
        int priv = 0;
        //apply permissions by showing or hiding menu items based on user permission level
        //http://www.blackbeltcoder.com/Articles/asp/recursively-finding-controls (http://www.blackbeltcoder.com/Legal/Licenses/CPOL)
        public static Control FindControlRecursive(Control Root, string Id)
        {
            if (Root.ID == Id)
                return Root;
            foreach (Control Ctl in Root.Controls)
            {
                Control FoundCtl = FindControlRecursive(Ctl, Id);
                if (FoundCtl != null)
                    return FoundCtl;
            }

          return null;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
            CreateUserButton.Click += new EventHandler(this.RegisterUser_CreatedUser);
            int caseSwitch = SOURCE.User.getPrivilege();//  grab value from current loggedin user's privilege
            
            switch (caseSwitch)
            {
                // case 1 = unsused since lowest privilege level cannot add users.
                case 1:
                    break;

                // case 2 = local treasurer user creates level 1 clerks
                case 2:
                    {
                        priv = 1;
                    }
                    break;
                // case 3 = backend admin user creates level 2 treasurers
                case 3:
                    {
                        priv = 2;
                    }
                    break;
            }
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

            if (webapp.SOURCE.User.Insert(StoreID.Text, CompID.Text, FirstName.Text, LastName.Text, UserName.Text, Password.Text, priv))
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
