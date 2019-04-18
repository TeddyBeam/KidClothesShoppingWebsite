using System;
using System.Linq;
using System.Collections.Generic;
using KidClothesShop.Core.ValueObjects;
using KidClothesShop.Core.Enums;

namespace KidClothesShop.Core.Entities
{
    public class Order : BaseEntity
    {
        public OrderStatus Status { get; set; }
        public string CustomerId { get; private set; }
        public DateTimeOffset OrderDate { get; private set; } = DateTimeOffset.Now;
        public Address ShipAddress { get; private set; }
        public IReadOnlyCollection<OrderDetails> OrderDetails => orderDetails.AsReadOnly();

        private readonly List<OrderDetails> orderDetails = new List<OrderDetails>();

        // Required by EF.
        private Order() {  }

        public Order(string customerId, Address shipAddress, List<OrderDetails> orderDetails)
            : this(customerId, DateTimeOffset.Now, shipAddress, orderDetails) { }

        public Order(string customerId, DateTimeOffset orderDate, Address shipAddress, List<OrderDetails> orderDetails)
        {
            CustomerId = customerId;
            OrderDate = orderDate;
            ShipAddress = shipAddress;
            this.orderDetails = orderDetails;
        }

        public decimal TotalPrice()
        {
            return orderDetails.Sum(detail => detail.UnitPrice * detail.Amount);
        }
    }
}
