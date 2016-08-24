using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ollo_InventorySystem.Controllers
{
    public class ViewItemsController : Controller
    {
        // GET: ViewItems
        public ActionResult Index()
        {
            return View();
        }
    }
}