using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configuration
{
    public class DishConfiguration : IEntityTypeConfiguration<Dish>
    {
        public void Configure(EntityTypeBuilder<Dish> builder)
        {
            builder.ToTable("Dish");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired();

            builder.Property(x => x.Name).HasMaxLength(45);

            builder.Property(x => x.Price).HasColumnType("decimal(18,2)");

            builder.Property(x => x.Description).HasMaxLength(1000);

            builder.Property(x => x.IsAvalialable);

            builder.Property(x => x.TypeId);

            builder.HasOne(x => x.DishType).WithMany(x => x.Dishes)
                .HasForeignKey(x => x.TypeId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
