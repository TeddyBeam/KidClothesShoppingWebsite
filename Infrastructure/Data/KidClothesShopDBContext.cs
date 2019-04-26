using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using KidClothesShop.Core.Entities;
using KidClothesShop.Core.ValueObjects;
using System;

namespace KidClothesShop.Infrastructure.Data
{
    public class KidClothesShopDBContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<TargetAges> TargetAges { get; set; }

        public KidClothesShopDBContext(DbContextOptions<KidClothesShopDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Order>(ConfigureOrder);
            builder.Entity<OrderDetails>(ConfigureOrderDetails);
            builder.Entity<Product>(ConfigureProduct);
            builder.Entity<ProductBrand>(ConfigureProductBrand);
            builder.Entity<ProductType>(ConfigureProductType);
            builder.Entity<TargetAges>(ConfigureTargetAges);

            builder.Entity<Address>(ConfigureAddress);
            builder.Entity<ProductOrdered>(ConfigureProductOrdered);
        }

        private void ConfigureOrder(EntityTypeBuilder<Order> builder)
        {
            var navigation = builder.Metadata.FindNavigation(nameof(Order.OrderDetails));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.OwnsOne(order => order.ShipAddress);
        }

        private void ConfigureOrderDetails(EntityTypeBuilder<OrderDetails> builder)
        {
            builder.OwnsOne(detail => detail.ProductOrdered);
        }

        private void ConfigureProduct(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(product => product.Id);

            builder.Property(product => product.Id)
                .ValueGeneratedOnAdd();

            builder.Property(product => product.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(product => product.Description)
                .IsRequired(false)
                .HasMaxLength(100);

            builder.Property(product => product.PictureUri)
                .IsRequired(false);

            builder.HasOne(product => product.ProductBrand)
                .WithMany()
                .HasForeignKey(product => product.ProductBrandId);

            builder.HasOne(product => product.ProductType)
                .WithMany()
                .HasForeignKey(product => product.ProductTypeId);

            builder.HasOne(product => product.TargetAges)
                .WithMany()
                .HasForeignKey(product => product.TargetAgesId);
        }

        private void ConfigureProductBrand(EntityTypeBuilder<ProductBrand> builder)
        {
            builder.HasKey(brand => brand.Id);

            builder.Property(brand => brand.Id)
                .ValueGeneratedOnAdd();

            builder.Property(brand => brand.Brand)
                .IsRequired()
                .HasMaxLength(30);
        }

        private void ConfigureProductType(EntityTypeBuilder<ProductType> builder)
        {
            builder.HasKey(type => type.Id);

            builder.Property(type => type.Id)
                .ValueGeneratedOnAdd();

            builder.Property(type => type.Type)
                .IsRequired()
                .HasMaxLength(30);
        }

        private void ConfigureTargetAges(EntityTypeBuilder<TargetAges> builder)
        {
            builder.HasKey(ages => ages.Id);

            builder.Property(ages => ages.Id)
                .ValueGeneratedOnAdd();

            builder.Property(ages => ages.Description)
                .IsRequired(false)
                .HasMaxLength(100);
        }

        private void ConfigureAddress(EntityTypeBuilder<Address> builder)
        {
            builder.Property(address => address.HouseNumber)
                .IsRequired()
                .IsUnicode(false)
                .HasMaxLength(20);

            builder.Property(address => address.Street)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(address => address.District)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(address => address.Province)
                .IsRequired()
                .HasMaxLength(20);
        }

        private void ConfigureProductOrdered(EntityTypeBuilder<ProductOrdered> builder)
        {
            builder.Property(productOrdered => productOrdered.ProductName)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
