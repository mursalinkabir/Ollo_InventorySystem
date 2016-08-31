using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Ollo_InventorySystem.Core.Gateway
{
    public class ImportGateway
    {
        private string connectionString =
            WebConfigurationManager.ConnectionStrings["OLLOInventoryDBConnection"].ConnectionString;
        SqlConnection connection = new SqlConnection();
        public int AddDataintoDB(string finalQueryString, string finalQueryString2)
        {
            connection.ConnectionString = connectionString;
            string query = finalQueryString;
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();

            //for movement table
            string query2 = finalQueryString2;
            SqlCommand command2 = new SqlCommand(query2, connection);
            connection.Open();
            int rowAffected2 = command2.ExecuteNonQuery();
            connection.Close();

            return rowAffected;
        }
    }
}