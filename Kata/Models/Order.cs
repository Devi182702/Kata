using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Kata.Models
{
    public class Order
    {
        private int itemId {  get; set; }
        private string itemName { get; set; }       
        private float totalPrice { get; set; }
        private int quantity { get; set; }

        public int ItemId
        {
            get { return itemId; }
            set { itemId = value; }
        }

        public string ItemName
        {
            get { return itemName; }
            set { itemName = value; }
        }

        [DisplayName("Item Price")]
        public float TotalPrice
        {
            get { return totalPrice; }
            set { totalPrice = value; }
        }    

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

    }
}
