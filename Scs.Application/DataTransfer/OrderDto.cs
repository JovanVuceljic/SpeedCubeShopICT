using Scs.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scs.Application.DataTransfer
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Address { get; set; }
        public DateTime CreateAt { get; set; }
        public int OrderLineId { get; set; }
    }
}
