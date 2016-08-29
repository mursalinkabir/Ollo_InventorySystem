using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
    }
}