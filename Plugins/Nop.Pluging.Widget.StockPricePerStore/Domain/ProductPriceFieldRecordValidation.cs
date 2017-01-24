using FluentValidation;
using Nop.Services.Localization;
using Nop.Plugin.Misc.StockPricerPerStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Misc.StockPricerPerStore.Domain
{
    public class ProductPriceFieldRecordValidation: AbstractValidator<ProductPriceFieldRecord>  
    {
        public ProductPriceFieldRecordValidation(ILocalizationService localizationService)
        {
            //RuleFor(n => n.StorePrice).NotEmpty().WithMessage(localizationService.GetResource("Nop.Plugin.Misc.StockPricerPerStore.Price"));
            //RuleFor(n => n.StoreOldPrice).NotEmpty().WithMessage(localizationService.GetResource("Nop.Plugin.Misc.StockPricerPerStore.OldPrice"));
            //RuleFor(n => n.StoreProductCost).NotEmpty().WithMessage(localizationService.GetResource("Nop.Plugin.Misc.StockPricerPerStore.ProductCost"));
        }
    }
}
