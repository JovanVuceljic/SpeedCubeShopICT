using System;
using System.Collections.Generic;
using System.Text;

namespace Scs.Application.DataTransfer
{
    public class CartItemDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int? OrderId { get; set; }
        public int Quantity { get; set; }
    }
}
