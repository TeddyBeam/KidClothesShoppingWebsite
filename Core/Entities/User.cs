using System;
using KidClothesShop.Core.ValueObjects;
using KidClothesShop.Core.Enums;

namespace KidClothesShop.Core.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }
        public DateTime Birthday { get; set; }
        public Address Address { get; set; }
        public string PictureUri { get; set; }
        public Account Account { get; set; }
    }
}
