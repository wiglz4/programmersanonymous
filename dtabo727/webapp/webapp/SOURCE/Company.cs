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
    abstract class Company
    {
        static String connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        //Method: Insert
        //returns true if succesfully inserted into database and false otherwise
        //number of columns must match number of values
        //columns and values formatted as "col1,col2,col3" "val1,val2,val3"
        public static bool Insert(string compID, string compName, string compStreet, string compCity, string compState, string compZip)
        {
            try
            {
                OleDbConnection connection = new OleDbConnection(connectionString);
                OleDbCommand cmd = new OleDbCommand(@"Insert Into [Company]([Company ID], [Company Name], [Street], [City], [State], [Zipcode]) 
                    Values (@CompanyIDParam, @CompanyNameParam, @StreetParam, @CityParam, @StateParam, @ZipcodeParam)", connection);
                cmd.Parameters.AddWithValue("@CompanyIDParam", compID);
                cmd.Parameters.AddWithValue("@CompanyNameParam", compName);
                cmd.Parameters.AddWithValue("@StreetParam", compStreet);
                cmd.Parameters.AddWithValue("@CityParam", compCity);
                cmd.Parameters.AddWithValue("@StateParam", compState);
                cmd.Parameters.AddWithValue("@ZipcodeParam", compZip);
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
            OleDbCommand cmd = new OleDbCommand("Update [Company] Set " + Assignments + " " + WhereClause, connection);
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
            OleDbCommand cmd = new OleDbCommand("Delete From [Company] " + WhereClause, connection);

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
            OleDbCommand cmd = new OleDbCommand("Select * From [Company]" + WhereClause, connection);
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);

            // Fill the DataSet.
            adapter.Fill(ds);
            connection.Close();

            return ds;
        }

    }
}