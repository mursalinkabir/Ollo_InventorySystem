using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using Ollo_InventorySystem.Models;

namespace Ollo_InventorySystem.Core.Gateway
{
    public class ViewGateway
    {
        private string connectionString =
              WebConfigurationManager.ConnectionStrings["OLLOInventoryDBConnection"].ConnectionString;
        SqlConnection connection = new SqlConnection();
          
        public List<LteRouter> GetAllLteRouters()
        {
          connection.ConnectionString = connectionString;

            string query = "SELECT * FROM LteRouter Order By Id ASC";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<LteRouter> LteRouterList = new List<LteRouter>();
            while (reader.Read())
            {
                LteRouter lteRouter = new LteRouter();
                lteRouter.Id = Convert.ToInt32(reader["Id"].ToString());
                lteRouter.ItemCode = reader["ItemCode"].ToString();
                lteRouter.ItemDescription = reader["ItemDescription"].ToString();
                lteRouter.Batch = reader["Batch"].ToString();
                lteRouter.TagNo = reader["Tag"].ToString();
                lteRouter.SerialNo = reader["Serial"].ToString();
                lteRouter.MacId = reader["Mac"].ToString();
                lteRouter.Imei = reader["Imei"].ToString();
                
                LteRouterList.Add(lteRouter);
            }
            reader.Close();
            connection.Close();
            return LteRouterList;
        }

        public LteRouter GetLteRouterById(double routerId)
        {
            connection.ConnectionString = connectionString;
            string query = "SELECT * FROM LteRouter WHERE Id=@routerId";



            SqlCommand command = new SqlCommand();
            command.CommandText = query;
            command.Connection = connection;
            command.Parameters.Add("routerId", SqlDbType.BigInt);
            command.Parameters["routerId"].Value = routerId;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            LteRouter lteRouter = new LteRouter();
            while (reader.Read())
            {
               
                lteRouter.Id = Convert.ToInt32(reader["Id"].ToString());
                lteRouter.ItemCode = reader["ItemCode"].ToString();
                lteRouter.ItemDescription = reader["ItemDescription"].ToString();
                lteRouter.Batch = reader["Batch"].ToString();
                lteRouter.TagNo = reader["Tag"].ToString();
                lteRouter.SerialNo = reader["Serial"].ToString();
                lteRouter.MacId = reader["Mac"].ToString();
                lteRouter.Imei = reader["Imei"].ToString();

                
            }
            reader.Close();
            connection.Close();
            return lteRouter;
        }
    }
}