using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configuration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();

            builder.Property(x => x.FirstName).HasMaxLength(45).IsRequired();

            builder.Property(x => x.LastName).HasMaxLength(45).IsRequired();

            builder.Property(x => x.DepartamentId).IsRequired();

            builder.Property(x => x.PhoneNumber).HasMaxLength(45);

            builder.Property(x => x.PositionId).IsRequired();

            builder.Property(x => x.GenderId);

            builder.Property(x => x.BirthDate);

            builder.HasOne(x => x.Departament).WithMany(x => x.Employees)
                .HasForeignKey(x => x.DepartamentId).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Gender).WithMany(x => x.Employees)
                .HasForeignKey(x => x.GenderId).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Position).WithMany(x => x.Employees)
                .HasForeignKey(x => x.PositionId).OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.OfflineTableResrvations).WithOne(x => x.Employee)
                .HasForeignKey(x => x.EmployeeId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
