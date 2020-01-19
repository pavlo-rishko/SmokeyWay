using DAL.Configuration;
using Microsoft.EntityFrameworkCore;

namespace DAL.Entities
{
    public class SmokeyWayDbContext : DbContext
    {
        public SmokeyWayDbContext(DbContextOptions options) : base(options)
        {
           Database.Migrate();
        }
        
        public DbSet<User> Users { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }

        public DbSet<Gender> Genders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
            modelBuilder.ApplyConfiguration(new GenderConfiguration());
        }
    }
}
