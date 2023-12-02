using Kata.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kata.Interfaces
{
    public interface IBasketService
    {
        IList<Order> AddToBasket(int itemId, int quantity);
        IList<Order> ViewBasket();
        float GetTotalBasketPrice();
    }
}
