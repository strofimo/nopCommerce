using Nop.Plugin.Misc.StockPricerPerStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Nop.Plugin.Misc.ProductInventory.ViewModels
{
    public class StoreProductInventoryViewModel
    {
        public List<SelectListItem> WarehouseList { get; set; }

        public ProductInventoryFieldRecord Record { get; set; }
        public string StoresJson { get; internal set; }
    }
}
