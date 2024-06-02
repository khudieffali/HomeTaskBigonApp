using Bigon.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bigon.Data.Persistance.Configuration
{
    public class BrandEntityConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnType("int");
            builder.Property(x => x.BrandName).HasColumnType("nvarchar").HasMaxLength(100).IsRequired();
            builder.Property(x => x.Description).HasColumnType("nvarchar(Max)");
            builder.ConfigureAsAuditable();
        }
    }
}
