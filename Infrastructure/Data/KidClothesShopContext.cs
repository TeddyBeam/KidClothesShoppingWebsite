using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using KidClothesShop.Core.Entities;
using System;

namespace KidClothesShop.Infrastructure.Data
{
    public class KidClothesShopContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }

        public KidClothesShopContext(DbContextOptions<KidClothesShopContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>(ConfigureProduct);
            builder.Entity<ProductType>(ConfigureProductType);
            builder.Entity<ProductBrand>(ConfigureProductBrand);
        }

        private void ConfigureProduct(EntityTypeBuilder<Product> builder)
        {
            throw new NotImplementedException();
        }

        private void ConfigureProductType(EntityTypeBuilder<ProductType> builder)
        {
            throw new NotImplementedException();
        }

        private void ConfigureProductBrand(EntityTypeBuilder<ProductBrand> builder)
        {
            throw new NotImplementedException();
        }
    }
}
