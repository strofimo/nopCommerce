using Nop.Core.Plugins;
using Nop.Services.Cms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Plugin.Misc.StockPricePerStore.Data;
using System.Web.Routing;
using Nop.Services.Common;
using Nop.Services.Localization;

namespace Nop.Plugin.Misc.StockPricePerStore
{
    public class StockPricePerStorePluging : BasePlugin, IMiscPlugin
    {
        private StockPricePerStoreObjectContext mainContext;

        public StockPricePerStorePluging(StockPricePerStoreObjectContext mainContext)
        {
            this.mainContext = mainContext;
        }

        public void GetConfigurationRoute(out string actionName, out string controllerName, out System.Web.Routing.RouteValueDictionary routeValues)
        {
            actionName = "Configuration";
            controllerName = "StockPricePerStore";
            routeValues = new RouteValueDictionary(){
                { "Namespaces", "Nop.Plugin.Misc.StockPricePerStore.Controllers" },
                { "area", null }
            };
        }

        public override void Install()
        {
            mainContext.Install();
            #region Add price Resources
            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.ProductCostValidation", "Product 'cost' must be initial");
            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.PriceValidation", "Product 'Price' must be initial");
            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.OldPriceValidation", "Product 'old price' must be initial");

            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StorePrice", "Price");
            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StorePrice.Hint", "Product price in selected store");

            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreProductCost", "ProductCost");
            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreProductCost.Hint", "Product cost in selected store");

            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreOldPrice", "OldPrice");
            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreOldPrice.Hint", "Product old price in selected store");

            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreSpecialPrice", "SpecialPrice");
            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreSpecialPrice.Hint", "Product special price in selected store");

            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreSpecialPriceStartDateTimeUtc", "SpecialPriceStartDateTimeUtc");
            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreSpecialPriceStartDateTimeUtc.Hint", "Product special price start dateTimeUtc in selected store");

            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreSpecialPriceEndDateTimeUtc", "SpecialPriceEndDateTimeUtc");
            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreSpecialPriceEndDateTimeUtc.Hint", "Product special price end dateTimeUtc in selected store");

            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreDisableBuyButton", "DisableBuyButton");
            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreDisableBuyButton.Hint", "Disable buy button in selected store");

            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreDisableWishlistButton", "DisableWishlistButton");
            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreDisableWishlistButton.Hint", "Disable Wish list button in selected store");

            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreAvailableForPreOrder", "AvailableForPreOrder");
            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreAvailableForPreOrder", "Product available for preOrder in selected store");

            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreCallForPrice", "CallForPrice");
            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreCallForPrice", "Call for price in selected store");

            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreCustomerEntersPrice", "CustomerEntersPrice");
            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreCustomerEntersPrice", "Customer enters price in selected store");

            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreIsTaxExempt", "IsTaxExempt");
            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreIsTaxExempt", "Is tax exempt in selected store");

            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreIsTelecommunicationsOrBroadcastingOrElectronicServices", "IsTelecommunicationsOrBroadcastingOrElectronicServices");
            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreIsTelecommunicationsOrBroadcastingOrElectronicServices", "Is Telecommunications or broadcasting or electronic services in selected store");
            #endregion

            #region Add stock resource
            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreWarehouseId", "WarehouseId");
            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreWarehouseId.Hint", "Product cost in selected store");

            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreStockQuantity", "StockQuantity");
            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreStockQuantity.Hint", "Product cost in selected store");

            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreDisplayStockAvailability", "DisplayStockAvailability");
            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreDisplayStockAvailability.Hint", "Product cost in selected store");
            
            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreMinStockQuantity", "MinStockQuantity");
            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreMinStockQuantity.Hint", "Product cost in selected store");

            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreLowStockActivityId", "LowStockActivityId");
            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreLowStockActivityId.Hint", "Product cost in selected store");

            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreNotifyAdminForQuantityBelow", "NotifyAdminForQuantityBelow");
            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreNotifyAdminForQuantityBelow.Hint", "Product cost in selected store");

            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreBackorderModeId", "BackorderModeId");
            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreBackorderModeId.Hint", "Product cost in selected store");

            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreOrderMinimumQuantity", "OrderMinimumQuantity");
            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreOrderMinimumQuantity.Hint", "Product cost in selected store");

            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreOrderMaximumQuantity", "OrderMaximumQuantity");
            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreOrderMaximumQuantity.Hint", "Product cost in selected store");

            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreAllowedQuantities", "AllowedQuantities");
            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreAllowedQuantities.Hint", "Product cost in selected store");

            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreDisplayStockQuantity", "DisplayStockQuantity");
            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreDisplayStockQuantity.Hint", "Product cost in selected store");

            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreAllowBackInStockSubscriptions", "AllowBackInStockSubscriptions");
            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreAllowBackInStockSubscriptions.Hint", "Product cost in selected store");
            #endregion
            base.Install();
        }

        public override void Uninstall()
        {
            mainContext.Uninstall();
            #region Remove price resource
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.ProductCostValidation");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StorePrice");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.PriceValidation");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.OldPriceValidation");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreProductCost");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreOldPrice");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreSpecialPrice");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreSpecialPriceStartDateTimeUtc");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreSpecialPriceEndDateTimeUtc");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreDisableBuyButton");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreDisableWishlistButton");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreAvailableForPreOrder");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreCallForPrice");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreCustomerEntersPrice");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreIsTaxExempt");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreIsTelecommunicationsOrBroadcastingOrElectronicServices");

            this.DeletePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.ProductCostValidation.Hint");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StorePrice.Hint");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.PriceValidation.Hint");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.OldPriceValidation.Hint");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreProductCost.Hint");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreOldPrice.Hint");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreSpecialPrice.Hint");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreSpecialPriceStartDateTimeUtc.Hint");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreSpecialPriceEndDateTimeUtc.Hint");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreDisableBuyButton.Hint");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreDisableWishlistButton.Hint");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreAvailableForPreOrder.Hint");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreCallForPrice.Hint");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreCustomerEntersPrice.Hint");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreIsTaxExempt.Hint");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreIsTelecommunicationsOrBroadcastingOrElectronicServices.Hint");
            #endregion

            #region Remove stock resource
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreWarehouseId");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreWarehouseId.Hint");

            this.DeletePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreStockQuantity");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreStockQuantity.Hint");

            this.DeletePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreDisplayStockAvailability");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreDisplayStockAvailability.Hint");

            this.DeletePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreMinStockQuantity");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreMinStockQuantity.Hint");

            this.DeletePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreLowStockActivityId");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreLowStockActivityId.Hint");

            this.DeletePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreNotifyAdminForQuantityBelow");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreNotifyAdminForQuantityBelow.Hint");

            this.DeletePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreBackorderModeId");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreBackorderModeId.Hint");

            this.DeletePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreOrderMinimumQuantity");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreOrderMinimumQuantity.Hint");

            this.DeletePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreOrderMaximumQuantity");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreOrderMaximumQuantity.Hint");

            this.DeletePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreAllowedQuantities");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreAllowedQuantities.Hint");

            this.DeletePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreDisplayStockQuantity");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreDisplayStockQuantity.Hint");

            this.DeletePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreAllowBackInStockSubscriptions");
            this.DeletePluginLocaleResource("Nop.Plugin.Misc.StockPricePerStore.StoreAllowBackInStockSubscriptions.Hint");
            #endregion
            base.Uninstall();
        }
    }
}
