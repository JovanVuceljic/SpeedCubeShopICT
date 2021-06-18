﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Scs.Domain
{
    public class CartItemDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public int? OrderId { get; set; }
        public int Quantity { get; set; }
    }
}
