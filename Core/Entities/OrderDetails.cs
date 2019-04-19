using KidClothesShop.Core.ValueObjects;

namespace KidClothesShop.Core.Entities
{
    public class OrderDetails : BaseEntity
    {
        public ProductOrdered ProductOrdered { get; private set; }
        public decimal UnitPrice { get; private set; }
        public int Amount { get; private set; }

        // Required by EF.
        private OrderDetails() { }

        public OrderDetails(ProductOrdered productOrdered, decimal unitPrice, int amount)
        {
            // TODO: Validate parameters.

            ProductOrdered = productOrdered;
            UnitPrice = unitPrice;
            Amount = amount;
        }
    }
}
