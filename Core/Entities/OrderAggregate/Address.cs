namespace KidClothesShop.Core.Entities
{
    /// <summary>
    /// [Value Object]
    /// </summary>
    public class Address
    {
        public string HouseNumber { get; private set; }
        public string Street { get; private set; }
        public string District { get; private set; }
        public string Province { get; private set; }

        // Required by EF.
        private Address() { }

        public Address(string houseNumber, string street, string district, string province)
        {
            // TODO: Validates parameters.

            HouseNumber = houseNumber;
            Street = street;
            District = district;
            Province = province;
        }
    }
}
