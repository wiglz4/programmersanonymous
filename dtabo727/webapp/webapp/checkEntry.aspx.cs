using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webapp
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void checkEntrySubmitButton_Click(object sender, EventArgs e)
        {
           /* System.Windows.Forms.MessageBox.Show("Submitted!"); */
            string script = "alert('Submitted!');";
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", script, true);

          
            
            /*Lots of code to add fields to DB*/

           /*I'm a terrible person, but this is a mockup. 
             
             Deal with it. 
            
             (•_•)
             ( •_•)>⌐■-■
             (⌐■_■)                                     */


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

        }  

        
    }
}