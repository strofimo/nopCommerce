using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Core.Data;
using Nop.Services.Catalog;
using Nop.Plugin.Misc.StockPricePerStore.Services;
using Nop.Plugin.Misc.StockPricePerStore.Domain;

namespace Nop.Plugin.Misc.ProductInventory.Services
{
    public class StockProductService : IStockProductService
    {
        private IRepository<ProductInventoryFieldRecord> repository;
        private IProductService productService;
        public StockProductService(IRepository<ProductInventoryFieldRecord> repository, IProductService productService)
        {
            this.repository = repository;
            this.productService = productService;
        }

        public void Delete(int productId, int storeId)
        {
            var rec = repository.Table.FirstOrDefault(n => n.StoreId == storeId && n.ProductId == productId);
            if (rec != null)
            {
                repository.Delete(rec);
            }
        }

        public ProductInventoryFieldRecord GetByStore(int productId, int? storeId)
        {
            return this.repository.Table.FirstOrDefault(n => n.ProductId == productId && n.StoreId == storeId);
        }

        public ProductInventoryFieldRecord GetByStoreOrDefault(int productId, int? storeId)
        {
            if (storeId.HasValue)
            {
                var result = this.repository.Table.FirstOrDefault(n => n.ProductId == productId && n.StoreId == storeId);
                if (result == null)
                {
                    return GetDefault(productId);
                }
                return result;
            }
            else
            {
                return GetDefault(productId);
            }
        }

        public void CreateOrUpdate(ProductInventoryFieldRecord data)
        {
            var result = this.repository.Table.FirstOrDefault(n => n.ProductId == data.ProductId && n.StoreId == data.StoreId);
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
                this.repository.Update(result);
            }
            else
            {
                this.repository.Insert(result);
            }
        }

        private ProductInventoryFieldRecord GetDefault(int productId)
        {
            var result = new ProductInventoryFieldRecord();
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
            return result;
        }

        public List<ProductInventoryFieldRecord> GetByProductIdsAndStoreId(List<int> productIds, int storeId)
        {
            return repository.Table.Where(n => productIds.Contains(n.ProductId) && n.StoreId == storeId).ToList();
        }
    }
}
