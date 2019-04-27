using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace KidClothesShop.Infrastructure.Identity
{
    public class KidClothesShopUserDBContext : IdentityDbContext<ApplicationUser>
    {
        public KidClothesShopUserDBContext(DbContextOptions<KidClothesShopUserDBContext> options) 
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>(ConfigureApplicationUser);
        }

        private void ConfigureApplicationUser(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.ToTable("ApplicationUsers");

            builder.Property(user => user.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(user => user.Gender)
                .IsRequired(false)
                .HasMaxLength(10);

            builder.Property(user => user.PictureUri)
                .IsRequired(false);

            builder.Property(user => user.Birthday)
                .IsRequired(false);

            builder.Property(user => user.IsAdmin)
                .IsRequired(false)
                .HasDefaultValue(false);
        }
    }
}
