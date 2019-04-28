using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using KidClothesShop.Core.Interfaces;
using KidClothesShop.Core.Entities;
using KidClothesShop.Core.Specifications;

namespace KidClothesShop.Core.Services
{
    public class BasketService : IBasketService
    {
        private readonly IAsyncRepository<Basket> basketRepository;
        private readonly IAsyncRepository<BasketDetails> basketDetailsRepository;

        public BasketService(IAsyncRepository<Basket> basketRepository, IAsyncRepository<BasketDetails> basketDetailsRepository)
        {
            this.basketRepository = basketRepository;
            this.basketDetailsRepository = basketDetailsRepository;
        }

        public async Task AddItemToBasketAsync(int basketId, int productId, decimal price, int quantity)
        {
            var basket = await basketRepository.SelectByIdAsync(basketId);
            basket.AddDetail(productId, price, quantity);
            await basketRepository.UpdateAsync(basket);
        }

        public async Task DeleteBasketAsync(int basketId)
        {
            var basket = await basketRepository.SelectByIdAsync(basketId);
            foreach (var detail in basket.Details)
                await basketDetailsRepository.DeleteAsync(detail);
            await basketRepository.DeleteAsync(basket);
        }

        public async Task<int> GetBasketItemCountAsync(string customerId)
        {
            // TODO: Validate customerId.

            var specification = new BasketWithItemSpecification(customerId);
            var basket = (await basketRepository.SelectAsync(specification)).FirstOrDefault();
            return basket != null ? basket.Details.Sum(detail => detail.Quantity) : 0;
        }

        /// <param name="quantities">
        /// Details quantity: key = detail's id, value = quantity. 
        /// </param>
        public async Task SetQuantitiesAsync(int basketId, Dictionary<string, int> quantities)
        {
            // TODO: Validate quantities.

            var basket = await basketRepository.SelectByIdAsync(basketId);
            if (basket == null)
                return; // TODO: Maybe throw an exception here??

            foreach(var detail in basket.Details)
                if (quantities.TryGetValue(detail.Id.ToString(), out var quantity))
                    detail.Quantity = quantity;

            await basketRepository.UpdateAsync(basket);
        }

        public async Task TransferBasketAsync(string anonymousId, string customerId)
        {
            // TODO: Validate anonymousId, customerId.

            var specification = new BasketWithItemSpecification(anonymousId);
            var basket = (await basketRepository.SelectAsync(specification)).FirstOrDefault();

            if (basket == null)
                return;

            basket.CustomerId = customerId;
            await basketRepository.UpdateAsync(basket);
        }
    }
}
