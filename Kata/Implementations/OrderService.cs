using Kata.Interfaces;
using Kata.Models;
using System.Collections.Generic;
using System.Linq;

namespace Kata.Implementations
{
    public class OrderService : IOrderService
    {
        IItemService itemService;
        //Using Dependency Injection
        public OrderService(IItemService itemService)
        {
            this.itemService = itemService;          
        }
        public Order CreateOrder(int itemId, int quantity)
        {
            Item itemObj = itemService.GetItem(itemId);

            Order currentOrder = new Order();
            currentOrder.ItemId = itemId;
            currentOrder.ItemName = itemObj.ItemName;
            currentOrder.Quantity = quantity;
            currentOrder.TotalPrice = ApplyPromotions(itemId, quantity, itemObj.UnitPrice);                  
            return currentOrder;
            
        }

        public float ApplyPromotions(int itemId, int quantity, float unitPrice)
        {
            float netAmount = 0;
            //This list will have items that has some kind of offer 
            IList<Promotions> promotionList = new List<Promotions>()
            {
                new Promotions(){ ItemId = 2, MinimumQuantity = 3, DiscountPerc = 0, OfferPrice = 40},
                new Promotions(){ ItemId = 4, MinimumQuantity= 2,  DiscountPerc = 25, OfferPrice = 0}
            };
            Promotions promoObj = promotionList.FirstOrDefault(eachOrder => eachOrder.ItemId == itemId);
            if (promoObj is null)
            {
                netAmount = quantity * unitPrice;
            }
            else
            {
                if (promoObj.OfferPrice > 0)
                {
                    int quantityForDiscount = quantity / promoObj.MinimumQuantity;
                    int quantityForFullPrice = quantity % promoObj.MinimumQuantity;
                    netAmount = quantityForDiscount * promoObj.OfferPrice;
                    netAmount += (quantityForFullPrice * unitPrice);
                }
                else if (promoObj.DiscountPerc > 0)
                {
                    int quantityForFullPriceItemD = quantity % promoObj.MinimumQuantity;
                    int quantityForDiscountItemD = quantity - quantityForFullPriceItemD;
                    netAmount = ((unitPrice * quantityForDiscountItemD) - ((float)promoObj.DiscountPerc / 100) * (unitPrice * quantityForDiscountItemD));
                    netAmount += (quantityForFullPriceItemD * unitPrice);
                }
            }
            return netAmount;
        }

        public void UpdateOrder(Order existingOrder, int itemId, int quantity)
        {

            Item itemObj = itemService.GetItem(itemId);
            int newQuantity = existingOrder.Quantity + quantity;
            //float totalPrice = newQuantity * itemObj.UnitPrice;
            float totalPrice = ApplyPromotions(itemId, newQuantity, itemObj.UnitPrice);
            existingOrder.TotalPrice = totalPrice;
            existingOrder.Quantity = newQuantity;
        }
    }
}
