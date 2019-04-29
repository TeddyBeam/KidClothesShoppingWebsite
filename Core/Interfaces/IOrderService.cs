using System.Threading.Tasks;
using KidClothesShop.Core.ValueObjects;

namespace KidClothesShop.Core.Interfaces
{
    public interface IOrderService
    {
        Task CreateOrderAsync(int basketId, Address shippingAddress);
    }
}
