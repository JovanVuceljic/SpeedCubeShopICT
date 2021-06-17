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
        public int UserId { get; set; }
        public User User { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime DeliveredAt { get; set; }
        public ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}
