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

          string query = "SELECT LteRouter.Id,ItemCode,ItemDescription,Batch,Tag,Serial,Mac,Imei,Location,Remarks FROM LteRouter INNER JOIN RouterMovement ON Imei= RouterImei Order By LteRouter.Id DESC";
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
                lteRouter.Tag = reader["Tag"].ToString();
                lteRouter.Serial = reader["Serial"].ToString();
                lteRouter.Mac = reader["Mac"].ToString();
                lteRouter.Imei = reader["Imei"].ToString();
                lteRouter.Location = reader["Location"].ToString();
                lteRouter.Remarks = reader["Remarks"].ToString();
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
                lteRouter.Tag = reader["Tag"].ToString();
                lteRouter.Serial = reader["Serial"].ToString();
                lteRouter.Mac = reader["Mac"].ToString();
                lteRouter.Imei = reader["Imei"].ToString();

                
            }
            reader.Close();
            connection.Close();
            return lteRouter;
        }

        public int ModifyLteRouterInfo(LteRouter lterouter)
        {
            connection.ConnectionString = connectionString;
            string query = "UPDATE LteRouter SET ItemCode=@ItemCode,Batch=@Batch,Imei=@Imei,ItemDescription=@ItemDescription,Mac=@Mac,Serial=@Serial,Tag=@Tag   WHERE Id=@Id";



            SqlCommand command = new SqlCommand();
            command.CommandText = query;
            command.Connection = connection;
            command.Parameters.Add("Id", SqlDbType.BigInt);
            command.Parameters["Id"].Value = lterouter.Id;

            command.Parameters.Add("ItemCode", SqlDbType.NVarChar);
            command.Parameters["ItemCode"].Value = lterouter.ItemCode;

            command.Parameters.Add("Batch", SqlDbType.NVarChar);
            command.Parameters["Batch"].Value = lterouter.Batch;

            command.Parameters.Add("Imei", SqlDbType.NVarChar);
            command.Parameters["Imei"].Value = lterouter.Imei;

            command.Parameters.Add("ItemDescription", SqlDbType.NVarChar);
            command.Parameters["ItemDescription"].Value = lterouter.ItemDescription;

            command.Parameters.Add("Mac", SqlDbType.NVarChar);
            command.Parameters["Mac"].Value = lterouter.Mac;

            command.Parameters.Add("Serial", SqlDbType.NVarChar);
            command.Parameters["Serial"].Value = lterouter.Serial;

            command.Parameters.Add("Tag", SqlDbType.NVarChar);
            command.Parameters["Tag"].Value = lterouter.Tag;
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }
    }
}