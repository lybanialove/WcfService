using Microsoft.EntityFrameworkCore;
using Service.Entites;

namespace Service
{
    public class Context : DbContext
    {
        public Context()
        {
            Database.EnsureCreated();
        }

        public DbSet<User> users { get; set; }
        public DbSet<Record> records { get; set; }
        public DbSet<Master> masters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=usersdb2;Username=postgres;Password=2602");
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(u => u.id);
            modelBuilder.Entity<Record>().HasKey(u => u.id);
            modelBuilder.Entity<Master>().HasKey(u => u.id);
        }
    }
}
