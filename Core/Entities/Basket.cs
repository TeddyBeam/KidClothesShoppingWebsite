using System.Linq;
using System.Collections.Generic;

namespace KidClothesShop.Core.Entities
{
    public class Basket : BaseEntity
    {
        public string CustomerId { get; set; }
        public IReadOnlyCollection<BasketDetails> Details => details.AsReadOnly();

        private readonly List<BasketDetails> details = new List<BasketDetails>();

        public void AddDetail(int productId, decimal unitPrice, int quantity = 1)
        {
            // Add new product to the basket if it doesn't exist.
            if (!Details.Any(d => d.ProductId == productId))
            {
                details.Add(new BasketDetails()
                {
                    ProductId = productId,
                    UnitPrice = unitPrice,
                    Quantity = quantity
                });
                return;
            }

            // Otherwise find the existing detail and update its quantity.
            var existingDetail = Details.FirstOrDefault(i => i.ProductId == productId);
            existingDetail.Quantity += quantity;
        }
    }
}
