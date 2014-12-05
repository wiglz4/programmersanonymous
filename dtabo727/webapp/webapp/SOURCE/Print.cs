using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Configuration;

namespace webapp.SOURCE
{

    public class Print
    {
        
        static String connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        
        
        //modify to do a specifi query
        public static bool genLetter(string checkNo, int letterNo)
        {
            DataSet ds = new DataSet();
            DateTime now = DateTime.Now;
            string letterDate = now.ToString();
            

            OleDbConnection connection = new OleDbConnection(connectionString);
            OleDbCommand cmdCheck = new OleDbCommand(@"Select * FROM [Check] WHERE ([Check Number] = @checkNo)", connection);
            cmdCheck.Parameters.AddWithValue("@checkNo", checkNo);

            connection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmdCheck);
            adapter.Fill(ds);
            int amtDue = 0;
            string checkDate = "";
            

            try
            {
                amtDue = int.Parse(ds.Tables[0].Rows[0][2].ToString());
            }
            catch 
            {
                return false;
            }

            try
            {
                checkDate = ds.Tables[0].Rows[0][5].ToString();
            }
            catch
            {
                return false;
            }

            int bankFee = 30;
            int stateFee = 30;
            int fullTotal = amtDue + bankFee + stateFee;
            
            
            string signature = "David Tabor - Bounce House Check Collection";

            switch (letterNo)
            {
                case 1:
                    {
                        string letterHeading = "Your check number " + checkNo + " in the amount of $" + amtDue + ", dated " + checkDate + ",  has been returned by the bank. We have verified with your bank that there are insufficient funds to pay the check.";
                        string letterBody = "Please replace this check with cash or a money order and pay the required state fee of $30 for a total of $" + (amtDue + stateFee) + " within 14 days per South Carolina Law to avoid further collection action. Since this is your first notice, the bank fee will be waived if payment is recieved within 14 days.";
                        string letterClose = "If you have questions about this, please contact the Bounce House Check Collection office at 864-555-5555 between the hours of 9 and 5."; 
                        

                        HttpContext.Current.Session["letterHeading"] = letterHeading;
                        HttpContext.Current.Session["letterBody"] = letterBody;
                        HttpContext.Current.Session["letterClose"] = letterClose;
                        HttpContext.Current.Session["letterSig"] = signature;
                    }
                    return true;

                case 2:
                    {
                        string letterHeading = "Your check number " + checkNo + " in the amount of $" + amtDue + ", dated " + checkDate + ",  has been returned by the bank. We have verified with your bank that there are insufficient funds to pay the check.";
                        string letterBody = "This is your second notice. Please replace this check with cash or a money order, pay the bank charge of $30, and pay the state fee of $30 for a total of " + fullTotal + " within 10 days per South Carolina Law to avoid further collection action.";
                        string letterClose = "If you have questions about this, please contact the Bounce House Check Collection office at 864-555-5555 between the hours of 9 and 5.";

                        HttpContext.Current.Session["letterHeading"] = letterHeading;
                        HttpContext.Current.Session["letterBody"] = letterBody;
                        HttpContext.Current.Session["letterClose"] = letterClose;
                        HttpContext.Current.Session["letterSig"] = signature;
                    }
                    return true;

                case 3:
                    {
                        string letterHeading = "Your check number " + checkNo + " in the amount of $" + amtDue + ", dated " + checkDate + ",  has been returned by the bank. We have verified with your bank that there are insufficient funds to pay the check.";
                        string letterBody = "This is your third notice. Please replace this check with cash or a money order, pay the bank charge of $30, and pay the state fee of $30 for a total of " + fullTotal + " within 14 days per South Carolina Law to avoid further collection action. If payment is not recieved within 14 days legal action will be taken to the full measure of the law.";
                        string letterClose = "If you have questions about this, please contact the Bounce House Check Collection office at 864-555-5555 between the hours of 9 and 5.";

                        HttpContext.Current.Session["letterHeading"] = letterHeading;
                        HttpContext.Current.Session["letterBody"] = letterBody;
                        HttpContext.Current.Session["letterClose"] = letterClose;
                        HttpContext.Current.Session["letterSig"] = signature;

                    }
                    return true;
                
            }

            //may need to either move StoreID into Check table or write a second Dataset call into the Account table and link the check to the appropriate 
            connection.Close();
            return false;
            
        }
    }
}