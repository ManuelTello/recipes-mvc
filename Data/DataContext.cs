using Microsoft.EntityFrameworkCore;
using recipes.Models;

namespace recipes.Data
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        private readonly string? DbPath;

        public DataContext(IConfiguration configuration)
        {
            this.DbPath = configuration.GetConnectionString("database");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(this.DbPath);
        }
    }
}