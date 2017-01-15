using Nop.Services.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Discounts;
using Nop.Core.Domain.Orders;
using Nop.Core;
using Nop.Services.Discounts;
using Nop.Core.Caching;

namespace Nop.Plugin.Misc.PricePerStore.Services
{
    public class CustomPriceService : PriceCalculationService
    {
        private IStoreContext storeСontext { get; set; }
        private IStoreProductService customservice { get; set; }

        public CustomPriceService(IStoreProductService customservice,IWorkContext workContext, IStoreContext storeContext, IDiscountService discountService, ICategoryService categoryService, IManufacturerService manufacturerService, IProductAttributeParser productAttributeParser, IProductService productService, ICacheManager cacheManager, ShoppingCartSettings shoppingCartSettings, CatalogSettings catalogSettings)
            :base(workContext, storeContext, discountService, categoryService, manufacturerService, productAttributeParser, productService, cacheManager, shoppingCartSettings, catalogSettings)
        {
            this.storeСontext = storeContext;
            this.customservice = customservice;
        }

        public override decimal GetFinalPrice(Product product, Customer customer, decimal additionalCharge, bool includeDiscounts, int quantity, DateTime? rentalStartDate, DateTime? rentalEndDate, out decimal discountAmount, out Discount appliedDiscount)
        {
            var data = customservice.GetByStore(product.Id, storeСontext.CurrentStore.Id);
            if (data!=null)
            {
                product.AvailableForPreOrder = data.StoreAvailableForPreOrder;
                product.CallForPrice = data.StoreCallForPrice;
                product.CustomerEntersPrice = data.StoreCustomerEntersPrice;
                product.DisableBuyButton = data.StoreDisableBuyButton;
                product.DisableWishlistButton = data.StoreDisableWishlistButton;
                product.OldPrice = data.StoreOldPrice;
                product.Price = data.StorePrice;
                product.SpecialPrice = data.StoreSpecialPrice;
                product.SpecialPriceEndDateTimeUtc = data.StoreSpecialPriceEndDateTimeUtc;
                product.SpecialPriceStartDateTimeUtc = data.StoreSpecialPriceStartDateTimeUtc;
                product.IsTaxExempt = data.StoreIsTaxExempt;
                product.IsTelecommunicationsOrBroadcastingOrElectronicServices = data.StoreIsTelecommunicationsOrBroadcastingOrElectronicServices;
                product.ProductCost = data.StoreProductCost;
            }
            return base.GetFinalPrice(product, customer, additionalCharge, includeDiscounts, quantity, rentalStartDate, rentalEndDate, out discountAmount, out appliedDiscount);
        }
    }
}