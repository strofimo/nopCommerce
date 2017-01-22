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
using Nop.Core.Data;
using Autofac.Core;
using Nop.Data;
using Nop.Plugin.Misc.ProductInventory.Data;
using Nop.Plugin.Misc.StoreProductInventory.Domain;
using Nop.Plugin.Misc.ProductInventory.Services;
using Nop.Core.Domain.Catalog;

namespace Nop.Plugin.Misc.StoreProductInventory.Data
{
    public class ProductInventoryDependencyRegister : IDependencyRegistrar
    {
        private const string CONTEXT_NAME = "nop_object_context_product_inventory_per_store";
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
            this.RegisterPluginDataContext<StoreProductInventoryObjectContext>(builder, CONTEXT_NAME);

            //override required repository with our custom context
            builder.RegisterType<EfRepository<StoreProductInventoryFieldRecord>>()
                .As<IRepository<StoreProductInventoryFieldRecord>>()
                .WithParameter(ResolvedParameter.ForNamed<IDbContext>(CONTEXT_NAME))
                .InstancePerLifetimeScope();
            
            builder.RegisterType<CustomProductRepository>()
                .As<IRepository<Product>>()
                .InstancePerLifetimeScope();
                
            builder.RegisterType<StoreProductInventoryService>()
                .As<IStoreProductInventoryService>()
                .InstancePerLifetimeScope();
        }
    }
}
