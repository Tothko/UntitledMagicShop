using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UntitledMagicShop.Core.Entities;

namespace UntitledMagicShop.Infrastructure.SQLData
{
    public static class DBInitializer
    {
        public static void SeedDB(UntitledMagicShopAppContext ctx)
        {

            ctx.Database.EnsureCreated();
            if (ctx.Users.Any())
            {
                return;   // DB has been seeded
            }
            SeedUsers(ctx);
            SeedItems(ctx);
            ctx.SaveChanges();
        }

        private static void SeedUsers(UntitledMagicShopAppContext ctx)
        {
            for (int i = 1; i <= 10; i++)
            {
                ctx.Users.Add(new User {
                    ID = i,
                    FirstName = "Marek",
                    LastName = "Surkus",
                    Email = "yolodude@fmail.com",
                    Password = "password",
                    Phone = "+4510203042",
                    Address = "Strandbygade 72, 6700 Esbjerg",
                }) ;

            }
        }

        private static void SeedItems(UntitledMagicShopAppContext ctx)
        {
            for (int i = 1; i <= 20; i++)
            {
                ctx.Items.Add(new Item
                {
                    ID = i,
                    Name = "MemeSword",
                    Price = 666.99,
                    OnStock = 42,
                    Type = "Sword",
                    Description = "For test purposes, do not sell",


                });
            }

        }

        private static void SeedPurchases(UntitledMagicShopAppContext ctx)
        {
            for (int i = 1; i <= 5; i++)
            {

            }

        }
    }
}
