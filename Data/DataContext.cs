using Microsoft.EntityFrameworkCore;
using recipes.Models;

namespace recipes.Data
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Recipe> Recipes { get; set; }

        private readonly string DbPath;

        public DataContext(IConfiguration configuration)
        {
            this.DbPath = configuration.GetConnectionString("databasesql")!;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlite(this.DbPath);
            optionsBuilder.UseSqlServer(this.DbPath);
        }
    }
}