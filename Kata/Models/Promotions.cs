namespace Kata.Models
{
    public class Promotions
    {
        private int itemId { get; set; }
        private int minimumQuantity { get; set; }
        private int discountPerc { get; set; }
        private float offerPrice { get; set; }

        public int ItemId
        {
            get { return itemId; }
            set { itemId = value; }
        }
        public int MinimumQuantity
        {
            get { return minimumQuantity; }
            set { minimumQuantity = value; }
        }
        public int DiscountPerc
        {
            get { return discountPerc; }
            set { discountPerc = value; }
        }
        public float OfferPrice
        {
            get { return offerPrice; }
            set { offerPrice = value; }
        }
    }
}
