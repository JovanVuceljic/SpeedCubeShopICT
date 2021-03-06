using System;
using System.Collections.Generic;
using System.Text;

namespace Scs.Domain
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Address { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DeliveredAt { get; set; }
    }
}
