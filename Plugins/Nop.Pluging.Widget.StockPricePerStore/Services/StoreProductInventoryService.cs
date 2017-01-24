using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Core.Data;
using Nop.Services.Catalog;
using Nop.Plugin.Misc.StockPricerPerStore.Services;
using Nop.Plugin.Misc.StockPricerPerStore.Domain;

namespace Nop.Plugin.Misc.ProductInventory.Services
{
    public class StoreProductInventoryService : IStoreProductInventoryService
    {
        private IRepository<ProductInventoryFieldRecord> service;
        private IProductService productService;
        public StoreProductInventoryService(IRepository<ProductInventoryFieldRecord> service, IProductService productService)
        {
            this.service = service;
            this.productService = productService;
        }

        public void Delete(int productId, int storeId)
        {
            var rec = service.Table.FirstOrDefault(n => n.StoreId == storeId && n.ProductId == productId);
            service.Delete(rec);
        }


        public ProductInventoryFieldRecord GetByStoreOrDefault(int productId, int storeId)
        {
            var result = this.service.Table.FirstOrDefault(n => n.ProductId == productId && n.StoreId == storeId);
            if (result == null)
            {
                result = new ProductInventoryFieldRecord();
                var product = this.productService.GetProductById(productId);
                result.StoreAllowedQuantities = product.AllowedQuantities;
                result.StoreBackorderModeId = product.BackorderModeId;
                result.StoreDisplayStockAvailability = product.DisplayStockAvailability;
                result.StoreLowStockActivityId = product.LowStockActivityId;
                result.StoreMinStockQuantity = product.MinStockQuantity;
                result.StoreNotifyAdminForQuantityBelow = product.NotifyAdminForQuantityBelow;
                result.StoreOrderMaximumQuantity = product.OrderMaximumQuantity;
                result.StoreOrderMinimumQuantity = product.OrderMinimumQuantity;
                result.StoreStockQuantity = product.StockQuantity;
                result.StoreWarehouseId = product.WarehouseId;
                result.ProductId = productId;
                result.StoreId = storeId;
            }
            return result;
        }

        public void CreateOrUpdate(ProductInventoryFieldRecord data)
        {
            var result = this.service.Table.FirstOrDefault(n => n.ProductId == data.ProductId && n.StoreId == data.StoreId);
            if (result == null)
            {
                result = new ProductInventoryFieldRecord();
            }
            result.StoreAllowedQuantities = data.StoreAllowedQuantities;
            result.StoreBackorderModeId = data.StoreBackorderModeId;
            result.StoreDisplayStockAvailability = data.StoreDisplayStockAvailability;
            result.StoreLowStockActivityId = data.StoreLowStockActivityId;
            result.StoreMinStockQuantity = data.StoreMinStockQuantity;
            result.StoreNotifyAdminForQuantityBelow = data.StoreNotifyAdminForQuantityBelow;
            result.StoreOrderMaximumQuantity = data.StoreOrderMaximumQuantity;
            result.StoreOrderMinimumQuantity = data.StoreOrderMinimumQuantity;
            result.StoreStockQuantity = data.StoreStockQuantity;
            result.StoreWarehouseId = data.StoreWarehouseId;
            result.StoreDisplayStockQuantity = data.StoreDisplayStockQuantity;
            result.StoreAllowBackInStockSubscriptions = data.StoreAllowBackInStockSubscriptions;
            result.ProductId = data.ProductId;
            result.StoreId = data.StoreId;

            if (result.Id != 0)
            {
                this.service.Update(result);
            }
            else
            {
                this.service.Insert(result);
            }
        }
    }
}
