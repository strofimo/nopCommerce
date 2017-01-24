using Nop.Core.Infrastructure.DependencyManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Core.Configuration;
using Nop.Core.Infrastructure;
using Autofac;
using Nop.Web.Framework.Mvc;
using Nop.Data;
using Nop.Core.Data;
using Autofac.Core;
using Nop.Plugin.Misc.StockPricerPerStore.Domain;
using Nop.Plugin.Misc.StockPricerPerStore.Services;
using Nop.Services.Catalog;
using Nop.Core.Caching;
using Nop.Plugin.Misc.ProductInventory.Services;

namespace Nop.Plugin.Misc.StockPricerPerStore.Data
{
    public class StockPricerPerStoreDependencyRegistrar : IDependencyRegistrar
    {
        private const string CONTEXT_NAME = "nop_object_context_price_per_store";
        public int Order
        {
            get
            {
                return 1;
            }
        }

        public void Register(ContainerBuilder builder, ITypeFinder typeFinder, NopConfig config)
        {
            //data context
            this.RegisterPluginDataContext<StockPricerPerStoreObjectContext>(builder, CONTEXT_NAME);

            //override required repository with our custom context
            builder.RegisterType<EfRepository<ProductPriceFieldRecord>>()
                .As<IRepository<ProductPriceFieldRecord>>()
                .WithParameter(ResolvedParameter.ForNamed<IDbContext>(CONTEXT_NAME))
                .InstancePerLifetimeScope();

            builder.RegisterType<EfRepository<ProductInventoryFieldRecord>>()
             .As<IRepository<ProductInventoryFieldRecord>>()
             .WithParameter(ResolvedParameter.ForNamed<IDbContext>(CONTEXT_NAME))
             .InstancePerLifetimeScope();

            
            builder.RegisterType<StoreProductService>()
                .As<IStoreProductService>()
                .InstancePerLifetimeScope();
                /*
            builder.RegisterType<CustomProductService>()
               .As<IProductService>()
               .WithParameter(ResolvedParameter.ForNamed<ICacheManager>("nop_cache_static"))
               .InstancePerLifetimeScope();
               */
        }
    }
}
