using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configuration
{
    public class DepartamentConfiguration : IEntityTypeConfiguration<Departament>
    {
        public void Configure(EntityTypeBuilder<Departament> builder)
        {
            builder.ToTable("Departament");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired();

            builder.Property(x => x.Name).HasMaxLength(45);

            builder.Property(x => x.Country).HasMaxLength(45);

            builder.Property(x => x.City).HasMaxLength(45);

            builder.Property(x => x.Street).HasMaxLength(45);

            builder.Property(x => x.HouseNumber).HasMaxLength(45);

            builder.HasMany(x => x.Tables).WithOne(x => x.Departament)
                .HasForeignKey(x => x.DepartamentId).OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Employees).WithOne(x => x.Departament)
                .HasForeignKey(x => x.DepartamentId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
