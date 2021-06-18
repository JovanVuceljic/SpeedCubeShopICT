using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Scs.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scs.EfDataAccess.Configurations
{
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.Property(p => p.ProductId)
                .IsRequired();

            builder.HasIndex(p => p.CategoryId)
                .IsUnique();

        }
    }
}
