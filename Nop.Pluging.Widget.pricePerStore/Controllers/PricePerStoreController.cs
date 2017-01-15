using Nop.Core.Data;
using Nop.Plugin.Misc.PricePerStore.Domain;
using Nop.Services.Catalog;
using Nop.Web.Framework.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Nop.Plugin.Misc.PricePerStore.ViewModels;
using Nop.Services.Stores;
using System.Web.Script.Serialization;
using Nop.Plugin.Misc.PricePerStore.Services;
using System.Net;

namespace Nop.Plugin.Misc.PricePerStore.Controllers
{
    public class PricePerStoreController : BasePluginController
    {
        private IStoreProductService storeService;
        private IProductService productService;
        private IStoreMappingService storeMappingService;
        public PricePerStoreController(IStoreProductService storeService, IProductService productService, IStoreMappingService storeMappingService)
        {
            this.storeService = storeService;
            this.productService = productService;
            this.storeMappingService = storeMappingService;
        }

        public ActionResult EditPricePerStore(int productId)
        {
            PricePerStoreViewModel model = new PricePerStoreViewModel();
            var product = productService.GetProductById(productId);
            var stores = storeMappingService.GetStoreMappings(product).Select(n => new StoreViewModel()
            {
                Id = n.Store.Id,
                Name = n.Store.Name
            });
            model.Record = storeService.GetByStoreOrDefault(productId, stores.FirstOrDefault().Id);
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            model.StoresJson = serializer.Serialize(stores);
            return View("~/Plugins/Misc.PricePerStore/Views/PricePerStore.cshtml", model);
        }

        [HttpPost]
        public JsonResult CreateUpdatePricePerStore(ProductPriceFieldRecord data)
        {
            if (ModelState.IsValid)
            {
                storeService.CreateUpdatePricePerStore(data);
                return Json(new { success = false });
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                var allErrors = ModelState.Values.SelectMany(v => v.Errors).Select(n=>n.ErrorMessage);
                return Json(new { success = false, errors = allErrors });
            }

            
        }

        [HttpPost]
        public JsonResult RemovePricePerStore(int productId, int storeId)
        {
            storeService.RemovePricePerStore(productId, storeId);
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
