using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configuration
{
    public class PositionConfiguration : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.ToTable("Position");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();

            builder.Property(x => x.Name).HasMaxLength(45);

            builder.Property(x => x.Description).HasMaxLength(8000);

            builder.HasMany(x => x.Employees).WithOne(x => x.Position)
                .HasForeignKey(x => x.PositionId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
