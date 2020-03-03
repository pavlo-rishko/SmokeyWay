using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configuration
{
    public class OfflineTableReservationConfiguration : IEntityTypeConfiguration<OfflineTableReservation>
    {
        public void Configure(EntityTypeBuilder<OfflineTableReservation> builder)
        {
            builder.ToTable("OfflineTableReservation");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired();

            builder.Property(x => x.TableId);

            builder.Property(x => x.UserName).HasMaxLength(45);

            builder.Property(x => x.UserPhoneNumber).HasMaxLength(45);

            builder.Property(x => x.CreateDateTime);

            builder.Property(x => x.EmployeeId);

            builder.HasOne(x => x.Employee).WithMany(x => x.OfflineTableResrvations)
                .HasForeignKey(x => x.EmployeeId).OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Table).WithMany(x => x.OfflineTableResrvations)
                .HasForeignKey(x => x.TableId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
