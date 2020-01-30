using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configuration
{
    public class GenderConfiguration : IEntityTypeConfiguration<Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> builder)
        {
            builder.ToTable("Gender");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).ValueGeneratedOnAdd().IsRequired();

            builder.Property(e => e.Name).HasMaxLength(100);

            builder.Property(e => e.Descriprion).HasMaxLength(1000);

            builder.HasMany(x => x.Users).WithOne(x => x.Gender)
                .HasForeignKey(x => x.GenderId).OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Employees).WithOne(x => x.Gender)
                .HasForeignKey(x => x.GenderId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
