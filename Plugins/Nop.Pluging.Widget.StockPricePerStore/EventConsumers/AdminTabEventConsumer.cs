using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc.Html;
using Nop.Admin.Models.Catalog;
using Nop.Services.Events;
using Nop.Web.Framework.Events;
using Nop.Plugin.Misc.StockPricePerStore.Services;
using Nop.Services.Stores;
using Nop.Services.Catalog;
using Nop.Plugin.Misc.StockPricePerStore.ViewModels;
using System.Web.Script.Serialization;
using Nop.Plugin.Misc.StockPricePerStore.ViewModels;

namespace Nop.Plugin.Misc.StockPricePerStore.EventConsumers
{
    public class AdminTabEventConsumer : IConsumer<AdminTabStripCreated>
    {
        private IStoreMappingService storeMappingService;
        private IProductService service;

        public AdminTabEventConsumer(IStoreMappingService storeMappingService, IProductService service)
        {
            this.storeMappingService = storeMappingService;
            this.service = service;
        }

        public void HandleEvent( AdminTabStripCreated eventMessage )
        {
            if( eventMessage.TabStripName == "product-edit" )
            {
                var model = eventMessage.Helper.ViewData.Model as ProductModel;
                var product = service.GetProductById(model.Id);
                var stores = storeMappingService.GetStoreMappings(product).Select(n => new StoreViewModel()
                {
                    Id = n.Store.Id,
                    Name = n.Store.Name
                });
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                var result = new TabViewModel();
                result.JsonStores = serializer.Serialize(stores);
                result.ProductId = model.Id;
                var html = eventMessage.Helper.Partial( "~/Plugins/Misc.StockPricePerStore/Views/ProductTab.cshtml",result );
                eventMessage.BlocksToRender.Add( html );
            }
        }
    }
}
