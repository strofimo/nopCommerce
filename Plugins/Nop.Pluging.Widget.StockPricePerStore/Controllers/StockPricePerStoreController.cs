using Nop.Core.Data;
using Nop.Plugin.Misc.StockPricePerStore.Domain;
using Nop.Services.Catalog;
using Nop.Web.Framework.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Nop.Plugin.Misc.StockPricePerStore.ViewModels;
using Nop.Services.Stores;
using Nop.Plugin.Misc.StockPricePerStore.Services;
using System.Net;
using System.Web.Script.Serialization;
using Nop.Services.Localization;
using Nop.Services.Shipping;

namespace Nop.Plugin.Misc.StockPricePerStore.Controllers
{
    public class StockPricePerStoreController : BasePluginController
    {
        private IProductService productService;
        private IStoreMappingService storeMappingService;
        private IStockProductService stockService;
        private IPriceProductService priceService;
        private ILocalizationService localizationService;
        private IShippingService shippingService;

        public StockPricePerStoreController( IProductService productService, ILocalizationService localizationService, IShippingService shippingService,
            IStoreMappingService storeMappingService,IStockProductService stockService, IPriceProductService priceService)
        {
            this.productService = productService;
            this.storeMappingService = storeMappingService;
            this.stockService = stockService;
            this.priceService = priceService;
            this.localizationService = localizationService;
            this.shippingService = shippingService;
        }

        public ActionResult EditStockPricePerStore(int productId,int storeId)
        {
            StockPricePerStoreViewModel model = new StockPricePerStoreViewModel() { WarehouseList = new List<SelectListItem>() };
            var product = productService.GetProductById(productId);
            model.PriceRecord = priceService.GetByStoreOrDefault(productId, storeId);
            model.StockRecord = stockService.GetByStoreOrDefault(productId, storeId);
            model.WarehouseList.Add(new SelectListItem { Text = localizationService.GetResource("Admin.Common.All"), Value = "0" });
            foreach (var w in shippingService.GetAllWarehouses())
            {
                model.WarehouseList.Add(new SelectListItem { Text = w.Name, Value = w.Id.ToString() });
            }
            model.StoreId = storeId;
            model.ProductId = productId;
            return View("~/Plugins/Misc.StockPricePerStore/Views/StockPricePerStore.cshtml", model);
        }

        [HttpPost]
        public JsonResult CreateUpdateStockPricePerStore(int productId,int storeId, ProductPriceFieldRecord priceField, ProductInventoryFieldRecord stockField)
        {
            if (ModelState.IsValid)
            {
                if (priceField != null)
                {
                    priceService.CreateUpdateStockPricePerStore(priceField);
                }
                else
                {
                    this.priceService.RemoveStockPricePerStore(productId, storeId);
                }
                if (stockField != null)
                {
                    stockService.CreateOrUpdate(stockField);
                }
                else
                {
                    stockService.Delete(productId, storeId);
                }
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
        public JsonResult RemoveStockPerStore(int productId, int storeId)
        {
            stockService.Delete(productId, storeId);
            var data = stockService.GetByStoreOrDefault(productId, null);
            return Json(data);
        }

        [HttpPost]
        public JsonResult RemovePricePerStore(int productId,int storeId)
        {
            this.priceService.RemoveStockPricePerStore(productId, storeId);
            var data = priceService.GetByStoreOrDefault(productId, null);
            return Json(data);
        }
    }
}
