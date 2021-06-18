

using Scs.Application;
using Scs.Application.DataTransfer;
using Scs.Application.Queries;
using Scs.Application.Searches;
using Scs.DataAccess;
using System.Collections.Generic;
using System.Linq;

namespace Scs.Implementation.Queries
{
    public class EfGetProductQuery : IGetProductQuery
    {
        private readonly ScsContext context;

        public EfGetProductQuery(ScsContext context)
        {
            this.context = context;
        }

        public int Id => 5;

        public string Name => "Product Search";


        public PagedResponse<ProductDto> Execute(ProductSearch search)
        {

            var query = context.Products.AsQueryable();

            if (!string.IsNullOrEmpty(search.Name) || !string.IsNullOrWhiteSpace(search.Name))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));
            }
            if (!string.IsNullOrEmpty(search.Description) || !string.IsNullOrWhiteSpace(search.Description))
            {
                query = query.Where(x => x.Description.ToLower().Contains(search.Description.ToLower()));
            }

            if (search.Price > 0)
            {
                query = query.Where(x => x.Price.Equals(search.Price));
            }

            var skipCount = search.PerPage * (search.Page - 1);

            var response = new PagedResponse<ProductDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new ProductDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    BrandId = x.BrandId,
                    Description = x.Description,
                    Price = x.Price

                }).ToList()
            };

            return response;

        }

    }
}
