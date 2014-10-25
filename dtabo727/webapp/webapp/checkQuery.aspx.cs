using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Configuration;

namespace webapp
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                String connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;      
                DataSet ds = new DataSet();

                // Connect to the database and run the query.
                OleDbConnection connection = new OleDbConnection(connectionString);
                OleDbCommand cmd = new OleDbCommand("Select * From Company", connection);
                OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                
                // Fill the DataSet.
                adapter.Fill(ds);

                //bind the dataset to gridview
                if (ds.Tables.Count > 0)
                {
                    myGridView.DataSource = ds;
                    myGridView.DataBind();
                }
            }
        }
    }
}