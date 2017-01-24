using Nop.Core.Plugins;
using Nop.Services.Cms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Plugin.Misc.StockPricerPerStore.Data;
using System.Web.Routing;
using Nop.Services.Common;
using Nop.Services.Localization;

namespace Nop.Plugin.Misc.StockPricerPerStore
{
    public class StockPricerPerStorePluging : BasePlugin, IMiscPlugin
    {
        private StockPricerPerStoreObjectContext mainContext;

        public StockPricerPerStorePluging(StockPricerPerStoreObjectContext mainContext)
        {
            this.mainContext = mainContext;
        }

        public void GetConfigurationRoute(out string actionName, out string controllerName, out System.Web.Routing.RouteValueDictionary routeValues)
        {
            actionName = "Configuration";
            controllerName = "StockPricerPerStore";
            routeValues = new RouteValueDictionary(){
                { "Namespaces", "Nop.Plugin.Misc.StockPricerPerStore.Controllers" },
                { "area", null }
            };
        }

        public override void Install()
        {
            mainContext.Install();
            #region Add Resources
            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.StockPricerPerStore.ProductCostValidation", "Product 'cost' must be initial");
            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.StockPricerPerStore.PriceValidation", "Product 'Price' must be initial");
            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.StockPricerPerStore.OldPriceValidation", "Product 'old price' must be initial");

            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.StockPricerPerStore.StorePrice", "Price");
            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.StockPricerPerStore.StorePrice.Hint", "Product price in selected store");

            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.StockPricerPerStore.StoreProductCost", "ProductCost");
            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.StockPricerPerStore.StoreProductCost.Hint", "Product cost in selected store");

            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.StockPricerPerStore.StoreOldPrice", "OldPrice");
            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.StockPricerPerStore.StoreOldPrice.Hint", "Product old price in selected store");

            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.StockPricerPerStore.StoreSpecialPrice", "SpecialPrice");
            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.StockPricerPerStore.StoreSpecialPrice.Hint", "Product special price in selected store");

            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.StockPricerPerStore.StoreSpecialPriceStartDateTimeUtc", "SpecialPriceStartDateTimeUtc");
            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.StockPricerPerStore.StoreSpecialPriceStartDateTimeUtc.Hint", "Product special price start dateTimeUtc in selected store");

            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.StockPricerPerStore.StoreSpecialPriceEndDateTimeUtc", "SpecialPriceEndDateTimeUtc");
            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.StockPricerPerStore.StoreSpecialPriceEndDateTimeUtc.Hint", "Product special price end dateTimeUtc in selected store");

            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.StockPricerPerStore.StoreDisableBuyButton", "DisableBuyButton");
            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.StockPricerPerStore.StoreDisableBuyButton.Hint", "Disable buy button in selected store");

            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.StockPricerPerStore.StoreDisableWishlistButton", "DisableWishlistButton");
            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.StockPricerPerStore.StoreDisableWishlistButton.Hint", "Disable Wish list button in selected store");

            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.StockPricerPerStore.StoreAvailableForPreOrder", "AvailableForPreOrder");
            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.StockPricerPerStore.StoreAvailableForPreOrder", "Product available for preOrder in selected store");

            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.StockPricerPerStore.StoreCallForPrice", "CallForPrice");
            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.StockPricerPerStore.StoreCallForPrice", "Call for price in selected store");

            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.StockPricerPerStore.StoreCustomerEntersPrice", "CustomerEntersPrice");
            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.StockPricerPerStore.StoreCustomerEntersPrice", "Customer enters price in selected store");

            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.StockPricerPerStore.StoreIsTaxExempt", "IsTaxExempt");
            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.StockPricerPerStore.StoreIsTaxExempt", "Is tax exempt in selected store");

            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.StockPricerPerStore.StoreIsTelecommunicationsOrBroadcastingOrElectronicServices", "IsTelecommunicationsOrBroadcastingOrElectronicServices");
            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.StockPricerPerStore.StoreIsTelecommunicationsOrBroadcastingOrElectronicServices", "Is Telecommunications or broadcasting or electronic services in selected store");
            #endregion
            base.Install();
        }

        public override void Uninstall()
        {
            mainContext.Uninstall();
            #region Remove resource
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.StockPricerPerStore.ProductCostValidation");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.StockPricerPerStore.StorePrice");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.StockPricerPerStore.PriceValidation");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.StockPricerPerStore.OldPriceValidation");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.StockPricerPerStore.StoreProductCost");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.StockPricerPerStore.StoreOldPrice");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.StockPricerPerStore.StoreProductCost");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.StockPricerPerStore.StoreSpecialPrice");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.StockPricerPerStore.StoreSpecialPriceStartDateTimeUtc");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.StockPricerPerStore.StoreSpecialPriceEndDateTimeUtc");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.StockPricerPerStore.StoreDisableBuyButton");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.StockPricerPerStore.StoreDisableWishlistButton");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.StockPricerPerStore.StoreAvailableForPreOrder");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.StockPricerPerStore.StoreCallForPrice");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.StockPricerPerStore.StoreCustomerEntersPrice");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.StockPricerPerStore.StoreIsTaxExempt");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.StockPricerPerStore.StoreIsTelecommunicationsOrBroadcastingOrElectronicServices");

            this.DeletePluginLocaleResource("Nop.Plugin.Misc.StockPricerPerStore.ProductCostValidation.Hint");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.StockPricerPerStore.StorePrice.Hint");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.StockPricerPerStore.PriceValidation.Hint");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.StockPricerPerStore.OldPriceValidation.Hint");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.StockPricerPerStore.StoreProductCost.Hint");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.StockPricerPerStore.StoreOldPrice.Hint");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.StockPricerPerStore.StoreProductCost.Hint");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.StockPricerPerStore.StoreSpecialPrice.Hint");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.StockPricerPerStore.StoreSpecialPriceStartDateTimeUtc.Hint");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.StockPricerPerStore.StoreSpecialPriceEndDateTimeUtc.Hint");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.StockPricerPerStore.StoreDisableBuyButton.Hint");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.StockPricerPerStore.StoreDisableWishlistButton.Hint");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.StockPricerPerStore.StoreAvailableForPreOrder.Hint");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.StockPricerPerStore.StoreCallForPrice.Hint");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.StockPricerPerStore.StoreCustomerEntersPrice.Hint");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.StockPricerPerStore.StoreIsTaxExempt.Hint");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.StockPricerPerStore.StoreIsTelecommunicationsOrBroadcastingOrElectronicServices.Hint");
            #endregion
            base.Uninstall();
        }
    }
}
