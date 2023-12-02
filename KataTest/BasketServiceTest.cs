using Kata.Controllers;
using Kata.Implementations;
using Kata.Interfaces;
using Kata.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataTest
{
    [TestClass]
    public class BasketServiceTest
    {
        IBasketService basketService;
        ItemsController controller;
        [TestInitialize()]
        public void BeforeEach()
        {
            IItemService itemService = new ItemService();
            IOrderService orderService = new OrderService(itemService);
            basketService = new BasketService(orderService);
            controller = new ItemsController(itemService, basketService);
        }

        [TestMethod]
        public void VerifyAddToBasket()
        {
            //Arrange
            int itemId = 1;
            int quantity = 3;

            //Act
            IList<Order> basket = basketService.AddToBasket(itemId, quantity);

            //Assert
            Assert.AreEqual(1, basket.Count);
            Assert.AreEqual(30, basket[0].TotalPrice);
        }

        [TestMethod]
        public void VerifyAllItemPrice()
        {
            //Arrange
            int itemAId = 1;
            int itemAQuantity = 2;

            int itemBId = 2;
            int itemBQuantity = 3;

            int itemCId = 3;
            int itemCQuantity = 5;

            int itemDId = 4;
            int itemDQuantity = 2;

            //to check for Item D when the basket already has 2 items
            int itemQuantity = 1;


         
            //Act
            IList<Order> basket = basketService.AddToBasket(itemAId, itemAQuantity);
            Assert.AreEqual(20, basket[0].TotalPrice);

            basket = basketService.AddToBasket(itemBId, itemBQuantity);
            Assert.AreEqual(40, basket[1].TotalPrice);

            basket = basketService.AddToBasket(itemCId, itemCQuantity);
            Assert.AreEqual(200, basket[2].TotalPrice);

            basket = basketService.AddToBasket(itemDId, itemDQuantity);
            Assert.AreEqual(82.5, basket[3].TotalPrice);

           
            //Assert
            Assert.AreEqual(342.5, basketService.GetTotalBasketPrice());

            //To check the update scenario if same item is added again to the basket
            basket = basketService.AddToBasket(itemDId, itemQuantity);
            Assert.AreEqual(137.5, basket[3].TotalPrice);

            Assert.AreEqual(397.5, basketService.GetTotalBasketPrice());
        }
    }
}
