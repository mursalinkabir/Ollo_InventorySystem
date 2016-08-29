using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ollo_InventorySystem.Core.BLL;


namespace Ollo_InventorySystem.Controllers
{

    public class ViewItemsController : Controller
    {
         ViewManager viewManager = new ViewManager();
        // GET: ViewItems
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewLteRouters()
        {
            ViewBag.LteRouters = viewManager.GetAllLteRouters();
            return View();
        }
    }
}