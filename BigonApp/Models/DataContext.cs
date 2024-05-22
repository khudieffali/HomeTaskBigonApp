using BigonApp.Models.Entities;
using BigonApp.Models.Persistances.Configurations;
using Microsoft.EntityFrameworkCore;

namespace BigonApp.Models
{
    public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
    {

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
        }

        public DbSet<Color> Colors { get; set; }
    }
}
