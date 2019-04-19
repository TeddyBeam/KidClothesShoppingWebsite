namespace KidClothesShop.Core.Entities
{
    public class Account : BaseEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
    }
}
