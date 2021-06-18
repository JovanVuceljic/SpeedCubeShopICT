using Scs.Application.DataTransfer;
using Scs.Application.Searches;
using Scs.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scs.Application.Queries
{
    public interface IGetCartItemQuery : IQuery<CartItemSearch, PagedResponse<CartItemDto>>
    {
    }

    
}
