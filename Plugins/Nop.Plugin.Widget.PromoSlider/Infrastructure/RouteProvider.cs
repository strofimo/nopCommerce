using Nop.Web.Framework.Mvc.Routes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nop.Plugin.Widgets.PromoSlider.Infrastructure
{
    public class RouteProvider : IRouteProvider
    {
        public int Priority
        {
            get { return 1; }
        }

        public void RegisterRoutes(System.Web.Routing.RouteCollection routes)
        {
            ViewEngines.Engines.Insert(0, new PromoViewEngine());

            routes.MapRoute("Plugin.Widget.PromoSlider.License",
                 "PromoSliderLicense",
                 new { controller = "PromoSlider", action = "License" },
                 new[] { "Nop.Plugin.Widget.PromoSlider.Controllers" }
            );

            routes.MapRoute("Plugin.Widget.PromoSlider.Blog",
                 "blog",
                 new { controller = "PromoSlider", action = "Blog" },
                 new[] { "Nop.Plugin.Widget.PromoSlider.Controllers" }
            );
        }
    }
}