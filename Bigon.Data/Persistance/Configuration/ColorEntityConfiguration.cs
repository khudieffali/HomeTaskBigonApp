using Bigon.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bigon.Data.Persistance.Configuration
{
    public class ColorEntityConfiguration : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).HasColumnType("int");
            builder.Property(a => a.Name).HasColumnType("varchar").HasMaxLength(40).IsRequired();
            builder.Property(a => a.HexCode).HasColumnType("varchar").HasMaxLength(7).IsRequired();
            builder.ConfigureAsAuditable();
            builder.ToTable("Colors");
        }
    }
}
