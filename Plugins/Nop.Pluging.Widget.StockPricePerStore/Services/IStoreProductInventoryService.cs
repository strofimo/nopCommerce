using Nop.Plugin.Misc.StockPricerPerStore.Domain;
using Nop.Plugin.Misc.ProductInventory.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Misc.StockPricerPerStore.Services
{
    public interface IStoreProductInventoryService
    {
        ProductInventoryFieldRecord GetByStoreOrDefault(int productId,int storeId);
        void CreateOrUpdate(ProductInventoryFieldRecord data);
        void Delete(int productId, int storeId);
    }
}
