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
using Nop.Plugin.Misc.StockPricePerStore.Domain;
using Nop.Plugin.Misc.StockPricePerStore.Services;
using Nop.Services.Catalog;
using Nop.Core.Caching;
using Nop.Plugin.Misc.ProductInventory.Services;

namespace Nop.Plugin.Misc.StockPricePerStore.Data
{
    public class StockPricePerStoreDependencyRegistrar : IDependencyRegistrar
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
            this.RegisterPluginDataContext<StockPricePerStoreObjectContext>(builder, CONTEXT_NAME);

            //override required repository with our custom context
            builder.RegisterType<EfRepository<ProductPriceFieldRecord>>()
                .As<IRepository<ProductPriceFieldRecord>>()
                .WithParameter(ResolvedParameter.ForNamed<IDbContext>(CONTEXT_NAME))
                .InstancePerLifetimeScope();

            builder.RegisterType<EfRepository<ProductInventoryFieldRecord>>()
             .As<IRepository<ProductInventoryFieldRecord>>()
             .WithParameter(ResolvedParameter.ForNamed<IDbContext>(CONTEXT_NAME))
             .InstancePerLifetimeScope();

            
            builder.RegisterType<PriceProductService>()
                .As<IPriceProductService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<StockProductService>()
                .As<IStockProductService>()
                .InstancePerLifetimeScope();
            
            builder.RegisterType<CustomProductService>()
               .As<IProductService>();
               
        }
    }
}
