using Kata.Controllers;
using Kata.Implementations;
using Kata.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KataTest
{
    [TestClass]
    public class ItemControllerTest
    {
        ItemsController controller;

        [TestInitialize()]
        public void BeforeEach()
        {
            IItemService itemService = new ItemService();            
            IOrderService orderService = new OrderService(itemService);
            IBasketService basketService = new BasketService(orderService);
            controller = new ItemsController(itemService, basketService);
        }
        [TestMethod]
        public void VerifyIndex()
        {
            ViewResult result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
        }
    }
}
