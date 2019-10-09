using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using UntitledMagicShop.Core.Application_Services;
using UntitledMagicShop.Core.Entities;

namespace UntitledMagicShop.Core.Application_Services_Impl
{
    public class ItemService : IItemService
    {
        private IItemRepository _repo;
        public ItemService(IItemRepository repo)
        {
            _repo = repo;
        }
        public Item createItem(Item newItem)
        {
            if (validateItem(newItem))
            {
                return _repo.createItem(newItem);
            }
            else
            {
                throw new NotImplementedException(); //Throw normal exception
            }
        }

        private bool validateItem(Item newItem)
        {
            //return Regex.Replace(newItem.name(), "[^a-zA-Z0-9_.]+", "", RegexOptions.Compiled);
            throw new NotImplementedException();

        }

        public Item deleteItem(Item itemToDelete)
        {
            return _repo.deleteItem(itemToDelete);
        }

        public List<Item> listAllItems()
        {
            return _repo.getAllItems();
        }

        public Item listSingleItem(int ID)
        {
            return _repo.getSingleItem(ID);
        }

        public List<Item> listItemsByType(string Type)
        {
            return _repo.getAllItemsByType(Type);
        }

        public Item updateItem(Item itemToUpdate)
        {
            return _repo.updateItem(itemToUpdate);
        }

        public IEnumerable<Item> ReadAll()
        {
            return _repo.ReadAll();
        }

        public IEnumerable<Item> GetFilteredItems(Filter filter)
        {
            return _repo.getFiltered(filter);
        }
    }
}
