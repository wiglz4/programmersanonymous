using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Drawing;
using webapp.SOURCE;

namespace webapp
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            QueryCheckNumber.Click += new EventHandler(this.QueryBtn_Click);
            EditButton.Click += new EventHandler(this.Edit_Click);
            DeleteButton.Click += new EventHandler(this.Delete_Click);
            CancelButton.Click += new EventHandler(this.Cancel_Click);
            SaveButton.Click += new EventHandler(this.Save_Click);
            PrintButton.Click += new EventHandler(this.Print_Click);
            int caseSwitch = SOURCE.User.getPrivilege();//  grab value from current loggedin user's privilege
            myGridView.RowDataBound += new GridViewRowEventHandler(myGridView_RowDataBound);
            myGridView.SelectedIndexChanged += new EventHandler(myGridView_SelectedIndexChanged);

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

        protected void Edit_Click(Object sender, EventArgs e)
        {
            Label1.Visible = true;
            AccID.Visible = true;
            AccID.Text = GridView2.Rows[0].Cells[0].Text;

            Label3.Visible = true;
            AmtPaid.Visible = true;
            AmtPaid.Text = GridView2.Rows[0].Cells[1].Text;

            Label4.Visible = true;
            AmtDue.Visible = true;
            AmtDue.Text = GridView2.Rows[0].Cells[2].Text; 

            Label5.Visible = true;
            CheckNo.Visible = true;
            CheckNo.Text = GridView2.Rows[0].Cells[3].Text; 
            
            Label6.Visible = true;
            LetterNo.Visible = true;
            LetterNo.Text = GridView2.Rows[0].Cells[4].Text;
            
            Label7.Visible = true;
            CheckDate.Visible = true;
            CheckDate.Text = GridView2.Rows[0].Cells[5].Text;

            SaveButton.Visible = true;
        }

        protected void Print_Click(Object sender, EventArgs e)
        {
            //DEBUG
            //adding one cuz of TABOR
            if (Print.genLetter(GridView2.Rows[0].Cells[3].Text, Convert.ToInt32(GridView2.Rows[0].Cells[4].Text) + 1))
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('printPreview.aspx');", true);
            }

            Cancel_Click(this, null);
        }

        protected void Save_Click(Object sender, EventArgs e)
        {
            string script;
            //at this point, grid view 2 contains the entry i want to mess with

            //GET OLD VALUES TO VERIFY UPDATING CORRECT CHECK
            string accountID = GridView2.Rows[0].Cells[0].Text;
            string checkPaid = GridView2.Rows[0].Cells[1].Text;
            string checkValue = GridView2.Rows[0].Cells[2].Text;
            string checkNo = GridView2.Rows[0].Cells[3].Text;
            string letterNo = GridView2.Rows[0].Cells[4].Text;
            string checkDate = GridView2.Rows[0].Cells[5].Text;

            //GET NEW VALUES FROM TEXT ENTRY BOXES
            string accountIDNew = AccID.Text;
            string checkPaidNew = AmtPaid.Text;
            string checkValueNew = AmtDue.Text;
            string checkNoNew = CheckNo.Text;
            string letterNoNew = LetterNo.Text;
            string checkDateNew = CheckDate.Text;

            if (!Check.Update(accountID, checkPaid, checkValue, checkNo, letterNo, checkDate, accountIDNew, checkPaidNew, checkValueNew, checkNoNew, letterNoNew, checkDateNew))
            {
                script = "alert('Invalid data. Please modify data and try again.');";
            }
            else
            {
                script = "alert('Check " + checkNo + ": updated.');";
            }

            Cancel_Click(this, null);

            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", script, true);
            this.QueryBtn_Click(this, null);
        }

        protected void Delete_Click(Object sender, EventArgs e)
        {
            string script;
            //at this point, grid view 2 contains the entry i want to mess with
            string accountID = GridView2.Rows[0].Cells[0].Text;
            string checkPaid = GridView2.Rows[0].Cells[1].Text;
            string checkValue = GridView2.Rows[0].Cells[2].Text;
            string checkNo = GridView2.Rows[0].Cells[3].Text;
            string letterNo = GridView2.Rows[0].Cells[4].Text;
            string checkDate = GridView2.Rows[0].Cells[5].Text;
            //if it fails to delte then we already deleted this and gridview 1 didn't update.
            if (!Check.Delete(accountID, checkPaid, checkValue, checkNo, letterNo, checkDate))
            {
                script = "alert('This record has already been removed.');";
            }
            else
            {
                script = "alert('Check " + checkNo + ": deleted.');";
            }

            Cancel_Click(this, null);

            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", script, true);
            this.QueryBtn_Click(this, null);
        }

        protected void Cancel_Click(Object sender, EventArgs e)
        {
            Label1.Visible = false;
            AccID.Visible = false;
            Label3.Visible = false;
            AmtPaid.Visible = false;
            Label4.Visible = false;
            AmtDue.Visible = false;
            Label5.Visible = false;
            CheckNo.Visible = false;
            Label6.Visible = false;
            LetterNo.Visible = false;
            Label7.Visible = false;
            CheckDate.Visible = false;
            SaveButton.Visible = false;

            PnlMain.Visible = false;
        }

        void myGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            GridViewRow row = myGridView.SelectedRow;
            string accountID = row.Cells[0].Text;
            string checkPaid = row.Cells[1].Text;
            string checkValue = row.Cells[2].Text;
            string checkNo = row.Cells[3].Text;
            string letterNo = row.Cells[4].Text;
            string checkDate = row.Cells[5].Text;
            DataSet ds = Check.SpecificQuery(accountID, checkPaid, checkValue, checkNo, letterNo, checkDate);

            //populate a secondary grid view with JUST the row i want to manipulate
            if (ds.Tables.Count > 0)
            {
                GridView2.DataSource = ds;
                GridView2.DataBind();
            }

            PnlMain.BackColor = Color.LightGray;
            PnlMain.Style.Add("border", "1px solid #666666");
            PnlMain.Style.Add("POSITION", "absolute");
            PnlMain.Visible = true;
        }

        void myGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onContextMenu ", ClientScript.GetPostBackEventReference(myGridView, "Select$" + e.Row.RowIndex.ToString()) + "; return false;");
                e.Row.Attributes.Add("onClick ", ClientScript.GetPostBackEventReference(myGridView, "Select$" + e.Row.RowIndex.ToString()) + "; return false;");
            }
        }

        protected override void Render(HtmlTextWriter writer)
        {
            for (int index = 0; index < myGridView.Rows.Count; index++)
            {
                ClientScript.RegisterForEventValidation(myGridView.UniqueID, "Select$" + index.ToString());
            }

            base.Render(writer);
        }

    }
}