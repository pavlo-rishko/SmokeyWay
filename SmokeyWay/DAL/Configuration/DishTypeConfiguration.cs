using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configuration
{
    public class DishTypeConfiguration : IEntityTypeConfiguration<DishType>
    {
        public void Configure(EntityTypeBuilder<DishType> builder)
        {
            builder.ToTable("DishType");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired();

            builder.Property(x => x.Name).HasMaxLength(45);
        }
    }
}
