using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc.Html;
using Nop.Admin.Models.Catalog;
using Nop.Services.Events;
using Nop.Web.Framework.Events;

namespace Nop.Plugin.Misc.StockPricerPerStore.EventConsumers
{
    public class AdminTabEventConsumer : IConsumer<AdminTabStripCreated>
    {
        public void HandleEvent( AdminTabStripCreated eventMessage )
        {
            if( eventMessage.TabStripName == "product-edit" )
            {
                var html = eventMessage.Helper.Partial( "~/Plugins/Misc.StockPricerPerStore/Views/ProductTab.cshtml" );
                eventMessage.BlocksToRender.Add( html );
            }
        }
    }
}
