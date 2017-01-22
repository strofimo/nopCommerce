using Nop.Core.Plugins;
using Nop.Plugin.Misc.ProductInventory.Data;
using Nop.Services.Common;
using Nop.Services.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Routing;

namespace Nop.Plugin.Misc.StoreProductInventory
{
    public class ProductInventory : BasePlugin, IMiscPlugin
    {
        private StoreProductInventoryObjectContext context;
        public ProductInventory(StoreProductInventoryObjectContext context)
        {
            this.context = context;
        }
        public void GetConfigurationRoute(out string actionName, out string controllerName, out RouteValueDictionary routeValues)
        {
            actionName = "Configuration";
            controllerName = "StoreProductInventory";
            routeValues = new RouteValueDictionary(){
                { "Namespaces", "Nop.Plugin.Misc.StoreProductInventory.Controllers" },
                { "area", null }
            };
        }

        public override void Install()
        {
            context.Install();
            base.Install();
        }

        public override void Uninstall()
        {
            context.Uninstall();
            base.Uninstall();
        }
    }
}
