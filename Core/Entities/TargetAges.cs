namespace KidClothesShop.Core.Entities
{
    public class TargetAges : BaseEntity
    {
        public string Description { get; set; }
        public float MinAge { get; set; }
        public float MaxAge { get; set; }
    }
}
