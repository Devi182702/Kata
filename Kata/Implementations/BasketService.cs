using Kata.Interfaces;
using Kata.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kata.Implementations
{
    public class BasketService : IBasketService
    {
        IOrderService orderService;
        public BasketService(IOrderService orderService)
        {
            this.orderService = orderService;
        }
        IList<Order> basket = new List<Order>();
        public IList<Order> AddToBasket(int itemId, int quantity)
        {            
            Order orderObj = orderService.CreateOrder(itemId, quantity);
            basket.Add(orderObj);
            return basket;
        }
        public IList<Order> ViewBasket()
        {
            return this.basket;
        }
    }
}
