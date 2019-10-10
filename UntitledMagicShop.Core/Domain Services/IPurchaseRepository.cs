using System;
using System.Collections.Generic;
using System.Text;
using UntitledMagicShop.Core.Entities;

namespace UntitledMagicShop.Core.Domain_Services
{
    public interface IPurchaseRepository
    {
        Purchase createPurchase(Purchase newPurchase);
        List<Purchase> readAllPurchases();
    }
}
