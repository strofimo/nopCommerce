using Nop.Plugin.Misc.StockPricePerStore.Domain;
using System.Collections.Generic;

namespace Nop.Plugin.Misc.StockPricePerStore.Services
{
    public interface IPriceProductService
    {
        ProductPriceFieldRecord GetByStoreOrDefault(int productId, int? storeId);
        ProductPriceFieldRecord GetByStore(int productId, int? storeId);
        void CreateUpdateStockPricePerStore(ProductPriceFieldRecord data);
        void RemoveStockPricePerStore(int productId, int storeId);
        List<ProductPriceFieldRecord> GetByProductIdsAndStoreId(List<int> productIds, int storeId);
    }
}