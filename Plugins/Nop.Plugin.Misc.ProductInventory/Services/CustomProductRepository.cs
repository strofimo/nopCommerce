using Nop.Core.Data;
using Nop.Core.Domain.Catalog;
using Nop.Data;
using Nop.Plugin.Misc.StoreProductInventory.Domain;
using Nop.Services.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Caching;
using Nop.Core.Domain.Common;
using Nop.Core.Domain.Localization;
using Nop.Core.Domain.Security;
using Nop.Core.Domain.Stores;
using Nop.Services.Events;
using Nop.Services.Localization;
using Nop.Services.Messages;
using Nop.Services.Security;
using Nop.Services.Stores;
using Nop.Core.Domain.Orders;

namespace Nop.Plugin.Misc.ProductInventory.Services
{
    public class CustomProductService : ProductService
    {
        private IRepository<StoreProductInventoryFieldRecord> customInventory;
        private IStoreContext storeContext;

        public CustomProductService(IRepository<StoreProductInventoryFieldRecord> customInventory, IStoreContext storeContext, ICacheManager cacheManager, IRepository<Product> productRepository, IRepository<RelatedProduct> relatedProductRepository, IRepository<CrossSellProduct> crossSellProductRepository, IRepository<TierPrice> tierPriceRepository, IRepository<ProductPicture> productPictureRepository, IRepository<LocalizedProperty> localizedPropertyRepository, IRepository<AclRecord> aclRepository, IRepository<StoreMapping> storeMappingRepository, IRepository<ProductSpecificationAttribute> productSpecificationAttributeRepository, IRepository<ProductReview> productReviewRepository, IRepository<ProductWarehouseInventory> productWarehouseInventoryRepository, IProductAttributeService productAttributeService, IProductAttributeParser productAttributeParser, ILanguageService languageService, IWorkflowMessageService workflowMessageService, IDataProvider dataProvider, IDbContext dbContext, IWorkContext workContext, LocalizationSettings localizationSettings, CommonSettings commonSettings, CatalogSettings catalogSettings, IEventPublisher eventPublisher, IAclService aclService, IStoreMappingService storeMappingService) :
            base(cacheManager, productRepository, relatedProductRepository, crossSellProductRepository, tierPriceRepository, productPictureRepository, localizedPropertyRepository, aclRepository, storeMappingRepository, productSpecificationAttributeRepository, productReviewRepository, productWarehouseInventoryRepository, productAttributeService, productAttributeParser, languageService, workflowMessageService, dataProvider, dbContext, workContext, localizationSettings, commonSettings, catalogSettings, eventPublisher, aclService, storeMappingService)
        {
            this.customInventory = customInventory;
            this.storeContext = storeContext;
        }

        private T SyncListProduct<T>(T list) where T: IEnumerable<Product>
        {
            StoreProductInventoryFieldRecord record;
            var ids = list.Select(n => n.Id);
            var data = this.customInventory.Table.Where(n => ids.Contains(n.ProductId) && n.StoreId == storeContext.CurrentStore.Id).ToList();
            foreach (var n in list)
            {
                record = data.FirstOrDefault(m => m.ProductId == n.Id);
                if (record != null)
                {
                    UpdateWithInventoryProduct(n, record);
                }
            }
            return list;
        }

        private void SyncProduct(Product product)
        {
            if (product != null)
            {
                var data = this.customInventory.Table.FirstOrDefault(n => n.ProductId == product.Id && n.StoreId == storeContext.CurrentStore.Id);
                if (data != null)
                {
                    UpdateWithInventoryProduct(product, data);
                }
            }
        }

        private void UpdateWithInventoryProduct(Product product, StoreProductInventoryFieldRecord record)
        {
            product.AllowBackInStockSubscriptions = record.StoreAllowBackInStockSubscriptions;
            product.AllowedQuantities = record.StoreAllowedQuantities;
            product.BackorderModeId = record.StoreBackorderModeId;
            product.DisplayStockAvailability = record.StoreDisplayStockAvailability;
            product.DisplayStockQuantity = record.StoreDisplayStockQuantity;
            product.LowStockActivityId = record.StoreLowStockActivityId;
            product.MinStockQuantity = record.StoreMinStockQuantity;
            product.NotifyAdminForQuantityBelow = record.StoreNotifyAdminForQuantityBelow;
            product.OrderMaximumQuantity = record.StoreOrderMaximumQuantity;
            product.OrderMinimumQuantity = record.StoreOrderMinimumQuantity;
            product.StockQuantity = record.StoreStockQuantity;
            product.WarehouseId = record.StoreWarehouseId;
        }

        public override IList<Product> GetAssociatedProducts(int parentGroupedProductId, int storeId = 0, int vendorId = 0, bool showHidden = false)
        {
            var res = base.GetAssociatedProducts(parentGroupedProductId, storeId, vendorId, showHidden);
            return SyncListProduct(res);
        }

        public override IList<Product> GetAllProductsDisplayedOnHomePage()
        {
            var res = base.GetAllProductsDisplayedOnHomePage();
            return SyncListProduct(res);
        }

        public override IList<Product> GetCrosssellProductsByShoppingCart(IList<ShoppingCartItem> cart, int numberOfProducts)
        {
            var res = base.GetCrosssellProductsByShoppingCart(cart, numberOfProducts);
            return SyncListProduct(res);
        }

        public override void GetLowStockProducts(int vendorId, out IList<Product> products, out IList<ProductAttributeCombination> combinations)
        {
            base.GetLowStockProducts(vendorId, out products, out combinations);
            products = SyncListProduct(products);
        }

        public override Product GetProductById(int productId)
        {
            var product = base.GetProductById(productId);
            SyncProduct(product);
            return product;
        }

        public override Product GetProductBySku(string sku)
        {
            var product = base.GetProductBySku(sku);
            SyncProduct(product);
            return product;
        }

        public override IList<Product> GetProductsByIds(int[] productIds)
        {
            var res = base.GetProductsByIds(productIds);
            return SyncListProduct(res);
        }

        public override IPagedList<Product> GetProductsByProductAtributeId(int productAttributeId, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var res = base.GetProductsByProductAtributeId(productAttributeId, pageIndex, pageSize);
            return SyncListProduct(res);
        }

        public override IPagedList<Product> SearchProducts(int pageIndex = 0, int pageSize = int.MaxValue, IList<int> categoryIds = null, int manufacturerId = 0, int storeId = 0, int vendorId = 0, int warehouseId = 0, ProductType? productType = default(ProductType?), bool visibleIndividuallyOnly = false, bool markedAsNewOnly = false, bool? featuredProducts = default(bool?), decimal? priceMin = default(decimal?), decimal? priceMax = default(decimal?), int productTagId = 0, string keywords = null, bool searchDescriptions = false, bool searchSku = true, bool searchProductTags = false, int languageId = 0, IList<int> filteredSpecs = null, ProductSortingEnum orderBy = ProductSortingEnum.Position, bool showHidden = false, bool? overridePublished = default(bool?))
        {
            var res = base.SearchProducts(pageIndex, pageSize, categoryIds, manufacturerId, storeId, vendorId, warehouseId, productType, visibleIndividuallyOnly, markedAsNewOnly, featuredProducts, priceMin, priceMax, productTagId, keywords, searchDescriptions, searchSku, searchProductTags, languageId, filteredSpecs, orderBy, showHidden, overridePublished);
            return SyncListProduct(res);
        }

        public override IPagedList<Product> SearchProducts(out IList<int> filterableSpecificationAttributeOptionIds, bool loadFilterableSpecificationAttributeOptionIds = false, int pageIndex = 0, int pageSize = int.MaxValue, IList<int> categoryIds = null, int manufacturerId = 0, int storeId = 0, int vendorId = 0, int warehouseId = 0, ProductType? productType = default(ProductType?), bool visibleIndividuallyOnly = false, bool markedAsNewOnly = false, bool? featuredProducts = default(bool?), decimal? priceMin = default(decimal?), decimal? priceMax = default(decimal?), int productTagId = 0, string keywords = null, bool searchDescriptions = false, bool searchSku = true, bool searchProductTags = false, int languageId = 0, IList<int> filteredSpecs = null, ProductSortingEnum orderBy = ProductSortingEnum.Position, bool showHidden = false, bool? overridePublished = default(bool?))
        {
            var res = base.SearchProducts(out filterableSpecificationAttributeOptionIds, loadFilterableSpecificationAttributeOptionIds, pageIndex, pageSize, categoryIds, manufacturerId, storeId, vendorId, warehouseId, productType, visibleIndividuallyOnly, markedAsNewOnly, featuredProducts, priceMin, priceMax, productTagId, keywords, searchDescriptions, searchSku, searchProductTags, languageId, filteredSpecs, orderBy, showHidden, overridePublished);
            return SyncListProduct(res);
        }
    }
}
