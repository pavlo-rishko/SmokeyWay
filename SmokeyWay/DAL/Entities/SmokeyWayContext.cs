using DAL.Configuration;
using Microsoft.EntityFrameworkCore;

namespace DAL.Entities
{
    public sealed class SmokeyWayDbContext : DbContext
    {
        public SmokeyWayDbContext(DbContextOptions options) : base(options)
        {
           Database.Migrate();
        }

        public DbSet<User> Users { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }

        public DbSet<Gender> Genders { get; set; }
        
        public DbSet<Dish> Dishes { get; set; }

        public DbSet<OrderDish> OrderDishes { get; set; }

        public DbSet<DishType> DishTypes { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Table> Tables { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OnlineTableReservation> OnlineTableReservations { get; set; }

        public DbSet<EmployeePosition> EmployeePositions { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<GameConsole> GameConsoles { get; set; }

        public DbSet<GameConsoleType> GameConsoleTypes { get; set; }

        public DbSet<GameConsoleToGame> GameConsoleToGames { get; set; }

        public DbSet<OfflineTableReservation> OfflineTableReservations { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
            modelBuilder.ApplyConfiguration(new GenderConfiguration());

            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new DishConfiguration());
            modelBuilder.ApplyConfiguration(new DishTypeConfiguration());

            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new OnlineTableReservationConfiguration());
            modelBuilder.ApplyConfiguration(new OfflineTableReservationConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());

            modelBuilder.ApplyConfiguration(new OrderDishConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeePositionConfiguration());
            modelBuilder.ApplyConfiguration(new TableConfiguration());

            modelBuilder.ApplyConfiguration(new GameConfiguration());
            modelBuilder.ApplyConfiguration(new GameConsoleConfiguration());
            modelBuilder.ApplyConfiguration(new GameConsoleTypeConfiguration());
            modelBuilder.ApplyConfiguration(new GameConsoleToGameConfiguration());
        }
    }
}
