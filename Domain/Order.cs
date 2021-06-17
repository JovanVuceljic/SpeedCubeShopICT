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
        public DateTime CreateAt { get; set; }
        public DateTime DeliveredAt { get; set; }
        public int OrderLineId { get; set; }
        public OrderLine OrderLine { get; set; }
    }
}
