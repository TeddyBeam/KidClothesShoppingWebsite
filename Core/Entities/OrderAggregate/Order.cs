using System;
using System.Linq;
using System.Collections.Generic;

namespace KidClothesShop.Core.Entities.OrderAggregate
{
    public class Order : BaseEntity
    {
        public string CustomerId { get; private set; }
        public DateTimeOffset OrderDate { get; private set; } = DateTimeOffset.Now;
        public Address ShipAddress { get; private set; }
        public IReadOnlyCollection<OrderDetails> OrderDetails => orderDetails.AsReadOnly();

        private readonly List<OrderDetails> orderDetails = new List<OrderDetails>();

        // Required by EF.
        private Order() {  }

        public decimal TotalPrice()
        {
            return orderDetails.Sum(detail => detail.UnitPrice * detail.Amount);
        }
    }
}
