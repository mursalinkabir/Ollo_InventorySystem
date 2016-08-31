using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ollo_InventorySystem.Core.Gateway;
using Ollo_InventorySystem.Models;

namespace Ollo_InventorySystem.Core.BLL
{
    public class ViewManager
    {
        ViewGateway viewGateway = new ViewGateway();
        public List<LteRouter> GetAllLteRouters()
        {
            return viewGateway.GetAllLteRouters();
        }

        public LteRouter GetLteRouterById(double Id)
        {
            return viewGateway.GetLteRouterById(Id);
        }

        public string ModifyLteRouterInfo(LteRouter lterouter)
        {
            if (viewGateway.ModifyLteRouterInfo(lterouter)>0)
            {
                return "Item Updated Successful";
            }
            return "Item Update Failed";
        }
    }
}