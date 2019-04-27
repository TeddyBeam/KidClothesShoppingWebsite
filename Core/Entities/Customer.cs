namespace KidClothesShop.Core.Entities
{
    public class Customer : BaseEntity
    {
        public string IdentityGuid { get; private set; }

        private Customer()
        {
            // Required by EF
        }

        public Customer(string identity) : this()
        {
            IdentityGuid = identity;
        }
    }
}
