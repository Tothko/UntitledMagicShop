using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public Item deleteItem(int ID)
        {
            var itemToRemove = context.Items.SingleOrDefault(x => x.ID == ID);
            context.Remove(itemToRemove);
            context.SaveChanges();
            return itemToRemove;
        }

        public List<Item> getAllItems()
        {
          
            return context.Items.Include(i => i.Images).ToList();
        }

        public List<Item> getAllItemsByType(string Type)
        {
            List<Item> ItemsByType = new List<Item>();
            foreach (var item in context.Items)
            {
                if (item.Type.ToLower() == Type.ToLower()) ItemsByType.Add(item);

            }
            return ItemsByType;
        }

        public IEnumerable<Item> getFiltered(Filter filter)
        {

           
            List<Item> paging = new List<Item>();
            if (filter != null && filter.CurrentPage > 0 && filter.ItemPrPage > 1)
            {
                paging = context.Items
                    .Skip((filter.CurrentPage - 1) * filter.ItemPrPage)
                    .Take(filter.ItemPrPage).ToList();
            }



            if (filter.SelectType != null )
            {
                return getAllItemsByType(filter.SelectType);
            }
            else if (filter != null && filter.CurrentPage > 0 && filter.ItemPrPage > 1 && filter.SortBy != null && filter.SortOrder == "desc")
            {
                return paging.OrderByDescending(i => FieldToSort(i, filter));
            }
            else if (filter != null && filter.CurrentPage > 0 && filter.ItemPrPage > 1 && filter.SortBy != null)
            {
                return paging.OrderBy(i => FieldToSort(i, filter));
            }
            else if (filter != null && filter.CurrentPage > 0 && filter.ItemPrPage > 1)
            {
                return paging;
            }
            else return context.Items;
        }

        public object FieldToSort(Item p, Filter filter)
        {
            if (filter.SortBy == null)
                return null;

            if (p == null)
                p = new Item();

            if (filter.SortBy.ToLower().Equals("id"))
                return p.ID;
            else if (filter.SortBy.ToLower().Equals("name"))
                return p.Name;
            else if (filter.SortBy.ToLower().Equals("type"))
                return p.Type;
            else if (filter.SortBy.ToLower().Equals("price"))
                return p.Price;
            else return null;
        }

        public Item getSingleItem(int Id)
        {
            return context.Items.Include(i => i.Images).Where(i => i.ID == Id).ToList().ElementAt(0);
        }

        

        public IEnumerable<Item> ReadAll()
        {
            return context.Items;
        }

        public Item updateItem(Item itemToUpdate)
        {
            var entity = context.Items.Find(itemToUpdate.ID);
            if (entity != null)
            {
                context.Entry(entity).CurrentValues.SetValues(itemToUpdate);
                context.SaveChanges();
                return itemToUpdate;
            }
            return null;
        }
    }
}
