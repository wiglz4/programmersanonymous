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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void checkEntrySubmitButton_Click(object sender, EventArgs e)
        {
            String connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            DataSet ds = new DataSet();

            String accountID = routingNoTextBox.Text + ':' + accountNoTextBox.Text;
           // double epoch = (DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;

            // Connect to the database and run the query.
            OleDbConnection connection = new OleDbConnection(connectionString);
            OleDbCommand cmdAccount = new OleDbCommand("Insert Into Account([Account ID], [Store ID], [First Name], [Last Name], Street, City, State, ZipCode) Values (@AccountIDParam, @StoreIDParam, @FirstNameParam, @LastNameParam, @StreetParam, @CityParam, @StateParam, @ZipcodeParam)", connection);
            cmdAccount.Parameters.AddWithValue("@AccountIDParam", accountID);
            cmdAccount.Parameters.AddWithValue("@StoreIDParam", storeIDTextBox.Text);
            cmdAccount.Parameters.AddWithValue("@FirstNameParam", firstNameTextBox.Text);
            cmdAccount.Parameters.AddWithValue("@LastNameParam", LastNameTextBox.Text);
            cmdAccount.Parameters.AddWithValue("@StreetParam", streetNameTextBox.Text);
            cmdAccount.Parameters.AddWithValue("@CityParam", cityTextBox.Text);
            cmdAccount.Parameters.AddWithValue("@StateParam", stateTextBox.Text);
            cmdAccount.Parameters.AddWithValue("@ZipCodeParam", zipTextBox.Text);
            connection.Open();
            cmdAccount.ExecuteNonQuery();

            OleDbCommand cmdCheck = new OleDbCommand("Insert Into [Check]([Account ID], [Amount Paid], [Amount Due], [Check Number], [Letter Sent Number]) Values (@AccountIDParam, @AmountPaidParam, @AmountDueParam, @CheckNoParam, @LetterNoParam)", connection);
            cmdCheck.Parameters.AddWithValue("@AccountIDParam", accountID);
            cmdCheck.Parameters.AddWithValue("@AmountPaidParam", "0.00");
            cmdCheck.Parameters.AddWithValue("@AmountDueParam", checkValueTextBox.Text);
            cmdCheck.Parameters.AddWithValue("@CheckNoParam", checkNoTextBox.Text);
            cmdCheck.Parameters.AddWithValue("@LetterNoParam", '0');
            //connection.Open();
            cmdCheck.ExecuteNonQuery();
            //OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);


            string script = "alert('Submitted!');";
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", script, true);
        }  
    }
}