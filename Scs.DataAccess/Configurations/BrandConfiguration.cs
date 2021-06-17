using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Scs.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scs.EfDataAccess.Configurations
{
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.Property(p => p.Name)
                .HasMaxLength(40)
                .IsRequired();

            builder.HasIndex(p => p.Name)
                .IsUnique();

        }
    }
}
