using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
using System.Configuration;

namespace webapp
{
    //class is abstract so it doesnt need a constructor and can be called using a statement such as
    //Check.Method();
    abstract class Check
    {
        static String connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        //Method: insert
        //returns true if succesfully inserted into database and false otherwise
        public static bool Insert(string Values)
        {

            return false;
        }

        //Method: delete
        //returns true if succesfully inserted into database and false otherwise
        public static bool Delete()
        {
            return false;

        }

        public static DataSet Query(string WhereClause)
        {
            DataSet ds = new DataSet();

            // Connect to the database and run the query.
            OleDbConnection connection = new OleDbConnection(connectionString);
            OleDbCommand cmd = new OleDbCommand("Select * From [Check]" + WhereClause, connection);
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);

            // Fill the DataSet.
            adapter.Fill(ds);

            return ds;
        }

    }
}