using Kata.Implementations;
using Kata.Interfaces;
using Kata.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kata.Controllers
{
    public class ItemsController : Controller
    {
        IItemService itemService;
        IBasketService basketService;
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
