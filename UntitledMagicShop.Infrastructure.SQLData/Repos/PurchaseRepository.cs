using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UntitledMagicShop.Core.Domain_Services;
using UntitledMagicShop.Core.Entities;
using System.Linq;

namespace UntitledMagicShop.Infrastructure.SQLData.Repos
{
    public class PurchaseRepository : IPurchaseRepository
    {
        readonly UntitledMagicShopAppContext context;

        public PurchaseRepository(UntitledMagicShopAppContext ctx)
        {
            context = ctx;
        }
        public Purchase createPurchase(Purchase NewPurchase)
        {
            context.Attach(NewPurchase).State = EntityState.Added;
            context.SaveChanges();
            return NewPurchase;
        }


        public Purchase deletePurchase(Purchase PurchaseToDelete)
        {

            context.Remove(context.Find<Purchase>(PurchaseToDelete));
            context.SaveChanges();
            return PurchaseToDelete;
        }

        public Purchase getSinglePurchase(int Id)
        {
            return context.Purchases.Include(p => p.User).Include(p => p.Items).Where(p =>p.ID == Id).ToList().ElementAt(0);
        }

        public Purchase updatePurchase(Purchase PurchaseToUpdate)
        {
            if (context.Items.Find(PurchaseToUpdate) == null)
            {
                return null;
            }
            context.Entry(PurchaseToUpdate).CurrentValues.SetValues(PurchaseToUpdate);

            return PurchaseToUpdate;
        }

        public User GetUserOfPurchase(Purchase Purchase)
        {
            User User = context.Purchases.Find(Purchase).User;
            return User;
        }

        public List<Purchase> readAllPurchases()
        {

            return context.Purchases.Include(p => p.User).Include(p => p.Items).ToList();

        }
    }
}
