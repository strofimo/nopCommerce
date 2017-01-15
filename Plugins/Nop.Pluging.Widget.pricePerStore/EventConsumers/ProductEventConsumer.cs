﻿using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Stores;
using Nop.Core.Events;
using Nop.Plugin.Misc.PricePerStore.Services;
using Nop.Services.Events;
using Nop.Services.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nop.Plugin.Misc.PricePerStore.EventConsumers
{
    public class ProductEventConsumer : IConsumer<EntityDeleted<StoreMapping>>
    {

        private IStoreProductService service;
        public ProductEventConsumer(IStoreProductService service)
        {
            this.service = service;
        }
        public void HandleEvent(EntityDeleted<StoreMapping> eventMessage)
        {
            if (eventMessage.Entity.EntityName=="Product")
            {
                service.RemovePricePerStore(eventMessage.Entity.EntityId, eventMessage.Entity.StoreId);
            }
        }
    }
}