using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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

            builder.Property(x => x.DepartamentId).IsRequired();

            builder.Property(x => x.SeatingCapacity).IsRequired();

            builder.Property(x => x.GameConsoleId);

            builder.HasMany(x => x.Orders).WithOne(x => x.Table)
                .HasForeignKey(x => x.TableId).OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.OnlineTableReservations).WithOne(x => x.Table)
                .HasForeignKey(x => x.TableId).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Departament).WithMany(x => x.Tables)
                .HasForeignKey(x => x.DepartamentId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
