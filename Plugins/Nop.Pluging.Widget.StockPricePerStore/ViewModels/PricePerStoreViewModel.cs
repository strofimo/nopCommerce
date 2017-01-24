using Nop.Plugin.Misc.StockPricerPerStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nop.Plugin.Misc.StockPricerPerStore.ViewModels
{
    public class StockPricerPerStoreViewModel
    {
        public string StoresJson { get; set; }
        public ProductPriceFieldRecord Record { get; set; }
    }
}