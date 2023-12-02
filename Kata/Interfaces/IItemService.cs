using Kata.Models;
using System.Collections.Generic;

namespace Kata.Interfaces
{
    public interface IItemService
    {
        IList<Item> GetItems();
        float GetItemPrice(int itemId);
        Item GetItem(int itemId);
    }
}
