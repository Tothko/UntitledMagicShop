using System;
using System.Collections.Generic;
using System.Text;

namespace UntitledMagicShop.Core.Entities
{
    public interface IItemRepository
    {
        Item createItem(Item newItem);
        Item deleteItem(Item itemToDelete);
        List<Item> getAllItemsByType(string type);
        List<Item> getAllItems();
        Item getSingleItem(int iD);
        Item updateItem(Item itemToUpdate);
        IEnumerable<Item> ReadAll();
        IEnumerable<Item> getFiltered(Filter filter);
    }
}
