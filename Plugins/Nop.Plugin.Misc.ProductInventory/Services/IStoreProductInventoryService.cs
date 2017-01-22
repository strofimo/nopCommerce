using Nop.Plugin.Misc.ProductInventory.ViewModels;
using Nop.Plugin.Misc.StoreProductInventory.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Misc.ProductInventory.Services
{
    public interface IStoreProductInventoryService
    {
        StoreProductInventoryFieldRecord GetByStoreOrDefault(int productId,int storeId);
        void CreateOrUpdate(StoreProductInventoryFieldRecord data);
        void Delete(int productId, int storeId);
    }
}
