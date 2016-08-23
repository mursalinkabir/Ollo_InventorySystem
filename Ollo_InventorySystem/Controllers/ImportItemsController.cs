using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ollo_InventorySystem.Core.BLL;

namespace Ollo_InventorySystem.Controllers
{
    public class ImportItemsController : Controller
    {
        // GET: ImportItems
        ImportManager impManager = new ImportManager();
        public ActionResult Index()
        {
            return View();
        }

        // Lte Router Serial tracking import
        public ActionResult LteRouterImport()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LteRouterImport(HttpPostedFileBase file)
        {
            string fileFullPath = "";
            if (file != null && file.ContentLength > 0)
                try
                {
                    //its getting the url of server folder path VendorFiles and merging with the File Name to get full url
                    string path = Path.Combine(Server.MapPath("~/VendorFiles"),
                                               Path.GetFileName(file.FileName));
                    fileFullPath = path;
                    file.SaveAs(path);
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
            else
            {
                ViewBag.Message = "You have not specified a file.";
            }

            bool isDataInserted = impManager.ReadExcelFile(fileFullPath);
            if (isDataInserted)
            {
                ViewBag.Message = "File Added to DB successfully";
            }
            else
            {
                ViewBag.Message = "File Adding to DB Failed";

            }



            return View();
        }



    }
}