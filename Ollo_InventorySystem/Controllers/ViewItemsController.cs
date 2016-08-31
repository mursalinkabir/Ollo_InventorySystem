using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ollo_InventorySystem.Core.BLL;
using Ollo_InventorySystem.Models;


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

        public ActionResult EditLteRouter(double Id)
        {
            LteRouter lteRouter = new LteRouter();
            lteRouter = viewManager.GetLteRouterById(Id);
            return View(lteRouter);
        }

        [HttpPost]
        public ActionResult EditLteRouter(LteRouter lterouter)
        {
            ViewBag.Message = viewManager.ModifyLteRouterInfo(lterouter);
            return View();
        }
    }
}