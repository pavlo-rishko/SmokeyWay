using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configuration
{
    public class GameConsoleToGameConfiguration : IEntityTypeConfiguration<GameConsoleToGame>
    {
        public void Configure(EntityTypeBuilder<GameConsoleToGame> builder)
        {
            builder.ToTable("GameConsoleToGame");
            
            builder.HasKey(x => new { x.GameConsoleId, x.GameId });

            builder.HasOne(x => x.GameConsole)
                .WithMany(x => x.GameConsolesGames)
                .HasForeignKey(x => x.GameConsoleId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Game)
                .WithMany(x => x.GameConsolesGames)
                .HasForeignKey(x => x.GameId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
