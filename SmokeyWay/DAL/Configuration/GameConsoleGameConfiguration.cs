using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configuration
{
    public class GameConsoleGameConfiguration : IEntityTypeConfiguration<GameConsoleGame>
    {
        public void Configure(EntityTypeBuilder<GameConsoleGame> builder)
        {
            builder.ToTable("GameConsoleGame");
            
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
