using Nop.Core.Data;
using Nop.Core.Plugins;
using Nop.Plugin.Widget.PromoSlider.Data;
using Nop.Plugin.Widget.PromoSlider.Domain;
using Nop.Services.Cms;
using Nop.Web.Framework.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Routing;
using Nop.Services.Localization;
using Nop.Core.Events;
using Nop.Services.Events;
using Nop.Core.Domain.Messages;
using Nop.Services.Configuration;
using Nop.Core.Infrastructure;
using Nop.Services.Security;

namespace Nop.Plugin.Widget.PromoSlider
{
    public class PromoSliderPlugin : BasePlugin, IWidgetPlugin, IAdminMenuPlugin, IConsumer<EntityInserted<PromoSliderRecord>>
    {
        private PromoSliderObjectContext _context;
        private IRepository<PromoSliderRecord> _sliderRepo;
        private ISettingService _settings;
        
        public PromoSliderPlugin(PromoSliderObjectContext context, 
            IRepository<PromoSliderRecord> sliderRepo, ISettingService settings)
        {
            _context = context;
            _sliderRepo = sliderRepo;
            _settings = settings;
        }

        public override void Install()
        {
            _context.Install();

            _settings.SetSetting<bool>("SendEmailOnSliderCreate", false);

            this.AddOrUpdatePluginLocaleResource("Plugins.Misc.PromoSlider.CreateImageMessage", "Please create and save a slider before creating an image");

            this.AddOrUpdatePluginLocaleResource("Plugins.Misc.PromoSlider.PromoSliderName", "Slider Name");
            this.AddOrUpdatePluginLocaleResource("Plugins.Misc.PromoSlider.PromoSliderName.Hint", "The Name of Your Slider");

            this.AddOrUpdatePluginLocaleResource("Plugins.Misc.PromoSlider.IsActive", "Is Active");
            this.AddOrUpdatePluginLocaleResource("Plugins.Misc.PromoSlider.IsActive.Hint", "Determines if the slider will currently display in the selected zone");

            this.AddOrUpdatePluginLocaleResource("Plugins.Misc.PromoSlider.ZoneName", "Select a Zone");
            this.AddOrUpdatePluginLocaleResource("Plugins.Misc.PromoSlider.ZoneName.Hint", "Choose the Zone your slider will be displayed in");

            this.AddOrUpdatePluginLocaleResource("Plugins.Misc.PromoSlider.Interval", "Interval");
            this.AddOrUpdatePluginLocaleResource("Plugins.Misc.PromoSlider.Interval.Hint", "The duration between slides");

            this.AddOrUpdatePluginLocaleResource("Plugins.Misc.PromoSlider.PauseOnHover", "Pause On Hover");
            this.AddOrUpdatePluginLocaleResource("Plugins.Misc.PromoSlider.PauseOnHover.Hint", "Determines whether your slider will pause on mouse over");

            this.AddOrUpdatePluginLocaleResource("Plugins.Misc.PromoSlider.Keyboard", "Keyboard Controls Enabled");
            this.AddOrUpdatePluginLocaleResource("Plugins.Misc.PromoSlider.Keyboard.Hint", "Determines whether users can rotate between slides using the keyboard");

            this.AddOrUpdatePluginLocaleResource("Plugins.Misc.PromoSlider.Wrap", "Cycle Slider");
            this.AddOrUpdatePluginLocaleResource("Plugins.Misc.PromoSlider.Wrap.Hint", "Determines whether slider will rotate continuously");

            this.AddOrUpdatePluginLocaleResource("Plugins.Misc.PromoSlider.SliderNameRequired", "Please Provide a Slider Name");
            this.AddOrUpdatePluginLocaleResource("Plugins.Misc.PromoSlider.SliderIntervalRequired", "Interval Must be Greater Than 0");
            this.AddOrUpdatePluginLocaleResource("Plugins.Misc.PromoSlider.GreaterThanZero", "Slider Interval Must be Between 1 and 10");


            base.Install();
        }

        public override void Uninstall()
        {
            _context.Uninstall();

            this.DeletePluginLocaleResource("Plugins.Misc.PromoSlider.CreateImageMessage");
                                  
            this.DeletePluginLocaleResource("Plugins.Misc.PromoSlider.PromoSliderName");
            this.DeletePluginLocaleResource("Plugins.Misc.PromoSlider.PromoSliderName.Hint");
            
            this.DeletePluginLocaleResource("Plugins.Misc.PromoSlider.IsActive");
            this.DeletePluginLocaleResource("Plugins.Misc.PromoSlider.IsActive.Hint");
             
            this.DeletePluginLocaleResource("Plugins.Misc.PromoSlider.ZoneName");
            this.DeletePluginLocaleResource("Plugins.Misc.PromoSlider.ZoneName.Hint");

            this.DeletePluginLocaleResource("Plugins.Misc.PromoSlider.Interval");
            this.DeletePluginLocaleResource("Plugins.Misc.PromoSlider.Interval.Hint");

            this.DeletePluginLocaleResource("Plugins.Misc.PromoSlider.PauseOnHover");
            this.DeletePluginLocaleResource("Plugins.Misc.PromoSlider.PauseOnHover.Hint");

            this.DeletePluginLocaleResource("Plugins.Misc.PromoSlider.Keyboard");
            this.DeletePluginLocaleResource("Plugins.Misc.PromoSlider.Keyboard.Hint");

            this.DeletePluginLocaleResource("Plugins.Misc.PromoSlider.Wrap");
            this.DeletePluginLocaleResource("Plugins.Misc.PromoSlider.Wrap.Hint");

            this.DeletePluginLocaleResource("Plugins.Misc.PromoSlider.SliderNameRequired");
            this.DeletePluginLocaleResource("Plugins.Misc.PromoSlider.SliderIntervalRequired");
            this.DeletePluginLocaleResource("Plugins.Misc.PromoSlider.GreaterThanZero");

            base.Uninstall();
        }


        public void GetConfigurationRoute(out string actionName, out string controllerName, out System.Web.Routing.RouteValueDictionary routeValues)
        {
            actionName = "Configure";
            controllerName = "PromoSlider";
            routeValues = new RouteValueDictionary(){
                { "Namespaces", "Nop.Plugin.Widget.PromoSlider.Controllers" },
                { "area", null }
            };
        }

        public void GetDisplayWidgetRoute(string widgetZone, out string actionName, out string controllerName, out System.Web.Routing.RouteValueDictionary routeValues)
        {
            actionName = "PromoSliderWidget";
            controllerName = "PromoSlider";
            routeValues = new RouteValueDictionary(){
                { "Namespaces", "Nop.Plugin.Widget.PromoSlider.Controllers" },
                { "area", null },
                { "widgetZone", widgetZone}
            };
        }

        public IList<string> GetWidgetZones()
        {
            var sliders = _sliderRepo.Table.Where(x => x.IsActive == true).ToList();
            var zoneNames = new List<string>();
            foreach (var slider in sliders)
            {
                zoneNames.Add(slider.ZoneName);
            }
            return zoneNames;
        }


        public bool Authenticate()
        {
            var permissionService = EngineContext.Current.Resolve<IPermissionService>();

            if (!permissionService.Authorize(StandardPermissionProvider.ManageProducts))
            {
                return false;
            }

            return true;
        }

        public SiteMapNode BuildMenuItem()
        {
            var parentNode = new SiteMapNode()
            {
                Visible = true,
                Title = "Promo Slider",
                Url = "/PromoSlider/CreateUpdatePromoSlider"
            };

            var createUpdateNode = new SiteMapNode()
            {
                Visible = true,
                Title = "New Slider",
                Url = "/PromoSlider/CreateUpdatePromoSlider"
            };

            var manageSliders = new SiteMapNode()
            {
                Visible = true,
                Title = "Manage Sliders",
                Url = "/PromoSlider/ManagePromoSliders"
            };

            parentNode.ChildNodes.Add(createUpdateNode);
            parentNode.ChildNodes.Add(manageSliders);

            return parentNode;
        }

        public void HandleEvent(EntityInserted<PromoSliderRecord> eventMessage)
        {
            if (_settings.GetSettingByKey<bool>("SendEmailOnSliderCreate"))
            {
                var email = new EmailAccount();

                //Assign email properties
                //Email service sends email
            }
            
        }

        public void ManageSiteMap(SiteMapNode rootNode)
        {
            var node = BuildMenuItem();
            rootNode.ChildNodes.Add(node);
        }
    }
}
