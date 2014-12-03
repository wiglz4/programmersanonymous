using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webapp.Account
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //SubmitCheckNumber.OnClientClick="javascript:window.open('MyPage.aspx?Param=" + Param1.ToString() + "');";         }
        }

        protected void SubmitCheckNumber_Click(object sender, EventArgs e)
        {
            if (webapp.SOURCE.Print.genLetter(CheckNumber.Text, int.Parse(LetterNumberDropDownList.Text)))
            {
                //Response.Redirect("~/printPreview.aspx");
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('printPreview.aspx');", true);
            }
            else
            {
                string script = "alert('Check Number is not valid. Please enter a stored check number.');";
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", script, true);
            }
            //Session["presentLetterHTML"] = presentLetterHTML;
            
            
        }

       

        
    }
}