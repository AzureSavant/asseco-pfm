using asseco_pfm.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace asseco_pfm.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<Transaction> Transaction { get; set; }
        public DbSet<Category> Category { get; set; }

        public AppDbContext()
        {

        }

        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
