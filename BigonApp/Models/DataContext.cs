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
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogCategory> BlogCategories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<BlogToTag> BlogToTags { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }
    }
}
