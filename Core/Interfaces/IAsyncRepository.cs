using KidClothesShop.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KidClothesShop.Core.Interfaces
{
    public interface IAsyncRepository<T> where T : BaseEntity
    {
        Task<T> SelectByIdAsync(int id);
        Task<IReadOnlyList<T>> SelectAllAsync();
        Task<IReadOnlyList<T>> SelectAsync(ISpecification<T> spec);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<int> CountAsync(ISpecification<T> spec);
    }
}
