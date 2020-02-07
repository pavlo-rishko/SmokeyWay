using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configuration
{
    public class GameConsoleConfiguration : IEntityTypeConfiguration<GameConsole>
    {
        public void Configure(EntityTypeBuilder<GameConsole> builder)
        {
            builder.ToTable("GameConsole");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired();

            builder.Property(x => x.GameConsoleTypeId);

            builder.HasOne(x => x.Table).WithOne(x => x.GameConsole)
                .HasForeignKey<Table>(x => x.GameConsoleId).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.GameConsoleType).WithMany(x => x.GameConsoles)
                .HasForeignKey(x => x.GameConsoleTypeId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
