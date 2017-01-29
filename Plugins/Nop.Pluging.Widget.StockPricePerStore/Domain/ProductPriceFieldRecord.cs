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

namespace Nop.Plugin.Misc.StockPricePerStore.Domain
{
    [Validator( typeof( ProductPriceFieldRecordValidation ) )]
    public class ProductPriceFieldRecord: BaseEntity
    {
        [NopResourceDisplayName("Nop.Plugin.Misc.StockPricePerStore.StorePrice")]
        public virtual decimal StorePrice { get; set; }
        [NopResourceDisplayName("Nop.Plugin.Misc.StockPricePerStore.StoreOldPrice")]
        public virtual decimal StoreOldPrice { get; set; }
        [NopResourceDisplayName("Nop.Plugin.Misc.StockPricePerStore.StoreProductCost")]
        public virtual decimal StoreProductCost { get; set; }
        [NopResourceDisplayName("Nop.Plugin.Misc.StockPricePerStore.StoreSpecialPrice")]
        [UIHint("DecimalNullable")]
        public virtual decimal? StoreSpecialPrice { get; set; }
        [UIHint("DateTimeNullable")]
        [NopResourceDisplayName("Nop.Plugin.Misc.StockPricePerStore.StoreSpecialPriceStartDateTimeUtc")]
        public virtual DateTime? StoreSpecialPriceStartDateTimeUtc { get; set; }
        [UIHint("DateTimeNullable")]
        [NopResourceDisplayName("Nop.Plugin.Misc.StockPricePerStore.StoreSpecialPriceEndDateTimeUtc")]
        public virtual DateTime? StoreSpecialPriceEndDateTimeUtc { get; set; }
        [NopResourceDisplayName("Nop.Plugin.Misc.StockPricePerStore.StoreDisableBuyButton")]
        public virtual bool StoreDisableBuyButton { get; set; }
        [NopResourceDisplayName("Nop.Plugin.Misc.StockPricePerStore.StoreDisableWishlistButton")]
        public virtual bool StoreDisableWishlistButton { get; set; }
        [NopResourceDisplayName("Nop.Plugin.Misc.StockPricePerStore.StoreAvailableForPreOrder")]
        public virtual bool StoreAvailableForPreOrder { get; set; }
        [NopResourceDisplayName("Nop.Plugin.Misc.StockPricePerStore.StoreCallForPrice")]
        public virtual bool StoreCallForPrice { get; set; }
        [NopResourceDisplayName("Nop.Plugin.Misc.StockPricePerStore.StoreCustomerEntersPrice")]
        public virtual bool StoreCustomerEntersPrice { get; set; }
        [NopResourceDisplayName("Nop.Plugin.Misc.StockPricePerStore.StoreIsTaxExempt")]
        public virtual bool StoreIsTaxExempt { get; set; }
        [NopResourceDisplayName("Nop.Plugin.Misc.StockPricePerStore.StoreIsTelecommunicationsOrBroadcastingOrElectronicServices")]
        public virtual bool StoreIsTelecommunicationsOrBroadcastingOrElectronicServices { get; set; }
        public virtual int StoreProductId { get; set; }
        public virtual int StoreId { get; set; }
    }
}
