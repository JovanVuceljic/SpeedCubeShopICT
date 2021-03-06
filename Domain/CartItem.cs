using System;
using System.Collections.Generic;
using System.Text;

namespace Scs.Domain
{
    public class CartItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int? OrderId { get; set; }
        public int Quantity { get; set; }
        public Product Product { get; set; }
        public Order Order { get; set; }
    }
}
