

using Scs.Application;
using Scs.Application.DataTransfer;
using Scs.Application.Queries;
using Scs.Application.Searches;
using Scs.DataAccess;
using System.Collections.Generic;
using System.Linq;

namespace Scs.Implementation.Queries
{
    public class EfGetCartItemQuery : IGetCartItemQuery
    {
        private readonly ScsContext context;

        public EfGetCartItemQuery(ScsContext context)
        {
            this.context = context;
        }

        public int Id => 6;

        public string Name => "CartItem Search";


        public PagedResponse<CartItemDto> Execute(CartItemSearch search)
        {

            var query = context.CartItems.AsQueryable();

            if (search.ProductId != 0)
            {
                query = query.Where(x => x.ProductId.Equals(search.ProductId));
            }
            if (search.OrderId != 0)
            {
                query = query.Where(x => x.OrderId.Equals(search.OrderId));
            }
            if (search.Quantity > 0)
            {
                query = query.Where(x => x.Quantity.Equals(search.Quantity));
            }

            var skipCount = search.PerPage * (search.Page - 1);

            var response = new PagedResponse<CartItemDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new CartItemDto
                {
                    Id = x.Id,
                    Quantity = x.Quantity,
                    ProductId = x.ProductId,
                    OrderId = x.OrderId

                }).ToList()
            };

            return response;

        }

    }
}
