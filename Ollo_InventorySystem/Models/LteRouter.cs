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
        public string TagNo { get; set; }
        public string SerialNo { get; set; }
        public string MacId { get; set; }
        public string Imei { get; set; }
    }
}