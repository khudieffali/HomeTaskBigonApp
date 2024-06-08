using Bigon.Infrastructure.Commons.Abstracts;
using Bigon.Infrastructure.Entities;
using Bigon.Infrastructure.Services.Abstracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Bigon.Data.Persistance
{
    public class DataContext(DbContextOptions<DataContext> options, IDateTimeService dateTimeService, IUserService userService) : DbContext(options)
    {
        private readonly IDateTimeService _dateTimeService = dateTimeService;
        private readonly IUserService _userService = userService;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken token = new())
        {
            var changes = this.ChangeTracker.Entries<IAuditableEntity>();
            
            if (changes != null)
            {
                foreach (var entity in changes.Where(x => x.State == EntityState.Added ||
                x.State == EntityState.Modified || x.State == EntityState.Deleted))
                {
                    
                    switch (entity.State)
                    {
                        case EntityState.Added:
                            entity.Entity.CreatedAt = _dateTimeService.ExecutingTime;
                            entity.Entity.CreatedBy = _userService.GetPrincipialId();
                            break;
                        case EntityState.Modified:
                            entity.Entity.ModifiedAt = _dateTimeService.ExecutingTime;
                            entity.Entity.ModifiedBy = _userService.GetPrincipialId();

                            entity.Property(x=>x.CreatedBy).IsModified=false;
                            entity.Property(x=>x.CreatedAt).IsModified=false;
                            break;
                        case EntityState.Deleted:
                            entity.State = EntityState.Modified;
                            entity.Entity.DeletedAt = _dateTimeService.ExecutingTime;
                            entity.Entity.DeletedBy = _userService.GetPrincipialId();
                            entity.Property(x => x.CreatedBy).IsModified = false;
                            entity.Property(x => x.CreatedAt).IsModified = false;
                            entity.Property(x => x.ModifiedBy).IsModified = false;
                            entity.Property(x => x.ModifiedAt).IsModified = false;
                            break;
                        default:
                            break;
                    }
                }
            }
            return await base.SaveChangesAsync(token);
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
