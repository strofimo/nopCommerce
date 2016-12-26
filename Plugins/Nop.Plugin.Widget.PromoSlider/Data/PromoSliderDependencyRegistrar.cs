using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Core;
using Nop.Core.Data;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.DependencyManagement;
using Nop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Plugin.Widget.PromoSlider.Domain;
using Nop.Plugin.Widget.PromoSlider.Data;
using Nop.Web.Framework.Mvc;
using Nop.Core.Configuration;

namespace Nop.Plugin.Widget.PromoSlider.Data
{
    public class PromoSliderDependencyRegistrar : IDependencyRegistrar
    {
        private const string CONTEXT_NAME = "nop_object_context_promo_slider";

        public void Register(ContainerBuilder builder, ITypeFinder typeFinder, NopConfig config)
        {
            //data context
            this.RegisterPluginDataContext<PromoSliderObjectContext>(builder, CONTEXT_NAME);

            //override required repository with our custom context
            builder.RegisterType<EfRepository<PromoSliderRecord>>()
                .As<IRepository<PromoSliderRecord>>()
                .WithParameter(ResolvedParameter.ForNamed<IDbContext>(CONTEXT_NAME))
                .InstancePerLifetimeScope();

            builder.RegisterType<EfRepository<PromoImageRecord>>()
                .As<IRepository<PromoImageRecord>>()
                .WithParameter(ResolvedParameter.ForNamed<IDbContext>(CONTEXT_NAME))
                .InstancePerLifetimeScope();
        }

        public int Order
        {
            get { return 1; }
        }
    }
}
