using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Scs.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scs.EfDataAccess.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Name)
                .IsRequired();

            builder.HasIndex(p => p.Name)
                .IsUnique();

        }
    }
}
