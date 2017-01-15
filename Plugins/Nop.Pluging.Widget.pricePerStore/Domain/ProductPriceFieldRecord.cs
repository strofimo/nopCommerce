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
using Nop.Nop.Plugin.Misc.PricePerStore.Domain;

namespace Nop.Plugin.Misc.PricePerStore.Domain
{
    [Validator( typeof( ProductPriceFieldRecordValidation ) )]
    public class ProductPriceFieldRecord: BaseEntity
    {
        [NopResourceDisplayName("Nop.Plugin.Misc.PricePerStore.StorePrice")]
        public virtual decimal StorePrice { get; set; }
        [NopResourceDisplayName("Nop.Plugin.Misc.PricePerStore.StoreOldPrice")]
        public virtual decimal StoreOldPrice { get; set; }
        [NopResourceDisplayName("Nop.Plugin.Misc.PricePerStore.StoreProductCost")]
        public virtual decimal StoreProductCost { get; set; }
        [NopResourceDisplayName("Nop.Plugin.Misc.PricePerStore.StoreSpecialPrice")]
        [UIHint("DecimalNullable")]
        public virtual decimal? StoreSpecialPrice { get; set; }
        [UIHint("DateTimeNullable")]
        [NopResourceDisplayName("Nop.Plugin.Misc.PricePerStore.StoreSpecialPriceStartDateTimeUtc")]
        public virtual DateTime? StoreSpecialPriceStartDateTimeUtc { get; set; }
        [UIHint("DateTimeNullable")]
        [NopResourceDisplayName("Nop.Plugin.Misc.PricePerStore.StoreSpecialPriceEndDateTimeUtc")]
        public virtual DateTime? StoreSpecialPriceEndDateTimeUtc { get; set; }
        [NopResourceDisplayName("Nop.Plugin.Misc.PricePerStore.StoreDisableBuyButton")]
        public virtual bool StoreDisableBuyButton { get; set; }
        [NopResourceDisplayName("Nop.Plugin.Misc.PricePerStore.StoreDisableWishlistButton")]
        public virtual bool StoreDisableWishlistButton { get; set; }
        [NopResourceDisplayName("Nop.Plugin.Misc.PricePerStore.StoreAvailableForPreOrder")]
        public virtual bool StoreAvailableForPreOrder { get; set; }
        [NopResourceDisplayName("Nop.Plugin.Misc.PricePerStore.StoreCallForPrice")]
        public virtual bool StoreCallForPrice { get; set; }
        [NopResourceDisplayName("Nop.Plugin.Misc.PricePerStore.StoreCustomerEntersPrice")]
        public virtual bool StoreCustomerEntersPrice { get; set; }
        [NopResourceDisplayName("Nop.Plugin.Misc.PricePerStore.StoreIsTaxExempt")]
        public virtual bool StoreIsTaxExempt { get; set; }
        [NopResourceDisplayName("Nop.Plugin.Misc.PricePerStore.StoreIsTelecommunicationsOrBroadcastingOrElectronicServices")]
        public virtual bool StoreIsTelecommunicationsOrBroadcastingOrElectronicServices { get; set; }
        public virtual int StoreProductId { get; set; }
        public virtual int StoreId { get; set; }
    }
}
