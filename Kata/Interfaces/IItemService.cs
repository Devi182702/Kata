using Kata.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kata.Interfaces
{
    public interface IItemService
    {
        IList<Item> GetItems();
        float GetItemPrice(int itemId);
        Item GetItem(int itemId);
    }
}
