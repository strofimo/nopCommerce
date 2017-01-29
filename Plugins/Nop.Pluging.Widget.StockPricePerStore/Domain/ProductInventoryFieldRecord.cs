using Nop.Core;
using Nop.Web.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Misc.StockPricePerStore.Domain
{
    public class ProductInventoryFieldRecord: BaseEntity
    {
        [NopResourceDisplayName("Nop.Plugin.Misc.StockPricePerStore.StoreWarehouseId")]
        public int StoreWarehouseId { get; set; }
        [NopResourceDisplayName("Nop.Plugin.Misc.StockPricePerStore.StoreStockQuantity")]
        public int StoreStockQuantity { get; set; }
        [NopResourceDisplayName("Nop.Plugin.Misc.StockPricePerStore.StoreDisplayStockAvailability")]
        public bool StoreDisplayStockAvailability { get; set; }
        [NopResourceDisplayName("Nop.Plugin.Misc.StockPricePerStore.StoreMinStockQuantity")]
        public int StoreMinStockQuantity { get; set; }
        [NopResourceDisplayName("Nop.Plugin.Misc.StockPricePerStore.StoreLowStockActivityId")]
        public int StoreLowStockActivityId { get; set; }
        [NopResourceDisplayName("Nop.Plugin.Misc.StockPricePerStore.StoreNotifyAdminForQuantityBelow")]
        public int StoreNotifyAdminForQuantityBelow { get; set; }
        [NopResourceDisplayName("Nop.Plugin.Misc.StockPricePerStore.StoreBackorderModeId")]
        public int StoreBackorderModeId { get; set; }
        [NopResourceDisplayName("Nop.Plugin.Misc.StockPricePerStore.StoreOrderMinimumQuantity")]
        public int StoreOrderMinimumQuantity { get; set; }
        [NopResourceDisplayName("Nop.Plugin.Misc.StockPricePerStore.StoreOrderMaximumQuantity")]
        public int StoreOrderMaximumQuantity { get; set; }
        [NopResourceDisplayName("Nop.Plugin.Misc.StockPricePerStore.StoreAllowedQuantities")]
        public string StoreAllowedQuantities { get; set; }
        [NopResourceDisplayName("Nop.Plugin.Misc.StockPricePerStore.StoreDisplayStockQuantity")]
        public bool StoreDisplayStockQuantity { get; set; }
        [NopResourceDisplayName("Nop.Plugin.Misc.StockPricePerStore.StoreAllowBackInStockSubscriptions")]
        public bool StoreAllowBackInStockSubscriptions { get; set; }
        public int ProductId { get; set; }
        public int StoreId { get; set; }
    }
}
