using Scs.Application.DataTransfer;
using Scs.Application.Queries;
using Scs.Application.Searches;
using Scs.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scs.Implementation.Queries
{
    public class EfGetOrdersQuery : IGetOrdersQuery
    {
        private readonly ScsContext context;

        public EfGetOrdersQuery(ScsContext context)
        {
            this.context = context;
        }

        public int Id => 1;

        public string Name => "Orders Search";

        public PagedResponse<OrderDto> Execute(OrdersSearch search)
        {


            var query = context.Orders.AsQueryable();

            if (!string.IsNullOrEmpty(search.Address) || !string.IsNullOrWhiteSpace(search.Address))
            {
                query = query.Where(x => x.Address.ToLower().Contains(search.Address.ToLower()));
            }
            
            if (!string.IsNullOrEmpty(search.UserId) || !string.IsNullOrWhiteSpace(search.UserId))
            {
                query = query.Where(x => x.UserId.Equals(search.UserId));
            }
            

            var skipCount = search.PerPage * (search.Page - 1);

            var response = new PagedResponse<OrderDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new OrderDto
                {
                    Id = x.Id,
                    Address = x.Address,
                    CreateAt = x.CreateAt,
                    UserId = x.UserId,
                    OrderLineId = x.OrderLineId

                }).ToList()
            };

            return response;
        }
    }
}
