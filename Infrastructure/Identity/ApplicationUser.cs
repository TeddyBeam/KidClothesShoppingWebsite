using System;
using Microsoft.AspNetCore.Identity;
using KidClothesShop.Core.Enums;
using KidClothesShop.Core.ValueObjects;

namespace KidClothesShop.Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string PictureUri { get; set; }
        public bool IsAdmin { get; set; }
    }
}
