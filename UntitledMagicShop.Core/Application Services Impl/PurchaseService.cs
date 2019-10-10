using System;
using System.Collections.Generic;
using System.Text;
using UntitledMagicShop.Core.Application_Services;
using UntitledMagicShop.Core.Domain_Services;
using UntitledMagicShop.Core.Entities;

namespace UntitledMagicShop.Core.Application_Services_Impl
{
    public class PurchaseService : IPurchaseService
    {
        private IPurchaseRepository _repo;
        public PurchaseService(IPurchaseRepository repo)
        {
            _repo = repo;
        }
        public Purchase createPurchase(Purchase newPurchase)
        {
            return _repo.createPurchase(newPurchase);
        }

        public List<Purchase> ReadAllPurchases()
        {
            return _repo.readAllPurchases();
        }
    }
}
