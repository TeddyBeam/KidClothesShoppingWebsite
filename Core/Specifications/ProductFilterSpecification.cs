using KidClothesShop.Core.Entities;

namespace KidClothesShop.Core.Specifications
{
    public class ProductFilterSpecification : BaseSpecification<Product>
    {
        public ProductFilterSpecification(int? brandId, int? typeId, int? targetAgesId)
            : base(p => (!brandId.HasValue || p.ProductBrandId == brandId) &&
                        (!typeId.HasValue || p.ProductTypeId == typeId) &&
                        (!targetAgesId.HasValue || p.TargetAgesId == targetAgesId))
        {

        }
    }
}
