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
            ctx.SaveChanges();
            SeedItems(ctx);
            ctx.SaveChanges();
            SeedPurchases(ctx);
            ctx.SaveChanges();
        }

        private static void SeedUsers(UntitledMagicShopAppContext ctx)
        {
            //for (int i = 1; i <= 10; i++)
            //{
                ctx.Users.Add(new User {
                    //ID = i,
                    FirstName = "Marek",
                    LastName = "Surkus",
                    Email = "yolodude@fmail.com",
                    Password = "password",
                    Phone = "+4510203042",
                    Address = "Strandbygade 72, 6700 Esbjerg",
                }) ;

            ctx.Users.Add(new User
            {
                //ID = i,
                FirstName = "Nedas",
                LastName = "Stancik",
                Email = "yolodude69@fmail.com",
                Password = "drowssap",
                Phone = "+45120103042",
                Address = "Strandbygade 54, 6700 Esbjerg",
            });

            ctx.Users.Add(new User
            {
                //ID = i,
                FirstName = "Christina Jancy",
                LastName = "Pedersen",
                Email = "cutegirl@fmail.com",
                Password = "password",
                Phone = "+4510203042",
                Address = "Fanostreet 11, 6700 Nordby",
            });

            ctx.Users.Add(new User
            {
                //ID = i,
                FirstName = "Olivia",
                LastName = "Owczarczyk",
                Email = "nicegirl@fmail.com",
                Password = "heslo",
                Phone = "+4510903042",
                Address = "Piast street 11, 4567 SomePolishCity",
            });

            //}
        }

        private static void SeedItems(UntitledMagicShopAppContext ctx)
        {
           // for (int i = 1; i <= 20; i++)
           //{
                ctx.Items.Add(new Item
                {
                    Name = "MemeSword",
                    Price = 666.99,
                    OnStock = 42,
                    Type = "Weapon",
                    Description = "For test purposes, do not sell",


                });
            ctx.Items.Add(new Item
            {
                Name = "KokotSword",
                Price = 100.99,
                OnStock = 100,
                Type = "Weapon",
                Description = "For ladies only, I HOPE",


            });
            ctx.Items.Add(new Item
            {
                Name = "Pamelky",
                Price = 1000.99,
                OnStock = 69,
                Type = "Tittie",
                Description = "Special item from Olivka",


            });
            ctx.Items.Add(new Item
            {
                Name = "Kratos's Axe",
                Price = 539.34,
                OnStock = 42,
                Type = "Weapon",
                Description = "Would not touch",


            });
            ctx.Items.Add(new Item
            {
                Name = "Health potion",
                Price = 20.00,
                OnStock = 888888,
                Type = "Potion",
                Description = "Restoers one health, its worth",


            });
            ctx.Items.Add(new Item
            {
                Name = "Marek ostrovid",
                Price = 1000000.00,
                OnStock = 1,
                Type = "Mount",
                Description = "With his škulky he can see everything",


            }); ctx.Items.Add(new Item
            {
                Name = "Christina",
                Price = 1000000.00,
                OnStock = 1,
                Type = "Pet",
                Description = "Most cutest of them all",



            });
            //}

        }

        private static void SeedPurchases(UntitledMagicShopAppContext ctx)
        {
            double somePrice = 0;
            List<Item> someList = new List<Item>();
            

            
            Purchase purchase0 = new Purchase
            {

                User = ctx.Users.SingleOrDefault(u => u.ID == 1),
                Items = someList,
                TotalPrice = somePrice



            };
            ctx.Purchases.Add(purchase0);
            ctx.Users.SingleOrDefault(u => u.ID == 1).Purchases.Add(purchase0);

            someList.Add(ctx.Items.SingleOrDefault(u => u.ID == 1));
            foreach (var item in someList)
            {
                somePrice += item.Price;
            }
            Purchase purchase1 = new Purchase
            {

                User = ctx.Users.SingleOrDefault(u => u.ID == 1),
                Items = someList,
                TotalPrice = somePrice



            };
            ctx.Purchases.Add(purchase1);
            ctx.Users.SingleOrDefault(u => u.ID == 1).Purchases.Add(purchase1);




            someList.Add(ctx.Items.SingleOrDefault(u => u.ID == 2));
            someList.Add(ctx.Items.SingleOrDefault(u => u.ID == 3));
            foreach (var item in someList)
            {
                somePrice += item.Price;
            }
            Purchase purchase2 = new Purchase
            {

                User = ctx.Users.SingleOrDefault(u => u.ID == 1),
                Items = someList,
                TotalPrice = somePrice



            };
            ctx.Purchases.Add(purchase2);
            ctx.Users.SingleOrDefault(u => u.ID == 1).Purchases.Add(purchase2);









            //for (int i = 1; i <= 5; i++)
            //{

            //}

        }
    }
}
