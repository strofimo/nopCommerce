using Nop.Plugin.Misc.StockPricerPerStore.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Core.Domain.Catalog;

namespace Nop.Plugin.Misc.StockPricerPerStore.Data
{
    public class ProductPriceFieldMap: EntityTypeConfiguration<ProductPriceFieldRecord>
    {
        public ProductPriceFieldMap()
        {
            ToTable("StockPricerPerStore_Product");
            HasKey(n => n.Id);
            Property(n => n.StoreAvailableForPreOrder);
            Property(n => n.StoreCallForPrice);
            Property(n => n.StoreCustomerEntersPrice);
            Property(n => n.StoreDisableBuyButton);
            Property(n => n.StoreDisableWishlistButton);
            Property(n => n.StoreOldPrice);
            Property(n => n.StorePrice);
            Property(n => n.StoreSpecialPrice);
            Property(n => n.StoreSpecialPriceEndDateTimeUtc);
            Property(n => n.StoreSpecialPriceStartDateTimeUtc);
            Property(n => n.StoreIsTaxExempt);
            Property(n => n.StoreIsTelecommunicationsOrBroadcastingOrElectronicServices);
            Property(n => n.StoreProductId);
            Property( n => n.StoreId );
            Property(n => n.StoreProductCost);
        }
    }
}
