using Nop.Plugin.Misc.StockPricerPerStore.Domain;

namespace Nop.Plugin.Misc.StockPricerPerStore.Services
{
    public interface IStoreProductService
    {
        ProductPriceFieldRecord GetByStoreOrDefault(int productId, int? storeId);
        ProductPriceFieldRecord GetByStore(int productId, int? storeId);
        void CreateUpdateStockPricerPerStore(ProductPriceFieldRecord data);
        void RemoveStockPricerPerStore(int productId, int storeId);
    }
}