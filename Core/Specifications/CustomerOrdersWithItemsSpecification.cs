using KidClothesShop.Core.Entities;

namespace KidClothesShop.Core.Specifications
{
    public class CustomerOrdersWithItemsSpecification : BaseSpecification<Order>
    {
        public CustomerOrdersWithItemsSpecification(string customerId)
            : base(o => o.CustomerId == customerId)
        {
            AddInclude(o => o.OrderDetails);
            AddInclude($"{nameof(Order.OrderDetails)}.{nameof(OrderDetails.ProductOrdered)}");
        }
    }
}
