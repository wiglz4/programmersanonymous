using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
using System.Configuration;

namespace webapp.SOURCE
{
    //class is abstract so it doesnt need a constructor and can be called using a statement such as
    //Check.Method();
    abstract class Check
    {
        static String connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        //Method: Insert
        //returns true if succesfully inserted into database and false otherwise
        public static bool Insert(string accountID, string checkValue, string checkNo)
        {
            try
            {
                OleDbConnection connection = new OleDbConnection(connectionString);
                OleDbCommand cmd = new OleDbCommand("Insert Into [Check]([Account ID], [Amount Paid], [Amount Due], [Check Number], [Letter Sent Number]) Values (@AccountIDParam, @AmountPaidParam, @AmountDueParam, @CheckNoParam, @LetterNoParam)", connection);
                cmd.Parameters.AddWithValue("@AccountIDParam", accountID);
                cmd.Parameters.AddWithValue("@AmountPaidParam", "0.00");
                cmd.Parameters.AddWithValue("@AmountDueParam", checkValue);
                cmd.Parameters.AddWithValue("@CheckNoParam", checkNo);
                cmd.Parameters.AddWithValue("@LetterNoParam", '0');
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch
            {
                //somethin blew up
                return false;
            }

        }

        //METHOD: Update
        //returns true if update is successfully completed and false otherwise
        //Assignments is "column1=value1,column2=value2"
        //WhereClause is "Where some_column = some_value"
        public static bool Update(string Assignments, string WhereClause)
        {
            OleDbConnection connection = new OleDbConnection(connectionString);
            OleDbCommand cmd = new OleDbCommand("Update [Check] Set " + Assignments + " " + WhereClause, connection);
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
            OleDbCommand cmd = new OleDbCommand("Delete From [Check] " + WhereClause, connection);

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
            OleDbCommand cmd = new OleDbCommand("Select * From [Check] " + WhereClause, connection);
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);

            // Fill the DataSet.
            adapter.Fill(ds);
            connection.Close();

            return ds;
        }

    }
}