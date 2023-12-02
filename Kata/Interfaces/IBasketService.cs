using Kata.Models;
using System.Collections.Generic;

namespace Kata.Interfaces
{
    public interface IBasketService
    {
        IList<Order> AddToBasket(int itemId, int quantity);
        IList<Order> ViewBasket();
        float GetTotalBasketPrice();
    }
}
