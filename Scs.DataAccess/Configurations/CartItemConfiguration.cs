using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Scs.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scs.EfDataAccess.Configurations
{
    public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.Property(p => p.ProductId)
                .IsRequired();

            //builder.Property(p => p.Quantity) > 0

        }
    }
}
