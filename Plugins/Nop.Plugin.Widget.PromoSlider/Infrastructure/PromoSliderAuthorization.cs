using Nop.Core.Infrastructure;
using Nop.Services.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nop.Plugin.Widgets.PromoSlider.Infrastructure
{
    public class PromoSliderAuthorization : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var permissionService = EngineContext.Current.Resolve<IPermissionService>();

            if (!permissionService.Authorize(StandardPermissionProvider.ManageProducts))
            {
                return false;
            }
            
            return base.AuthorizeCore(httpContext);
        }
    }
}