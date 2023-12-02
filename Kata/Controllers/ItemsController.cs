using Kata.Interfaces;
using Kata.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Kata.Controllers
{
    public class ItemsController : Controller
    {
        IItemService itemService;
        IBasketService basketService;

        //Using Dependency Injection
        public ItemsController(IItemService itemService, IBasketService basketService)
        {
            this.itemService = itemService;
            this.basketService = basketService;
        }

        // GET: ItemsController
        public ActionResult Index()
        {
            IList<Item> stockItems = this.itemService.GetItems();
            return View(stockItems);
        }

        [HttpPost]
        public ActionResult AddToCart([FromBody] Item selectedItem)
        {
            IList<Order> basketItems = basketService.AddToBasket(selectedItem.ItemId, selectedItem.SelectedQuantity);
            return View("Basket", basketItems);
        }
        public ActionResult ViewBasket()
        {

            IList<Order> basketItems = basketService.ViewBasket();
            ViewBag.TotalBasketPrice = basketService.GetTotalBasketPrice();
            return View("Basket", basketItems);
        }
    }
}
