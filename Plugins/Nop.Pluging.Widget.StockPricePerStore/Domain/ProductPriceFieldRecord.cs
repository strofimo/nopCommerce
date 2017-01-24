using Nop.Core;
using Nop.Core.Domain.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Core.Domain.Stores;
using System.ComponentModel.DataAnnotations;
using Nop.Web.Framework;
using FluentValidation.Attributes;

namespace Nop.Plugin.Misc.StockPricerPerStore.Domain
{
    [Validator( typeof( ProductPriceFieldRecordValidation ) )]
    public class ProductPriceFieldRecord: BaseEntity
    {
        [NopResourceDisplayName("Nop.Plugin.Misc.StockPricerPerStore.StorePrice")]
        public virtual decimal StorePrice { get; set; }
        [NopResourceDisplayName("Nop.Plugin.Misc.StockPricerPerStore.StoreOldPrice")]
        public virtual decimal StoreOldPrice { get; set; }
        [NopResourceDisplayName("Nop.Plugin.Misc.StockPricerPerStore.StoreProductCost")]
        public virtual decimal StoreProductCost { get; set; }
        [NopResourceDisplayName("Nop.Plugin.Misc.StockPricerPerStore.StoreSpecialPrice")]
        [UIHint("DecimalNullable")]
        public virtual decimal? StoreSpecialPrice { get; set; }
        [UIHint("DateTimeNullable")]
        [NopResourceDisplayName("Nop.Plugin.Misc.StockPricerPerStore.StoreSpecialPriceStartDateTimeUtc")]
        public virtual DateTime? StoreSpecialPriceStartDateTimeUtc { get; set; }
        [UIHint("DateTimeNullable")]
        [NopResourceDisplayName("Nop.Plugin.Misc.StockPricerPerStore.StoreSpecialPriceEndDateTimeUtc")]
        public virtual DateTime? StoreSpecialPriceEndDateTimeUtc { get; set; }
        [NopResourceDisplayName("Nop.Plugin.Misc.StockPricerPerStore.StoreDisableBuyButton")]
        public virtual bool StoreDisableBuyButton { get; set; }
        [NopResourceDisplayName("Nop.Plugin.Misc.StockPricerPerStore.StoreDisableWishlistButton")]
        public virtual bool StoreDisableWishlistButton { get; set; }
        [NopResourceDisplayName("Nop.Plugin.Misc.StockPricerPerStore.StoreAvailableForPreOrder")]
        public virtual bool StoreAvailableForPreOrder { get; set; }
        [NopResourceDisplayName("Nop.Plugin.Misc.StockPricerPerStore.StoreCallForPrice")]
        public virtual bool StoreCallForPrice { get; set; }
        [NopResourceDisplayName("Nop.Plugin.Misc.StockPricerPerStore.StoreCustomerEntersPrice")]
        public virtual bool StoreCustomerEntersPrice { get; set; }
        [NopResourceDisplayName("Nop.Plugin.Misc.StockPricerPerStore.StoreIsTaxExempt")]
        public virtual bool StoreIsTaxExempt { get; set; }
        [NopResourceDisplayName("Nop.Plugin.Misc.StockPricerPerStore.StoreIsTelecommunicationsOrBroadcastingOrElectronicServices")]
        public virtual bool StoreIsTelecommunicationsOrBroadcastingOrElectronicServices { get; set; }
        public virtual int StoreProductId { get; set; }
        public virtual int StoreId { get; set; }
    }
}
