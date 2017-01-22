using Nop.Plugin.Misc.StoreProductInventory.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Misc.StoreProductInventory.Data
{
    public class StoreProductInventoryFieldMap : EntityTypeConfiguration<StoreProductInventoryFieldRecord>
    {
        public StoreProductInventoryFieldMap()
        {
            ToTable("InventoryPerStore_Product");
            HasKey(n => n.Id);
            Property(n => n.StoreAllowedQuantities);
            Property(n => n.StoreBackorderModeId);
            Property(n => n.StoreDisplayStockAvailability);
            Property(n => n.StoreLowStockActivityId);
            Property(n => n.StoreMinStockQuantity);
            Property(n => n.StoreNotifyAdminForQuantityBelow);
            Property(n => n.StoreOrderMaximumQuantity);
            Property(n => n.StoreOrderMinimumQuantity);
            Property(n => n.StoreStockQuantity);
            Property(n => n.StoreWarehouseId);
            Property(n => n.StoreAllowBackInStockSubscriptions);
            Property(n =>n.StoreDisplayStockQuantity);
            Property(n => n.ProductId);
            Property(n => n.StoreId);
        }
    }
}
