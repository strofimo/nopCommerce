using Nop.Plugin.Misc.PricePerStore.Domain;

namespace Nop.Plugin.Misc.PricePerStore.Services
{
    public interface IStoreProductService
    {
        ProductPriceFieldRecord GetByStoreOrDefault(int productId, int? storeId);

        ProductPriceFieldRecord GetByStore(int productId, int? storeId);
        void CreateUpdatePricePerStore(ProductPriceFieldRecord data);

        void RemovePricePerStore(int productId, int storeId);
    }
}