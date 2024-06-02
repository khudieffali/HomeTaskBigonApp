using Bigon.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bigon.Data.Persistance.Configuration
{
    public class SubscriberEntityConfiguration : IEntityTypeConfiguration<Subscriber>
    {
        public void Configure(EntityTypeBuilder<Subscriber> builder)
        {
            builder.Property(x => x.EmailAddress).HasColumnType("varchar").HasMaxLength(150);
            builder.HasKey(x => x.EmailAddress);
            builder.Property(x => x.IsApproved).HasColumnType("bit");
            builder.Property(x => x.ApprovedAt).HasColumnType("datetime");
            builder.Property(x => x.CreatedAt).HasColumnType("datetime").IsRequired();


        }
    }
}
