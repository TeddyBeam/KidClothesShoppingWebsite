using KidClothesShop.Core.Entities;

namespace KidClothesShop.Core.Specifications
{
    public class ProductFilterPaginatedSpecification : BaseSpecification<Product>
    {
        public ProductFilterPaginatedSpecification(int skip, int take, int? brandId, int? typeId, int? targetAgesId)
            : base(p => (!brandId.HasValue || p.ProductBrandId == brandId) &&
            (!typeId.HasValue || p.ProductTypeId == typeId) &&
            (!targetAgesId.HasValue || p.TargetAgesId == targetAgesId))
        {
            ApplyPaging(skip, take);
        }
    }
}
