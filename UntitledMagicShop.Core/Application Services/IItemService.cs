using System;
using System.Collections.Generic;
using System.Text;
using UntitledMagicShop.Core.Entities;

namespace UntitledMagicShop.Core.Application_Services
{
    public interface IItemService
    {
        List<Item> listAllItems(string type);

        Item listSingleItem(int ID);

        Item createItem(Item newItem);

        Item updateItem(Item itemToUpdate);

        Item deleteItem(Item itemToDelete);

        IEnumerable<Item> ReadAll();

    }
}
