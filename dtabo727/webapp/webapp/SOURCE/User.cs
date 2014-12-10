using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using webapp.SOURCE;
using webapp;

namespace webapp.SOURCE
{
    //class is abstract so it doesnt need a constructor and can be called using a statement such as
    //Check.Method();
    abstract class User
    {
        static String connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;


        
        //Method: Insert
        //returns true if succesfully inserted into database and false otherwise
        //number of columns must match number of values
        //columns and values formatted as "col1,col2,col3" "val1,val2,val3"
        public static bool Insert(string storeID, string compID, string fName, string lName, string uName, string pass, int priv)
        {
            try
            {
                OleDbConnection connection = new OleDbConnection(connectionString);
                OleDbCommand cmd = new OleDbCommand(@"Insert Into [User]([Store ID], [Company ID], [First Name], [Last Name], [Username], [Password], [Privelege]) 
                    Values (@StoreIDParam, @CompanyIDParam, @FNameParam, @LNameParam, @UsernameParam, @PasswordParam, @PrivilegeParam)", connection);
                cmd.Parameters.AddWithValue("@StoreIDParam", storeID);
                cmd.Parameters.AddWithValue("@CompanyIDParam", compID);
                cmd.Parameters.AddWithValue("@FNameParam", fName);
                cmd.Parameters.AddWithValue("@LNameParam", lName);
                cmd.Parameters.AddWithValue("@UsernameParam", uName);
                cmd.Parameters.AddWithValue("@PasswordParam", pass);
                cmd.Parameters.AddWithValue("@PrivilegeParam", priv);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception e)
            {
                if (e.Message == @"The changes you requested to the table were not successful because they would create duplicate 
                values in the index, primary key, or relationship.  Change the data in the field or fields that contain duplicate 
                data, remove the index, or redefine the index to permit duplicate entries and try again.")
                {
                    //it won't let you insert if there is a duplicate record. doesn't mean somethin blew up
                    return true;
                }
                else
                {
                    //somethin blew up
                    return false;
                }
            }

        }

        //METHOD: Update
        //returns true if update is successfully completed and false otherwise
        //Assignments is "column1=value1,column2=value2"
        //WhereClause is "Where some_column = some_value"
        public static bool Update(string Assignments, string WhereClause)
        {
            OleDbConnection connection = new OleDbConnection(connectionString);
            OleDbCommand cmd = new OleDbCommand("Update [User] Set " + Assignments + " " + WhereClause, connection);
            int result = cmd.ExecuteNonQuery();
            connection.Close();

            if (result == 0) return true;
            else return false; 
        }

        //Method: Delete
        //returns true if records succesfully deleted from database and false otherwise
        //WhereClause is "Where some_column = some_value"
        public static bool Delete(string WhereClause)
        {
            OleDbConnection connection = new OleDbConnection(connectionString);
            OleDbCommand cmd = new OleDbCommand("Delete From [User] " + WhereClause, connection);

            int result = cmd.ExecuteNonQuery();
            connection.Close();

            if (result == 0) return true;
            else return false; 
        }

        //METHOD: Query
        //returns Dataset
        public static DataSet Query(string WhereClause)
        {
            DataSet ds = new DataSet();

            // Connect to the database and run the query.
            OleDbConnection connection = new OleDbConnection(connectionString);
            OleDbCommand cmd = new OleDbCommand("Select * From [User]" + WhereClause, connection);
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);

            // Fill the DataSet.
            adapter.Fill(ds);
            connection.Close();

            return ds;
        }

        //METHOD: Login
        //returns string error message
        public static bool Login(string uName, string pWord, string cID)
        {
            OleDbConnection connection = new OleDbConnection(connectionString);
            
            // pull data and run the query.
            OleDbCommand cmd = new OleDbCommand("Select * From [User] Where (Username = @uName) And (Password = @pWord) And ([Company ID] = @cID)", connection);
            cmd.Parameters.AddWithValue("@uName", uName);
            cmd.Parameters.AddWithValue("@pWord", pWord);
            cmd.Parameters.AddWithValue("@cID", cID);
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);

            DataSet ds = new DataSet();
            adapter.Fill(ds);

            // verify username and password
            if (ds.Tables[0].Rows.Count == 0)
            {
                //credentials were wrong
                return false;
            }
            else if (ds.Tables[0].Rows.Count == 1)
            {
                //congratulations login is succesful
                return true;
            }
            else
            {
                //"Error: More than one record of this user exists. Please contact your system administrator.";
                return false;
            }
        }

        //METHOD: getPrivilege
        //returns Int
        public static int getPrivilege()
        {
            string uName = "";
                string pWord = "";
                string cID = "";
            try
            {

                uName = HttpContext.Current.Session["uName"].ToString();
                pWord = HttpContext.Current.Session["pWord"].ToString();
                cID = HttpContext.Current.Session["cID"].ToString();

            }
                // ctches a bad login (between two server instances and will redirect to force login)
            catch (Exception e)
            {
                if (e.Message == "Object reference not set to an instance of an object.")
                {
                    System.Web.Security.FormsAuthentication.SignOut();
                    HttpContext.Current.Response.Redirect("~/Account/login.aspx", true);
                }
            }

            // Connect to the database and run the query.
            OleDbConnection connection = new OleDbConnection(connectionString);
            OleDbCommand cmd = new OleDbCommand("Select * From [User] Where (Username = @uName) And (Password = @pWord) And ([Company ID] = @cID)", connection);
            cmd.Parameters.AddWithValue("@uName", uName);
            cmd.Parameters.AddWithValue("@pWord", pWord);
            cmd.Parameters.AddWithValue("@cID", cID);
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);

            // Fill the DataSet.
            DataSet ds = new DataSet();
            adapter.Fill(ds);

            int privilege = int.Parse(ds.Tables[0].Rows[0][7].ToString());
            connection.Close();
            return privilege;
        }
        
        
    }
}