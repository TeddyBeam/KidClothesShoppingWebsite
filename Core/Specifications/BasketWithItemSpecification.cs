using System;
using System.Linq.Expressions;
using KidClothesShop.Core.Entities;

namespace KidClothesShop.Core.Specifications
{
    public class BasketWithItemSpecification : BaseSpecification<Basket>
    {
        public BasketWithItemSpecification(int basketId) 
            : base(basket => basket.Id == basketId)
        {
            AddInclude(basket => basket.Details);
        }

        public BasketWithItemSpecification(string customerId)
            : base(basket => basket.CustomerId == customerId)
        {
            AddInclude(basket => basket.Details);
        }
    }
}
