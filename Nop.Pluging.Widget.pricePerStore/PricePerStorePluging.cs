using Nop.Core.Plugins;
using Nop.Services.Cms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Plugin.Misc.PricePerStore.Data;
using System.Web.Routing;
using Nop.Services.Common;
using Nop.Services.Localization;

namespace Plugin.Misc.PricePerStore
{
    public class PricePerStorePluging : BasePlugin, IMiscPlugin
    {
        private PricePerStoreObjectContext mainContext;

        public PricePerStorePluging(PricePerStoreObjectContext mainContext)
        {
            this.mainContext = mainContext;
        }

        public void GetConfigurationRoute(out string actionName, out string controllerName, out System.Web.Routing.RouteValueDictionary routeValues)
        {
            actionName = "Configuration";
            controllerName = "PricePerStore";
            routeValues = new RouteValueDictionary(){
                { "Namespaces", "Nop.Plugin.Misc.PricePerStore.Controllers" },
                { "area", null }
            };
        }

        public override void Install()
        {
            mainContext.Install();
            #region Add Resources
            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.PricePerStore.ProductCostValidation", "Product 'cost' must be initial");
            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.PricePerStore.PriceValidation", "Product 'Price' must be initial");
            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.PricePerStore.OldPriceValidation", "Product 'old price' must be initial");

            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.PricePerStore.StorePrice", "Price");
            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.PricePerStore.StorePrice.Hint", "Product price in selected store");

            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.PricePerStore.StoreProductCost", "ProductCost");
            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.PricePerStore.StoreProductCost.Hint", "Product cost in selected store");

            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.PricePerStore.StoreOldPrice", "OldPrice");
            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.PricePerStore.StoreOldPrice.Hint", "Product old price in selected store");

            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.PricePerStore.StoreSpecialPrice", "SpecialPrice");
            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.PricePerStore.StoreSpecialPrice.Hint", "Product special price in selected store");

            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.PricePerStore.StoreSpecialPriceStartDateTimeUtc", "SpecialPriceStartDateTimeUtc");
            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.PricePerStore.StoreSpecialPriceStartDateTimeUtc.Hint", "Product special price start dateTimeUtc in selected store");

            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.PricePerStore.StoreSpecialPriceEndDateTimeUtc", "SpecialPriceEndDateTimeUtc");
            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.PricePerStore.StoreSpecialPriceEndDateTimeUtc.Hint", "Product special price end dateTimeUtc in selected store");

            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.PricePerStore.StoreDisableBuyButton", "DisableBuyButton");
            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.PricePerStore.StoreDisableBuyButton.Hint", "Disable buy button in selected store");

            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.PricePerStore.StoreDisableWishlistButton", "DisableWishlistButton");
            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.PricePerStore.StoreDisableWishlistButton.Hint", "Disable Wish list button in selected store");

            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.PricePerStore.StoreAvailableForPreOrder", "AvailableForPreOrder");
            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.PricePerStore.StoreAvailableForPreOrder", "Product available for preOrder in selected store");

            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.PricePerStore.StoreCallForPrice", "CallForPrice");
            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.PricePerStore.StoreCallForPrice", "Call for price in selected store");

            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.PricePerStore.StoreCustomerEntersPrice", "CustomerEntersPrice");
            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.PricePerStore.StoreCustomerEntersPrice", "Customer enters price in selected store");

            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.PricePerStore.StoreIsTaxExempt", "IsTaxExempt");
            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.PricePerStore.StoreIsTaxExempt", "Is tax exempt in selected store");

            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.PricePerStore.StoreIsTelecommunicationsOrBroadcastingOrElectronicServices", "IsTelecommunicationsOrBroadcastingOrElectronicServices");
            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.PricePerStore.StoreIsTelecommunicationsOrBroadcastingOrElectronicServices", "Is Telecommunications or broadcasting or electronic services in selected store");
            #endregion
            base.Install();
        }

        public override void Uninstall()
        {
            mainContext.Uninstall();
            #region Remove resource
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.PricePerStore.ProductCostValidation");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.PricePerStore.StorePrice");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.PricePerStore.PriceValidation");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.PricePerStore.OldPriceValidation");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.PricePerStore.StoreProductCost");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.PricePerStore.StoreOldPrice");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.PricePerStore.StoreProductCost");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.PricePerStore.StoreSpecialPrice");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.PricePerStore.StoreSpecialPriceStartDateTimeUtc");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.PricePerStore.StoreSpecialPriceEndDateTimeUtc");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.PricePerStore.StoreDisableBuyButton");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.PricePerStore.StoreDisableWishlistButton");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.PricePerStore.StoreAvailableForPreOrder");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.PricePerStore.StoreCallForPrice");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.PricePerStore.StoreCustomerEntersPrice");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.PricePerStore.StoreIsTaxExempt");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.PricePerStore.StoreIsTelecommunicationsOrBroadcastingOrElectronicServices");

            this.DeletePluginLocaleResource("Nop.Plugin.Misc.PricePerStore.ProductCostValidation.Hint");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.PricePerStore.StorePrice.Hint");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.PricePerStore.PriceValidation.Hint");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.PricePerStore.OldPriceValidation.Hint");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.PricePerStore.StoreProductCost.Hint");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.PricePerStore.StoreOldPrice.Hint");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.PricePerStore.StoreProductCost.Hint");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.PricePerStore.StoreSpecialPrice.Hint");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.PricePerStore.StoreSpecialPriceStartDateTimeUtc.Hint");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.PricePerStore.StoreSpecialPriceEndDateTimeUtc.Hint");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.PricePerStore.StoreDisableBuyButton.Hint");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.PricePerStore.StoreDisableWishlistButton.Hint");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.PricePerStore.StoreAvailableForPreOrder.Hint");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.PricePerStore.StoreCallForPrice.Hint");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.PricePerStore.StoreCustomerEntersPrice.Hint");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.PricePerStore.StoreIsTaxExempt.Hint");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.PricePerStore.StoreIsTelecommunicationsOrBroadcastingOrElectronicServices.Hint");
            #endregion
            base.Uninstall();
        }
    }
}
