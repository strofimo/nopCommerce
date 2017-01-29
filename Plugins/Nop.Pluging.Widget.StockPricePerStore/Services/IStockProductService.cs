using Nop.Plugin.Misc.StockPricePerStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Misc.StockPricePerStore.Services
{
    public interface IStockProductService
    {
        ProductInventoryFieldRecord GetByStoreOrDefault(int productId,int? storeId);
        void CreateOrUpdate(ProductInventoryFieldRecord data);
        void Delete(int productId, int storeId);
        List<ProductInventoryFieldRecord> GetByProductIdsAndStoreId(List<int> productIds, int storeId);
        ProductInventoryFieldRecord GetByStore(int productId, int? storeId);
    }
}
