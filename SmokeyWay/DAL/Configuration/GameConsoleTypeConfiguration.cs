using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configuration
{
    public class GameConsoleTypeConfiguration : IEntityTypeConfiguration<GameConsoleType>
    {
        public void Configure(EntityTypeBuilder<GameConsoleType> builder)
        {
            builder.ToTable("GameConsoleType");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired();

            builder.Property(x => x.Name).HasMaxLength(45);

            builder.HasMany(x => x.GameConsoles).WithOne(x => x.GameConsoleType)
                .HasForeignKey(x => x.GameConsoleTypeId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
