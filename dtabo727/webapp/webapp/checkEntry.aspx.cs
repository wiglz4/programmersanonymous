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

                // case 2 = local treasurer user (data-entry + data-retrieval + print letters + add Level 1 users [clerks]) {plans changed - no controls will be removed now.}
                case 2:
                    break;
                // case 3 = backend admin - no restrictions
                case 3:
                    break;
            }
            
        }

        protected void checkEntrySubmitButton_Click(object sender, EventArgs e)
        {
            int routingNo;
            int accountNo;
            int checkNo;
            try
            {
                routingNo = int.Parse(routingNoTextBox.Text);
            }
            catch
            {
                string script = "alert('Routing Number should contain numerals only.');";
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", script, true);
                return;
            }

            try
            {
                accountNo = int.Parse(accountNoTextBox.Text);
            }
            catch
            {
                string script = "alert('Account Number should contain numerals only.');";
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", script, true);
                return;
            }

            try
            {
                checkNo = int.Parse(checkNoTextBox.Text);
            }
            catch
            {
                string script = "alert('Check Number should contain numerals only.');";
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", script, true);
                return;
            }
            
            int accountID = routingNo+ ':' + accountNo;
            DateTime now = DateTime.Now;
            String checkDate = now.ToString();

            string checkPaid = "0";
            string letterNo = "0";

            //create or verify Account's existence
            bool success = SOURCE.Account.Insert((accountID.ToString()), storeIDTextBox.Text, firstNameTextBox.Text, LastNameTextBox.Text, streetNameTextBox.Text, cityTextBox.Text, stateTextBox.Text, zipTextBox.Text);
            if (success)
            {
                //(string accountID, string checkPaid, string checkValue, string checkNo, string letterNo, string checkDate)
                if (Check.Insert((accountID.ToString()), checkPaid, checkValueTextBox.Text, (checkNo.ToString()), letterNo, checkDate))
                {
                    //tell em it worked
                    string script = "alert('Submitted!');";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", script, true);

                    firstNameTextBox.Text = "";
                    LastNameTextBox.Text = "";
                    streetNameTextBox.Text = "";
                    cityTextBox.Text = "";
                    stateTextBox.Text = "";
                    zipTextBox.Text = "";
                    checkValueTextBox.Text = "";
                    routingNoTextBox.Text = "";
                    accountNoTextBox.Text = "";
                    checkNoTextBox.Text = "";
                    storeIDTextBox.Text = "";
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