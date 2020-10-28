using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Holtz_ProductCatalog.Models;

namespace Holtz_ProductCatalog.Data.Maps
{
    public class CategoryMap  : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder) {
            builder.ToTable("Category");
            builder.HasKey(x  => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(120).HasColumnType("VARCHAR(120)");
        }
    }
}