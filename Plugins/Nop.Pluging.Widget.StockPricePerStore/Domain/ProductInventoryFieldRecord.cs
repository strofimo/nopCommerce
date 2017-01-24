using Nop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Misc.StockPricerPerStore.Domain
{
    public class ProductInventoryFieldRecord: BaseEntity
    {
        public int StoreWarehouseId { get; set; }
        public int StoreStockQuantity { get; set; }
        public bool StoreDisplayStockAvailability { get; set; }
        public int StoreMinStockQuantity { get; set; }
        public int StoreLowStockActivityId { get; set; }
        public int StoreNotifyAdminForQuantityBelow { get; set; }
        public int StoreBackorderModeId { get; set; }
        public int StoreOrderMinimumQuantity { get; set; }
        public int StoreOrderMaximumQuantity { get; set; }
        public string StoreAllowedQuantities { get; set; }
        public bool StoreDisplayStockQuantity { get; set; }
        public bool StoreAllowBackInStockSubscriptions { get; set; }
        public int ProductId { get; set; }
        public int StoreId { get; set; }
    }
}
