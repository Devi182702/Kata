using Kata.Interfaces;
using Kata.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata.Implementations
{
    public class BasketService : IBasketService
    {
        IOrderService orderService;
        //Using Dependency Injection
        public BasketService(IOrderService orderService)
        {
            this.orderService = orderService;
        }
        IList<Order> basket = new List<Order>();
        public IList<Order> AddToBasket(int itemId, int quantity)
        {
            try
            {
                Order existingOrder = basket.FirstOrDefault(eachOrder => eachOrder.ItemId == itemId);
                if (existingOrder == null)
                {
                    Order orderObj = orderService.CreateOrder(itemId, quantity);
                    basket.Add(orderObj);                   
                }
                else
                {
                    orderService.UpdateOrder(existingOrder, itemId, quantity);
                }
                return basket;
            }
            catch(Exception e)
            {
                throw e;
            }
            
        }
        public IList<Order> ViewBasket()
        {
            return this.basket;
        }

        public float GetTotalBasketPrice()
        {
            return basket.Sum(order => order.TotalPrice);

        }
    }
}
