using Scs.Application.DataTransfer;
using Scs.Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scs.Application.Queries
{
    public interface IGetProductQuery : IQuery<ProductSearch, PagedResponse<ProductDto>>
    {
    }

    
}
