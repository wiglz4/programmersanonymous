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

namespace webapp
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            QueryCheckNumber.Click += new EventHandler(this.QueryBtn_Click);
            int caseSwitch = SOURCE.User.getPrivilege();//  grab value from current loggedin user's privilege

            switch (caseSwitch)
            {
                // case 1 = standard user (data-entry clerk) {checkEntry only}
                case 1:
                    {
                        Menu menu = (Menu)WebForm1.FindControlRecursive(this.Master, "NavigationMenu");
                        // Menu menu = (Menu)this.FindControl("NavigationMenu");
                        MenuItemCollection menuItems = menu.Items;


                        for (int i = 0; i < menuItems.Count; i++)
                        {
                            if (menuItems[i].Text != "Enter Check")
                            {
                                menuItems.Remove(menuItems[i]);
                                i--;
                            }
                        }

                    }
                    break;

                // case 2 = local treasurer user (data-entry + data-retrieval + print letters) {removes Add User}
                case 2:
                    {
                        Menu menu = (Menu)WebForm1.FindControlRecursive(this.Master, "NavigationMenu");
                        // Menu menu = (Menu)this.FindControl("NavigationMenu");
                        MenuItemCollection menuItems = menu.Items;

                        for (int i = 0; i < menuItems.Count; i++)
                        {
                            if (menuItems[i].Text == "Add User")
                            {
                                menuItems.Remove(menuItems[i]);
                                i--;
                            }
                        }

                    }
                    break;
                case 3:

                    break;
            }

        }

        protected void QueryBtn_Click(Object sender, EventArgs e)
        {
            string checkNo = CheckNumber.Text;
            
            DataSet ds = Check.Query(checkNo);

            //bind the dataset to gridview
            if (ds.Tables.Count > 0)
            {
                myGridView.DataSource = ds;
                myGridView.DataBind();
            }
        }
    }
}