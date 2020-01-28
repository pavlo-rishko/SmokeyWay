using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configuration
{
    public class OrderDishConfiguration : IEntityTypeConfiguration<OrderDish>
    {
        public void Configure(EntityTypeBuilder<OrderDish> builder)
        {
            builder.ToTable("OrderDish");

            builder.HasKey(x => new {x.DishId, x.OrderId});

            builder.HasOne(x => x.Order)
                .WithMany(x => x.OrdersDishes)
                .HasForeignKey(x => x.OrderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Dish)
                .WithMany(x => x.OrdersDishes)
                .HasForeignKey(x => x.DishId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
