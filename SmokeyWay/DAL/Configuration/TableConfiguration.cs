using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Configuration
{
    public class TableConfiguration : IEntityTypeConfiguration<Table>
    {
        public void Configure(EntityTypeBuilder<Table> builder)
        {
            builder.ToTable("Table");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired();

            builder.Property(x => x.Identifier).HasMaxLength(45).IsRequired();

            builder.Property(x => x.DepartmentId).IsRequired();

            builder.Property(x => x.SeatingCapacity).IsRequired();

            builder.Property(x => x.ConsoleId);
        }
    }
}
