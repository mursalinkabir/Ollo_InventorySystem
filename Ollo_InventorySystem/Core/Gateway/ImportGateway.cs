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
        public int AddDataintoDB(string finalQueryString)
        {
            connection.ConnectionString = connectionString;
            string query = finalQueryString;
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }
    }
}