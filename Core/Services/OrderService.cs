using System.Threading.Tasks;
using System.Collections.Generic;
using KidClothesShop.Core.Interfaces;
using KidClothesShop.Core.ValueObjects;
using KidClothesShop.Core.Entities;

namespace KidClothesShop.Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly IAsyncRepository<Order> orderRepository;
        private readonly IAsyncRepository<Basket> basketRepository;
        private readonly IAsyncRepository<Product> productRepository;

        public OrderService(IAsyncRepository<Basket> basketRepository,
                            IAsyncRepository<Product> productRepository,
                            IAsyncRepository<Order> orderRepository)
        {
            this.orderRepository = orderRepository;
            this.basketRepository = basketRepository;
            this.productRepository = productRepository;
        }

        public async Task CreateOrderAsync(int basketId, Address shippingAddress)
        {
            var basket = await basketRepository.SelectByIdAsync(basketId);
            if (basket == null)
                return; // TODO: Maybe throw an exception here?

            var items = new List<OrderDetails>();
            foreach (var item in basket.Details)
            {
                var product = await productRepository.SelectByIdAsync(item.ProductId);
                var productOrdered = new ProductOrdered(product.Id, product.Name, product.PictureUri);
                var orderDetails = new OrderDetails(productOrdered, item.UnitPrice, item.Quantity);
                items.Add(orderDetails);
            }
            var order = new Order(basket.CustomerId, shippingAddress, items);

            await orderRepository.AddAsync(order);
        }
    }
}
