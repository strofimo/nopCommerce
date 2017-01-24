using Nop.Plugin.Misc.StockPricerPerStore.Domain;
using Nop.Plugin.Misc.StockPricerPerStore.Services;
using Nop.Plugin.Misc.StockPricerPerStore.ViewModels;
using Nop.Plugin.Misc.ProductInventory.ViewModels;
using Nop.Services.Catalog;
using Nop.Services.Localization;
using Nop.Services.Shipping;
using Nop.Services.Stores;
using Nop.Web.Framework.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Nop.Plugin.Misc.StockPricerPerStore.Controllers
{
    public class StoreProductInventoryController: BasePluginController
    {
        private IStoreProductInventoryService service;
        private IShippingService shippingService;
        private IStoreMappingService storeMappingService;
        private IProductService productService;
        private ILocalizationService localizationService;

        public StoreProductInventoryController(IStoreProductInventoryService service,IProductService productService,
            IShippingService shippingService, IStoreMappingService storeMappingService, ILocalizationService localizationService)
        {
            this.service = service;
            this.shippingService = shippingService;
            this.storeMappingService = storeMappingService;
            this.productService = productService;
            this.localizationService = localizationService;
        }

        [HttpGet]
        public ActionResult EditProductInventory(int productId)
        {
            var model = new StoreProductInventoryViewModel();
            model.WarehouseList = new List<SelectListItem>();
            var product = this.productService.GetProductById(productId);
            var stores = this.storeMappingService.GetStoreMappings(product).Select(n => new StoreViewModel()
            {
                Id = n.Store.Id,
                Name = n.Store.Name
            }).ToList();
            var field = this.service.GetByStoreOrDefault(productId, stores[0].Id);

            model.Record = field;
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            model.StoresJson = serializer.Serialize(stores);
            //warehouses
            model.WarehouseList.Add(new SelectListItem { Text = localizationService.GetResource("Admin.Common.All"), Value = "0" });
            foreach (var w in shippingService.GetAllWarehouses())
                model.WarehouseList.Add(new SelectListItem { Text = w.Name, Value = w.Id.ToString() });
            return View("~/Plugins/Misc.StoreProductInventory/Views/StoreProductInventory.cshtml", model);
        }

        [HttpPost]
        public JsonResult GetStockFieldsByStore(int storeId, int productId)
        {
            var data = this.service.GetByStoreOrDefault(productId, storeId);
            return Json(data);
        }

        [HttpPost]
        public JsonResult CreateUpdateStockPerStore(ProductInventoryFieldRecord data)
        {
            if (ModelState.IsValid)
            {
                service.CreateOrUpdate(data);
                return Json(new { success = true });
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                var allErrors = ModelState.Values.SelectMany(v => v.Errors).Select(n => n.ErrorMessage);
                return Json(new { success = false, errors = allErrors });
            }
        }

        [HttpPost]
        public JsonResult RemoveStockPerStore(int storeId, int productId)
        {
            service.Delete(productId,storeId);
            return Json(new { success = true });
        }
    }
}
