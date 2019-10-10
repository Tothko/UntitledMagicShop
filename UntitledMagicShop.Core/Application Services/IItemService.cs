using System;
using System.Collections.Generic;
using System.Text;
using UntitledMagicShop.Core.Entities;

namespace UntitledMagicShop.Core.Application_Services
{
    public interface IItemService
    {
        List<Item> listAllItems();

        List<Item> listItemsByType(string Type);
        Item listSingleItem(int ID);

        Item createItem(Item newItem);

        Item updateItem(Item itemToUpdate);

        Item deleteItem(int ID);

        IEnumerable<Item> ReadAll();
        IEnumerable<Item> GetFilteredItems(Filter filter);
        
    }
}
