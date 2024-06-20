using Bigon.Data.Configurations;
using Bigon.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bigon.Data.Persistance.Configuration
{
    public class BlogEntityConfiguration : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnType("int");
            builder.Property(x => x.Name).HasColumnType("nvarchar").HasMaxLength(256).IsRequired();
            builder.Property(x => x.Description).HasColumnType("nvarchar(Max)");
            builder.Property(x => x.ImagePath).HasColumnType("varchar").HasMaxLength(1000).IsRequired();
            builder.HasOne<Category>().WithMany().HasForeignKey(x => x.CategoryId).HasPrincipalKey(x=>x.Id).OnDelete(DeleteBehavior.NoAction);
            builder.ConfigureAsAuditable();
            builder.Property(x => x.PublishedAt).HasColumnType("datetime");
            builder.Property(x => x.PublishedBy).HasColumnType("int");
            builder.HasIndex(x => x.Slug).IsUnique();

        }
    }
}
