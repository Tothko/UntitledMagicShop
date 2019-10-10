using System;
using System.Collections.Generic;
using System.Text;
using UntitledMagicShop.Core.Entities;

namespace UntitledMagicShop.Core.Application_Services
{
    public interface IPurchaseService
    {
        Purchase createPurchase(Purchase newPurchase);
        List<Purchase> ReadAllPurchases();
    }
}
