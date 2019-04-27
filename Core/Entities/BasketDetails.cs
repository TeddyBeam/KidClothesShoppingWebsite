namespace KidClothesShop.Core.Entities
{
    public class BasketDetails : BaseEntity
    {
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
    }
}
