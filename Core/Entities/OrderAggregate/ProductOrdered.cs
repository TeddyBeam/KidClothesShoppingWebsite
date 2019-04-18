using System;

namespace KidClothesShop.Core.Entities.OrderAggregate
{
    /// <summary>
    /// [Value Object]
    /// Represents a snapshot of the product that was odered.
    /// If product details change, details of the item that was part of a completed order should not be changed.
    /// </summary>
    public class ProductOrdered
    {
        public string ProductId { get; private set; }
        public string ProductName { get; private set; }
        public string PictureUri { get; private set; }

        // Required by EF.
        private ProductOrdered() { }

        public ProductOrdered(string productId, string productName, string pictureUri)
        {
            // TODO: Validate parameters.

            ProductId = productId;
            ProductName = productName;
            PictureUri = pictureUri;
        }
    }
}
