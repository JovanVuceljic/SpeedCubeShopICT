

using Scs.Application;
using Scs.Application.DataTransfer;
using Scs.Application.Queries;
using Scs.Application.Searches;
using Scs.DataAccess;
using System.Collections.Generic;
using System.Linq;

namespace Scs.Implementation.Queries
{
    public class EfGetProductCategoriesQuery : IGetProductCategoriesQuery
    {
        private readonly ScsContext context;

        public EfGetProductCategoriesQuery(ScsContext context)
        {
            this.context = context;
        }

        public int Id => 4;

        public string Name => "ProductCategory Search";


        public PagedResponse<ProductCategoryDto> Execute(ProductCategorySearch search)
        {

            var query = context.ProductCategories.AsQueryable();

            if (!string.IsNullOrEmpty(search.CategoryId) || !string.IsNullOrWhiteSpace(search.CategoryId))
            {
                query = query.Where(x => x.CategoryId.Equals(search.CategoryId));
            }
            if (!string.IsNullOrEmpty(search.ProductId) || !string.IsNullOrWhiteSpace(search.ProductId))
            {
                query = query.Where(x => x.ProductId.Equals(search.ProductId));
            }

            var skipCount = search.PerPage * (search.Page - 1);

            var response = new PagedResponse<ProductCategoryDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new ProductCategoryDto
                {
                    Id = x.Id,
                    CategoryId = x.CategoryId,
                    ProductId = x.ProductId
                }).ToList()
            };

            return response;

        }

    }
}
