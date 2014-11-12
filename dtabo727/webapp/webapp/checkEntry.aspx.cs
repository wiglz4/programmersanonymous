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
    public partial class WebForm1 : System.Web.UI.Page
    {
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
            int caseSwitch = 2;//  grab value from current loggedin user's privilege                       ****NEED TO IMPLEMENT****
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
                    Console.WriteLine("Default case");
                    break;
            }
            
        }

        protected void checkEntrySubmitButton_Click(object sender, EventArgs e)
        {
            String accountID = routingNoTextBox.Text + ':' + accountNoTextBox.Text;

            //create or verify Account's existence
            bool success = SOURCE.Account.Insert(accountID, storeIDTextBox.Text, firstNameTextBox.Text, LastNameTextBox.Text, streetNameTextBox.Text, cityTextBox.Text, stateTextBox.Text, zipTextBox.Text);
            if (success)
            {
                if (Check.Insert(accountID, checkValueTextBox.Text, checkNoTextBox.Text))
                {
                    //tell em it worked
                    string script = "alert('Submitted!');";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", script, true);
                }
                else
                {
                    //check data was bad
                    string script = "alert('Check Data is Incorrectly Formatted.');";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", script, true);
                }
            }
            else
            {
                //account data was bad
                string script = "alert('Account Data is Incorrectly Formatted.');";
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", script, true);
            }
        }  
    }
}