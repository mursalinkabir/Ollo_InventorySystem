using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ollo_InventorySystem.Models
{
    public class LteRouter
    {
        public double Id { get; set; }
        public string ItemCode { get; set; }
        public string ItemDescription { get; set; }
        public string Batch { get; set; }
        public string Tag { get; set; }
        public string Serial { get; set; }
        public string Mac { get; set; }
        public string Imei { get; set; }
        public string Location  { get; set; }
        public string Remarks { get; set; }
    }
}