using Bigon.Infrastructure.Commons.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bigon.Data.Persistance.Configuration
{
    public static class ConfigurationHelper
    {

        public static EntityTypeBuilder<T> ConfigureAsAuditable<T>(this EntityTypeBuilder<T> builder)
            where T : AuditableEntity
        {
            builder.Property(a => a.CreatedBy).HasColumnType("int").IsRequired();
            builder.Property(a => a.CreatedAt).HasColumnType("datetime").IsRequired();
            builder.Property(a => a.ModifiedBy).HasColumnType("int");
            builder.Property(a => a.ModifiedAt).HasColumnType("datetime");
            builder.Property(a => a.DeletedBy).HasColumnType("int");
            builder.Property(a => a.DeletedAt).HasColumnType("datetime");
            return builder;
        }
    }
}
