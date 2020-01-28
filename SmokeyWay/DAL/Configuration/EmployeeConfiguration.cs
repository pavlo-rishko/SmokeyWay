using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
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

            builder.Property(x => x.DepartmentId).IsRequired();

            builder.Property(x => x.PhoneNumber).HasMaxLength(45);

            builder.Property(x => x.HireDate);

            builder.Property(x => x.PositionId).IsRequired();

            builder.Property(x => x.GenderId);

            builder.Property(x => x.BirthDate);

            builder.HasOne(x => x.Department).WithMany(x => x.Employees)
                .HasForeignKey(x => x.DepartmentId).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Gender).WithMany(x => x.Employees)
                .HasForeignKey(x => x.GenderId).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Position).WithMany(x => x.Employees)
                .HasForeignKey(x => x.PositionId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
