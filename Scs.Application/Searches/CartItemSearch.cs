using Scs.Application.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scs.Application.Searches
{
    public class CartItemSearch : PagedSearch
    {
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }
    }
}
