using Nop.Core.Data;
using Nop.Plugin.Misc.StockPricerPerStore.Domain;
using Nop.Services.Catalog;
using Nop.Web.Framework.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Nop.Plugin.Misc.StockPricerPerStore.ViewModels;
using Nop.Services.Stores;
using Nop.Plugin.Misc.StockPricerPerStore.Services;
using System.Net;
using System.Web.Script.Serialization;

namespace Nop.Plugin.Misc.StockPricerPerStore.Controllers
{
    public class StockPricerPerStoreController : BasePluginController
    {
        private IStoreProductService storeService;
        private IProductService productService;
        private IStoreMappingService storeMappingService;
        public StockPricerPerStoreController(IStoreProductService storeService, IProductService productService, IStoreMappingService storeMappingService)
        {
            this.storeService = storeService;
            this.productService = productService;
            this.storeMappingService = storeMappingService;
        }

        public ActionResult EditStockPricerPerStore(int productId)
        {
            StockPricerPerStoreViewModel model = new StockPricerPerStoreViewModel();
            var product = productService.GetProductById(productId);
            var stores = storeMappingService.GetStoreMappings(product).Select(n => new StoreViewModel()
            {
                Id = n.Store.Id,
                Name = n.Store.Name
            });
            model.Record = storeService.GetByStoreOrDefault(productId, stores.FirstOrDefault().Id);
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            model.StoresJson = serializer.Serialize(stores);
            return View("~/Plugins/Misc.StockPricerPerStore/Views/StockPricerPerStore.cshtml", model);
        }

        [HttpPost]
        public JsonResult CreateUpdateStockPricerPerStore(ProductPriceFieldRecord data)
        {
            if (ModelState.IsValid)
            {
                storeService.CreateUpdateStockPricerPerStore(data);
                return Json(new { success = true });
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                var allErrors = ModelState.Values.SelectMany(v => v.Errors).Select(n=>n.ErrorMessage);
                return Json(new { success = false, errors = allErrors });
            }         
        }

        [HttpPost]
        public JsonResult RemoveStockPricerPerStore(int productId, int storeId)
        {
            storeService.RemoveStockPricerPerStore(productId, storeId);
            var data = storeService.GetByStoreOrDefault(productId, null);
            return Json(data);
        }

        [HttpPost]
        public JsonResult GetProductFieldsByStore(int productId, int storeId)
        {
            var data = storeService.GetByStoreOrDefault(productId, storeId);
            return Json(data);
        }
    }
}
