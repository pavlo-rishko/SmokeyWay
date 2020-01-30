using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configuration
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("Department");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired();

            builder.Property(x => x.Name).HasMaxLength(45);

            builder.Property(x => x.Country).HasMaxLength(45);

            builder.Property(x => x.City).HasMaxLength(45);

            builder.Property(x => x.Street).HasMaxLength(45);

            builder.Property(x => x.HouseNumber).HasMaxLength(45);

            builder.HasMany(x => x.Tables).WithOne(x => x.Department)
                .HasForeignKey(x => x.DepartmentId).OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Employees).WithOne(x => x.Department)
                .HasForeignKey(x => x.DepartmentId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
