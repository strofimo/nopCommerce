using Nop.Plugin.Misc.PricePerStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nop.Plugin.Misc.PricePerStore.ViewModels
{
    public class PricePerStoreViewModel
    {
        public string StoresJson { get; set; }
        public ProductPriceFieldRecord Record { get; set; }
    }
}