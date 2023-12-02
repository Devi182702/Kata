using Kata.Interfaces;
using Kata.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata.Implementations
{
    public class ItemService : IItemService
    {
        public Item GetItem(int itemId)
        {
            return GetItems().FirstOrDefault(eachItem => eachItem.ItemId == itemId);
        }

        public float GetItemPrice(int itemId)
        {
            throw new NotImplementedException();
        }

        public IList<Item> GetItems()
        {
            IList<Item> items = new List<Item>()
            {
                 new Item(){ ItemId = 1, ItemName="ITEM A", UnitPrice = 10},
                new Item(){ ItemId = 2, ItemName="ITEM B", UnitPrice = 15},
                new Item(){ ItemId = 3, ItemName="ITEM C", UnitPrice = 40},
                new Item(){ ItemId = 4, ItemName="ITEM D", UnitPrice = 55}
            };
            return items;            
        }
    }
}
