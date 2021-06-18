using Scs.Application.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scs.Application.Searches
{
    public class ProductCategorySearch : PagedSearch
    {
        public string ProductId { get; set; }
        public string CategoryId { get; set; }
    }
}
