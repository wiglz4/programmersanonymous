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


        }

        protected void QueryBtn_Click(Object sender, EventArgs e)
        {
            DataSet ds = Check.Query("");

            //bind the dataset to gridview
            if (ds.Tables.Count > 0)
            {
                myGridView.DataSource = ds;
                myGridView.DataBind();
            }
        }
    }
}