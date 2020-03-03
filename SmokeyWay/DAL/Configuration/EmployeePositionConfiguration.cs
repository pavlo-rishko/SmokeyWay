using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configuration
{
    public class EmployeePositionConfiguration : IEntityTypeConfiguration<EmployeePosition>
    {
        public void Configure(EntityTypeBuilder<EmployeePosition> builder)
        {
            builder.ToTable("EmployeePosition");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();

            builder.Property(x => x.Name).HasMaxLength(45);

            builder.Property(x => x.Description).HasMaxLength(8000);

            builder.HasMany(x => x.Employees).WithOne(x => x.Position)
                .HasForeignKey(x => x.PositionId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
