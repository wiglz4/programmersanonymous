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
        public static bool Insert(string accountID, string checkPaid, string checkValue, string checkNo, string letterNo, string checkDate)
        {
            try
            {
                OleDbConnection connection = new OleDbConnection(connectionString);
                OleDbCommand cmd = new OleDbCommand(@"Insert Into [Check]([Account ID], [Amount Paid], [Amount Due], [Check Number], [Letter Sent Number], [Check Date]) 
                    Values (@AccountIDParam, @AmountPaidParam, @AmountDueParam, @CheckNoParam, @LetterNoParam, @CheckDateParam)", connection);
                cmd.Parameters.AddWithValue("@AccountIDParam", accountID);
                cmd.Parameters.AddWithValue("@AmountPaidParam", checkPaid);
                cmd.Parameters.AddWithValue("@AmountDueParam", checkValue);
                cmd.Parameters.AddWithValue("@CheckNoParam", checkNo);
                cmd.Parameters.AddWithValue("@LetterNoParam", letterNo);
                cmd.Parameters.AddWithValue("@CheckDateParam", checkDate);
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
        public static bool Update(string accountID, string checkPaid, string checkValue, string checkNo, string letterNo, string checkDate, string accountIDNew, string checkPaidNew, string checkValueNew, string checkNoNew, string letterNoNew, string checkDateNew)
        {
            try
            {

                OleDbConnection connection = new OleDbConnection(connectionString);
                OleDbCommand cmd = new OleDbCommand(@"Update [Check] Set [Account ID] = @AccountIDParamNew, [Amount Paid] = @AmountPaidParamNew, [Amount Due] = @AmountDueParamNew, [Check Number] = @CheckNoParamNew, [Letter Sent Number] = @LetterNoParamNew, [Check Date] = @CheckDateParamNew Where ([Account ID] = @AccountIDParam AND [Amount Paid] = @AmountPaidParam AND [Amount Due] = @AmountDueParam AND [Check Number] = @CheckNoParam AND [Letter Sent Number] = @LetterNoParam AND [Check Date] = @CheckDateParam)", connection);


                cmd.Parameters.AddWithValue("@AccountIDParamNew", accountIDNew);
                cmd.Parameters.AddWithValue("@AmountPaidParamNew", checkPaidNew);
                cmd.Parameters.AddWithValue("@AmountDueParamNew", checkValueNew);
                cmd.Parameters.AddWithValue("@CheckNoParamNew", checkNoNew);
                cmd.Parameters.AddWithValue("@LetterNoParamNew", letterNoNew);
                cmd.Parameters.AddWithValue("@CheckDateParamNew", checkDateNew);

                cmd.Parameters.AddWithValue("@AccountIDParam", accountID);
                cmd.Parameters.AddWithValue("@AmountPaidParam", checkPaid);
                cmd.Parameters.AddWithValue("@AmountDueParam", checkValue);
                cmd.Parameters.AddWithValue("@CheckNoParam", checkNo);
                cmd.Parameters.AddWithValue("@LetterNoParam", letterNo);
                cmd.Parameters.AddWithValue("@CheckDateParam", checkDate);

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        //Method: Delete
        //returns true if records succesfully deleted from database and false otherwise
        //WhereClause is "Where some_column = some_value"
        public static bool Delete(string accountID, string checkPaid, string checkValue, string checkNo, string letterNo, string checkDate)
        {
            try
            {

                OleDbConnection connection = new OleDbConnection(connectionString);
                OleDbCommand cmd = new OleDbCommand(@"Delete From [Check] Where ([Account ID] = @AccountIDParam AND [Amount Paid] = @AmountPaidParam AND [Amount Due] = @AmountDueParam 
                AND [Check Number] = @CheckNoParam AND [Letter Sent Number] = @LetterNoParam AND [Check Date] = @CheckDateParam)", connection);
                cmd.Parameters.AddWithValue("@AccountIDParam", accountID);
                cmd.Parameters.AddWithValue("@AmountPaidParam", checkPaid);
                cmd.Parameters.AddWithValue("@AmountDueParam", checkValue);
                cmd.Parameters.AddWithValue("@CheckNoParam", checkNo);
                cmd.Parameters.AddWithValue("@LetterNoParam", letterNo);
                cmd.Parameters.AddWithValue("@CheckDateParam", checkDate);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //METHOD: Query
        //returns Dataset
        public static DataSet SpecificQuery(string accountID, string checkPaid, string checkValue, string checkNo, string letterNo, string checkDate)
        {
            DataSet ds = new DataSet();
            
            
                OleDbConnection connection = new OleDbConnection(connectionString);
                OleDbCommand cmd = new OleDbCommand(@"Select * FROM [Check] Where ([Account ID] = @AccountIDParam AND [Amount Paid] = @AmountPaidParam AND [Amount Due] = @AmountDueParam 
                AND [Check Number] = @CheckNoParam AND [Letter Sent Number] = @LetterNoParam AND [Check Date] = @CheckDateParam)", connection);
                cmd.Parameters.AddWithValue("@AccountIDParam", accountID);
                cmd.Parameters.AddWithValue("@AmountPaidParam", checkPaid);
                cmd.Parameters.AddWithValue("@AmountDueParam", checkValue);
                cmd.Parameters.AddWithValue("@CheckNoParam", checkNo);
                cmd.Parameters.AddWithValue("@LetterNoParam", letterNo);
                cmd.Parameters.AddWithValue("@CheckDateParam", checkDate);
                
                connection.Open();
                OleDbDataAdapter adapter = new OleDbDataAdapter(cmd); 
                adapter.Fill(ds);
                connection.Close();
                return ds;
        }

        public static DataSet Query(string checkNo)
        {
            DataSet ds = new DataSet();


            OleDbConnection connection = new OleDbConnection(connectionString);
            OleDbCommand cmd = new OleDbCommand(@"Select * FROM [Check] WHERE ([Check Number] = @checkNo)", connection);
            cmd.Parameters.AddWithValue("@checkNo", checkNo);

            connection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(ds);
            connection.Close();
            return ds;
        }

    }
}