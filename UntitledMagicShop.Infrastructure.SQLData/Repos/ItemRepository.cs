using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UntitledMagicShop.Core.Entities;

namespace UntitledMagicShop.Infrastructure.SQLData.Repos
{
    public class ItemRepository : IItemRepository
    {

        readonly UntitledMagicShopAppContext context;

        public ItemRepository(UntitledMagicShopAppContext ctx)
        {
            context = ctx;
        }
        public Item createItem(Item newItem)
        {
            context.Attach(newItem).State = EntityState.Added;
            context.SaveChanges();
            return newItem;
        }

        public Item deleteItem(Item itemToDelete)
        {
            
            context.Remove(context.Find<Item>(itemToDelete));
            context.SaveChanges();
            return itemToDelete;
        }

        public List<Item> getAllItemsByType(string type)
        {
            List<Item> ItemsByType = new List<Item>();
            foreach (var item in context.Items)
            {
                if (item.Type == type) ItemsByType.Add(item);

            }
            return ItemsByType;
        }

        public Item getSingleItem(int Id)
        {
            return context.Items.Find(Id);
        }

        public IEnumerable<Item> ReadAll()
        {
            return context.Items;
        }

        public Item updateItem(Item itemToUpdate)
        {
            
            return itemToUpdate;
        }
    }
}
