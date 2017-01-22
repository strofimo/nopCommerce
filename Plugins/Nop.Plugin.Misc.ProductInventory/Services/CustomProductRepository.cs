using Nop.Core.Data;
using Nop.Core.Domain.Catalog;
using Nop.Data;
using Nop.Plugin.Misc.StoreProductInventory.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Misc.ProductInventory.Services
{
    class CustomProductRepository : EfRepository<Product>
    {
        private IDbContext context;
        /*
        public override IQueryable<Product> Table
        {
            get
            {
                return context.SqlQuery<Product>(@"
                        SELECT t1.[Id]
      ,[ProductTypeId]
      ,[ParentGroupedProductId]
      ,[VisibleIndividually]
      ,[Name]
      ,[ShortDescription]
      ,[FullDescription]
      ,[AdminComment]
      ,[ProductTemplateId]
      ,[VendorId]
      ,[ShowOnHomePage]
      ,[MetaKeywords]
      ,[MetaDescription]
      ,[MetaTitle]
      ,[AllowCustomerReviews]
      ,[ApprovedRatingSum]
      ,[NotApprovedRatingSum]
      ,[ApprovedTotalReviews]
      ,[NotApprovedTotalReviews]
      ,[SubjectToAcl]
      ,[LimitedToStores]
      ,[Sku]
      ,[ManufacturerPartNumber]
      ,[Gtin]
      ,[IsGiftCard]
      ,[GiftCardTypeId]
      ,[OverriddenGiftCardAmount]
      ,[RequireOtherProducts]
      ,[RequiredProductIds]
      ,[AutomaticallyAddRequiredProducts]
      ,[IsDownload]
      ,[DownloadId]
      ,[UnlimitedDownloads]
      ,[MaxNumberOfDownloads]
      ,[DownloadExpirationDays]
      ,[DownloadActivationTypeId]
      ,[HasSampleDownload]
      ,[SampleDownloadId]
      ,[HasUserAgreement]
      ,[UserAgreementText]
      ,[IsRecurring]
      ,[RecurringCycleLength]
      ,[RecurringCyclePeriodId]
      ,[RecurringTotalCycles]
      ,[IsRental]
      ,[RentalPriceLength]
      ,[RentalPricePeriodId]
      ,[IsShipEnabled]
      ,[IsFreeShipping]
      ,[ShipSeparately]
      ,[AdditionalShippingCharge]
      ,[DeliveryDateId]
      ,[IsTaxExempt]
      ,[TaxCategoryId]
      ,[IsTelecommunicationsOrBroadcastingOrElectronicServices]
      ,[ManageInventoryMethodId]
      ,[UseMultipleWarehouses]
      ,ISNULL(t2.[StoreWarehouseId], [WarehouseId]) as WarehouseId
      ,ISNULL(t2.[StoreStockQuantity],[StockQuantity]) as StockQuantity
      ,isnull(t2.[StoreDisplayStockAvailability],[DisplayStockAvailability]) as [DisplayStockAvailability]
      ,isnull(t2.[StoreDisplayStockQuantity], DisplayStockQuantity) as DisplayStockQuantity 
      ,isnull(t2.[StoreMinStockQuantity],MinStockQuantity) as MinStockQuantity
      ,isnull(t2.[StoreLowStockActivityId],LowStockActivityId) as LowStockActivityId
      ,isnull(t2.[StoreNotifyAdminForQuantityBelow],NotifyAdminForQuantityBelow) as NotifyAdminForQuantityBelow
      ,isnull(t2.[StoreBackorderModeId],BackorderModeId) as BackorderModeId
      ,isnull(t2.[StoreAllowBackInStockSubscriptions],AllowBackInStockSubscriptions) as AllowBackInStockSubscriptions
      ,isnull(t2.[StoreOrderMinimumQuantity],OrderMinimumQuantity) as OrderMinimumQuantity
      ,isnull(t2.[StoreOrderMaximumQuantity],OrderMaximumQuantity) as OrderMaximumQuantity
      ,isnull(t2.[StoreAllowedQuantities],AllowedQuantities) as AllowedQuantities
      ,[AllowAddingOnlyExistingAttributeCombinations]
      ,[DisableBuyButton]
      ,[DisableWishlistButton]
      ,[AvailableForPreOrder]
      ,[PreOrderAvailabilityStartDateTimeUtc]
      ,[CallForPrice]
      ,[Price]
      ,[OldPrice]
      ,[ProductCost]
      ,[SpecialPrice]
      ,[SpecialPriceStartDateTimeUtc]
      ,[SpecialPriceEndDateTimeUtc]
      ,[CustomerEntersPrice]
      ,[MinimumCustomerEnteredPrice]
      ,[MaximumCustomerEnteredPrice]
      ,[BasepriceEnabled]
      ,[BasepriceAmount]
      ,[BasepriceUnitId]
      ,[BasepriceBaseAmount]
      ,[BasepriceBaseUnitId]
      ,[MarkAsNew]
      ,[MarkAsNewStartDateTimeUtc]
      ,[MarkAsNewEndDateTimeUtc]
      ,[HasTierPrices]
      ,[HasDiscountsApplied]
      ,[Weight]
      ,[Length]
      ,[Width]
      ,[Height]
      ,[AvailableStartDateTimeUtc]
      ,[AvailableEndDateTimeUtc]
      ,[DisplayOrder]
      ,[Published]
      ,[Deleted]
      ,[CreatedOnUtc]
      ,[UpdatedOnUtc]
  FROM [dbo].[Product] as t1 left join InventoryPerStore_Product as t2 on t1.Id =t2.ProductId 
                ").AsQueryable();
            }
        }
        */
        public CustomProductRepository(IDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}
