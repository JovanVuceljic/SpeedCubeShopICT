using System;
using System.Collections.Generic;
using System.Text;

namespace Scs.Domain
{
    public class OrderLine
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string OrderId { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime DeliveredAt { get; set; }
    }
}
