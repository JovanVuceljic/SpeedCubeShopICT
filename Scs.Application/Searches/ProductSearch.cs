using Scs.Application.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scs.Application.Searches
{
    public class ProductSearch : PagedSearch
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int BrandId { get; set; }
    }
}
