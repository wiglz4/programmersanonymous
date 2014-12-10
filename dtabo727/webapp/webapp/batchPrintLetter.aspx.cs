using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
using System.Web.UI;
using System.Web.UI.WebControls;
using webapp.SOURCE;
using System.Net;


namespace webapp.Account
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void SubmitCheckNumber_Click(object sender, EventArgs e)
        {
            int letterNo = Int32.Parse(LetterNumberDropDownList.Text);
            letterNo = letterNo - 1;
            DataSet ds = Check.letterQuery(letterNo);

            //clean ~/App_Data/singlePDFs folder in prep for creating new single PDFs
            //if successful then proceed with new PDF creation
            bool success0 = (Print.prepDirForPrint());

            if (success0)
            {
                int fileNumber = 1;

                //generate single PDFs in prep for merge
                //batch merge singlePDFs into large PDF
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    string acctID = dr[0].ToString();
                    string amtDue = dr[2].ToString();
                    string checkNo = dr[3].ToString();
                    string date = dr[5].ToString();

                    bool success1 = (Print.singlePDFs(acctID, amtDue, checkNo, date, letterNo, fileNumber));
                    if (success1)
                    {
                        fileNumber++;
                    }
                    else
                    {
                        string script = "alert('Individual PDF creation failed!');";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", script, true);
                    }
                }

                bool success2 = (Print.CreateMergedPDF());

                if (success2)
                {
                    string script = "alert('Merged PDF creation Success!');";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", script, true);
                }
                else
                {
                    string script = "alert('Merged PDF creation failed! Please ensure that no other programs (such as PDF viewing programs) are accessing any Bounce House files.');";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", script, true);
                }
            }
            else
            {
                string script = "alert('Directory was not cleaned. Please ensure that no individual letter files are in use');";
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", script, true);
            }
        }


        //load final batch PDF in new tab
        protected void ViewPDF(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('openPDF.aspx');", true);
        }
    }
}