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
        protected void Page_Load(object sender, EventArgs e)
        {

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