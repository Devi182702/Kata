using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kata.Models
{
    public class Item
    {
        private int itemId { get; set; }
        private string itemName { get; set; }
        private float unitPrice { get; set; }
        private int selectedQuantity { get; set; }

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
        public float UnitPrice
        {
            get { return unitPrice; }
            set { unitPrice = value; }
        }
        public int SelectedQuantity
        {
            get { return selectedQuantity; }
            set { selectedQuantity = value; }
        }
    }
}
