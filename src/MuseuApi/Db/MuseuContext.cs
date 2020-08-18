using Microsoft.EntityFrameworkCore;
using MuseuApi.Entities;

namespace MuseuApi.Db
{
    public class MuseuContext : DbContext
    {
    

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(Startup.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        
        public DbSet<Item> Item { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
    }
}