using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Scs.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scs.EfDataAccess.Configurations
{
    public class OrdersConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(p => p.Address)
                .HasMaxLength(40)
                .IsRequired();

            // TODO CartItems > 0
                
        }
    }
}
