using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using Excel;
using Ollo_InventorySystem.Core.Gateway;

namespace Ollo_InventorySystem.Core.BLL
{
    public class ImportManager
    {
        ImportGateway importGateway = new ImportGateway();
        public bool ReadExcelFile(string fileFullPath)
        {
            string LongQueryString = "INSERT INTO LteRouter ( ItemCode, ItemDescription, Batch , Tag , Serial , Mac , Imei,ImportTime ) VALUES ";
            string LongQueryString2 = "INSERT INTO RouterMovement ( RouterImei,RouterDescription , Location , LocationStatus , MovementDate ) VALUES ";
            int isDataAdded = 0;
            if (fileFullPath != "")
            {

                FileStream stream = File.Open(@fileFullPath, FileMode.Open, FileAccess.Read);
                IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

                excelReader.IsFirstRowAsColumnNames = true;

                DataSet result = excelReader.AsDataSet();
                foreach (DataRow row in result.Tables["Sheet1"].Rows)
                {
                    string Item_code, Item_description, Batch, Tag_no, Serial_no, Mac_id, Imei_code, ImportTime, Location, LocationStatus;

                    Item_code = Item_description = Batch = Tag_no = Serial_no = Mac_id = Imei_code = ImportTime = Location = LocationStatus = "";
                    //if ((!string.IsNullOrEmpty(row["Item-Code"].ToString())) & (!string.IsNullOrEmpty(row["Item-Description"].ToString())) & (!string.IsNullOrEmpty(row["Batch"].ToString())) & (!string.IsNullOrEmpty(row["Tag-No"].ToString())) & (!string.IsNullOrEmpty(row["Serial-No"].ToString())) & (!string.IsNullOrEmpty(row["MAC-ID"].ToString())) & (!string.IsNullOrEmpty(row["IMEI-Code"].ToString())) )
                    //{
                        Item_code = "'" + row["Item-Code"].ToString() + "'";
                        Item_description = "'" + row["Item-Description"].ToString() +"'";
                        Batch = "'" + row["Batch"].ToString() + "'";
                        Tag_no = "'" + row["Tag-No"].ToString() + "'";
                        Serial_no = "'" + row["Serial-No"].ToString() + "'";
                        Mac_id = "'" + row["MAC-ID"].ToString() + "'";
                        Imei_code = "'" + row["IMEI-Code"].ToString() + "'";
                        ImportTime =  "'" + DateTime.Now + "'";
                        Location = "'" + row["Location"].ToString() + "'";
                        LocationStatus = "'" + "Active" + "'";

                    LongQueryString = LongQueryString + "( " + Item_code + "," + Item_description +
                                      "," + Batch +
                                      "," + Tag_no +
                                      "," + Serial_no +
                                      "," + Mac_id +
                                      "," + Imei_code +
                                      "," + ImportTime +
                                      " ),";
                    LongQueryString2 = LongQueryString2 + "( " + Imei_code +"," + Item_description +
                                          "," + Location +
                                          "," + LocationStatus +
                                          "," + ImportTime +
                                          " ),";

                }
                string finalQueryString = LongQueryString.Remove(LongQueryString.Length -1); //removing last comma
                string finalQueryString2 = LongQueryString2.Remove(LongQueryString2.Length - 1); //removing last comma
                isDataAdded = isDataAdded + importGateway.AddDataintoDB(finalQueryString, finalQueryString2);
                

                if (isDataAdded > 0)
                {
                    return true;
                }

            }

            return false;
        }
    }
}