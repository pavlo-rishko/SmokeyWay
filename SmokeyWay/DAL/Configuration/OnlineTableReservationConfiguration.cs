using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configuration
{
    public class OnlineTableReservationConfiguration : IEntityTypeConfiguration<OnlineTableReservation>
    {
        public void Configure(EntityTypeBuilder<OnlineTableReservation> builder)
        {
            builder.ToTable("OnlineTableReservation");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired();

            builder.Property(x => x.TableId);

            builder.Property(x => x.CreateDateTime);

            builder.Property(x => x.UserId);

            builder.HasOne(x => x.User).WithMany(x => x.OnlineTableReservations)
                .HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Table).WithMany(x => x.OnlineTableReservations)
                .HasForeignKey(x => x.TableId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
