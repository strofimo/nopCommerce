using Nop.Services.Events;
using Nop.Web.Framework.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc.Html;

namespace Nop.Plugin.Misc.ProductInventory.EventConsumers
{
    public class AdminTabEventConsumer : IConsumer<AdminTabStripCreated>
    {
        public void HandleEvent(AdminTabStripCreated eventMessage)
        {
            if (eventMessage.TabStripName == "product-edit")
            {
                var html = eventMessage.Helper.Partial("~/Plugins/Misc.StoreProductInventory/Views/StoreProductInventoryTab.cshtml");
                eventMessage.BlocksToRender.Add(html);
            }
        }
    }
}
