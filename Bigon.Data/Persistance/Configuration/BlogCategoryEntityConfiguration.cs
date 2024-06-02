﻿using Bigon.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bigon.Data.Persistance.Configuration
{
    public class BlogCategoryEntityConfiguration : IEntityTypeConfiguration<BlogCategory>
    {
        public void Configure(EntityTypeBuilder<BlogCategory> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnType("int");
            builder.Property(x => x.Name).HasColumnType("nvarchar").HasMaxLength(200).IsRequired();
            builder.Property(x => x.Description).HasColumnType("nvarchar(Max)");
            builder.ConfigureAsAuditable();
        }
    }
}