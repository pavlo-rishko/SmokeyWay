using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired();
            
            builder.Property(x => x.TableId);

            builder.Property(x => x.EmployeeId);

            builder.HasOne(x => x.Table).WithMany(x => x.Orders)
                .HasForeignKey(x => x.TableId).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Employee).WithMany(x => x.Orders)
                .HasForeignKey(x => x.EmployeeId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
