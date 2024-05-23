using BigonApp.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BigonApp.Models.Persistances.Configurations
{
    public class TagEntityConfiguration:IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.HasKey(x=>x.Id);
            builder.Property(x => x.Id).HasColumnType("int");
            builder.Property(x=>x.Name).HasColumnType("nvarchar").HasMaxLength(150).IsRequired();
            builder.ConfigureAsAuditable();
        }
    }
}
