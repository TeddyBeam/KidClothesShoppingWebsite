using System.Collections.Generic;
using System.Threading.Tasks;

namespace KidClothesShop.Core.Interfaces
{
    public interface IBasketService
    {
        Task<int> GetBasketItemCountAsync(string customerId);
        Task TransferBasketAsync(string anonymousId, string customerId);
        Task AddItemToBasketAsync(int basketId, int productId, decimal price, int quantity);
        Task SetQuantitiesAsync(int basketId, Dictionary<string, int> quantities);
        Task DeleteBasketAsync(int basketId);
    }
}
