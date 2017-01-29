using Nop.Plugin.Misc.StockPricePerStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nop.Plugin.Misc.StockPricePerStore.ViewModels
{
    public class StockPricePerStoreViewModel
    {
        public int ProductId { get; set; }
        public int StoreId { get; set; }
        public List<SelectListItem> WarehouseList { get; set; }
        public bool ExistsPriceRecord { get { return PriceRecord.Id != 0; } }
        public bool ExistsStockRecord { get { return StockRecord.Id != 0; } }
        public ProductPriceFieldRecord PriceRecord { get; set; }
        public ProductInventoryFieldRecord StockRecord { get; set; }
    }
}