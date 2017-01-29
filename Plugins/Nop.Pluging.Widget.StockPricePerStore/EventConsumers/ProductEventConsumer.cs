using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Stores;
using Nop.Core.Events;
using Nop.Plugin.Misc.StockPricePerStore.Services;
using Nop.Services.Events;
using Nop.Services.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nop.Plugin.Misc.StockPricePerStore.EventConsumers
{
    public class ProductEventConsumer : IConsumer<EntityDeleted<StoreMapping>>
    {
        private IPriceProductService priceService;
        IStockProductService stockService;
        public ProductEventConsumer(IPriceProductService priceService,IStockProductService stockService)
        {
            this.priceService = priceService;
            this.stockService = stockService;
        }
        public void HandleEvent(EntityDeleted<StoreMapping> eventMessage)
        {
            if (eventMessage.Entity.EntityName=="Product")
            {
                priceService.RemoveStockPricePerStore(eventMessage.Entity.EntityId, eventMessage.Entity.StoreId);
                stockService.Delete(eventMessage.Entity.EntityId, eventMessage.Entity.StoreId);
            }
        }
    }
}