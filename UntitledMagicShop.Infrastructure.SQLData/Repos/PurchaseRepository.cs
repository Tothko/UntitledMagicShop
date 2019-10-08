using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UntitledMagicShop.Core.Domain_Services;
using UntitledMagicShop.Core.Entities;

namespace UntitledMagicShop.Infrastructure.SQLData.Repos
{
    public class PurchaseRepository : IPurchaseRepository
    {
        readonly UntitledMagicShopAppContext context;

        public PurchaseRepository(UntitledMagicShopAppContext ctx)
        {
            context = ctx;
        }
        public Purchase createPurchase(Purchase newPurchase)
        {
            context.Attach(newPurchase).State = EntityState.Added;
            context.SaveChanges();
            return newPurchase;
        }


        public Purchase deletePurchase(Purchase PurchaseToDelete)
        {

            context.Remove(context.Find<Purchase>(PurchaseToDelete));
            context.SaveChanges();
            return PurchaseToDelete;
        }

        public Purchase getSinglePurchase(int Id)
        {
            return context.Purchases.Find(Id);
        }

        public IEnumerable<Purchase> ReadAll()
        {
            return context.Purchases;
        }

        public Purchase updatePurchase(Purchase PurchaseToUpdate)
        {

            return PurchaseToUpdate;
        }

    }
}
