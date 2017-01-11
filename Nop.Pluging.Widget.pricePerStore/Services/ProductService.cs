using Nop.Core.Data;
using Nop.Data;
using Nop.Plugin.Misc.PricePerStore.Domain;
using Nop.Plugin.Misc.PricePerStore.Services;
using Nop.Services.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nop.Plugin.Misc.PricePerStore.Services
{
    public class StoreProductService : IStoreProductService
    {
        private IProductService productService;
        private IRepository<ProductPriceFieldRecord> repository;

        public StoreProductService(IProductService productService, IRepository<ProductPriceFieldRecord> repository)
        {
            this.productService = productService;
            this.repository = repository;
        }

        /// <summary>
        /// Get product by store or get default from IProductService
        /// </summary>
        /// <param name="productId"> Product id</param>
        /// <param name="storeId">Store </param>
        /// <returns></returns>
        public ProductPriceFieldRecord GetByStoreOrDefault(int productId, int? storeId)
        {
            if (!storeId.HasValue)
            {
                return GetDefaultProductPrices(productId);
            }
            var res = GetByStore(productId, storeId);
            if (res == null)
            {
                return GetDefaultProductPrices(productId);
            }
            return res;
        }

        public void CreateUpdatePricePerStore(ProductPriceFieldRecord data)
        {
            var record = repository.Table.FirstOrDefault(n => n.StoreProductId == data.StoreProductId && n.StoreId == data.StoreId);
            if (record == null)
            {
                record = new ProductPriceFieldRecord();
            }

            record.StoreAvailableForPreOrder = data.StoreAvailableForPreOrder;
            record.StoreCallForPrice = data.StoreCallForPrice;
            record.StoreCustomerEntersPrice = data.StoreCustomerEntersPrice;
            record.StoreDisableBuyButton = data.StoreDisableBuyButton;
            record.StoreDisableWishlistButton = data.StoreDisableWishlistButton;
            record.StoreOldPrice = data.StoreOldPrice;
            record.StorePrice = data.StorePrice;
            record.StoreProductId = data.StoreProductId;
            record.StoreSpecialPrice = data.StoreSpecialPrice;
            record.StoreSpecialPriceEndDateTimeUtc = data.StoreSpecialPriceEndDateTimeUtc;
            record.StoreSpecialPriceStartDateTimeUtc = data.StoreSpecialPriceStartDateTimeUtc;
            record.StoreIsTaxExempt = data.StoreIsTaxExempt;
            record.StoreIsTelecommunicationsOrBroadcastingOrElectronicServices = data.StoreIsTelecommunicationsOrBroadcastingOrElectronicServices;
            record.StoreId = data.StoreId;
            record.StoreProductCost = data.StoreProductCost;
            if (record.Id == 0)
            {
                repository.Insert(record);
            }
            else
            {
                repository.Update(record);
            }
        }

        private ProductPriceFieldRecord GetDefaultProductPrices(int productId)
        {
            var product = productService.GetProductById(productId);
            return new ProductPriceFieldRecord()
            {
                StoreAvailableForPreOrder = product.AvailableForPreOrder,
                StoreCallForPrice = product.CallForPrice,
                StoreCustomerEntersPrice = product.CustomerEntersPrice,
                StoreDisableBuyButton = product.DisableBuyButton,
                StoreDisableWishlistButton = product.DisableWishlistButton,
                StoreOldPrice = product.OldPrice,
                StorePrice = product.Price,
                StoreProductId = product.Id,
                StoreSpecialPrice = product.SpecialPrice,
                StoreSpecialPriceEndDateTimeUtc = product.SpecialPriceEndDateTimeUtc,
                StoreSpecialPriceStartDateTimeUtc = product.SpecialPriceStartDateTimeUtc,
                StoreIsTaxExempt = product.IsTaxExempt,
                StoreIsTelecommunicationsOrBroadcastingOrElectronicServices = product.IsTelecommunicationsOrBroadcastingOrElectronicServices
            };
        }

        public void RemovePricePerStore(int productId, int storeId)
        {
            var data = repository.Table.FirstOrDefault(n => n.StoreId == storeId && n.StoreProductId == productId);
            if (data!=null)
            {
                repository.Delete(data);
            }
        }

        public ProductPriceFieldRecord GetByStore(int productId, int? storeId)
        {
            return repository.Table.FirstOrDefault(n => n.StoreId == storeId && n.StoreProductId == productId);
        }
    }
}