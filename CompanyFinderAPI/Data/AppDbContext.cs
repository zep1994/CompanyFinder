using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CompanyFinderAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

        public DbSet<Company> Companies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("PostgreSQLConnection");
        }
    }
}