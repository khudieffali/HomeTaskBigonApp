using BigonApp.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BigonApp.Models.Persistances.Configurations
{
    public class BlogEntityConfiguration:IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.HasKey(x=>x.Id);
            builder.Property(x => x.Id).HasColumnType("int");
            builder.Property(x => x.Name).HasColumnType("nvarchar").HasMaxLength(256).IsRequired();
            builder.Property(x=>x.Description).HasColumnType("nvarchar(Max)");
            builder.Property(x=>x.ImagePath).HasColumnType("varchar").HasMaxLength(1000).IsRequired();
            builder.HasOne(x => x.BlogCategory).WithMany(a=>a.Blogs).HasForeignKey(x => x.BlogCategoryId).OnDelete(DeleteBehavior.NoAction);
            builder.ConfigureAsAuditable();
        }
    }
}
