using Scs.Application.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scs.Application.Searches
{
    public class OrdersSearch : PagedSearch
    {
        public string UserId { get; set; }
        public string Address { get; set; }
        public int OrderLineId { get; set; }
    }
}
