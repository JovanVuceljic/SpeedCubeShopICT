

using Scs.Application;
using Scs.Application.DataTransfer;
using Scs.Application.Queries;
using Scs.Application.Searches;
using Scs.DataAccess;
using System.Collections.Generic;
using System.Linq;

namespace Scs.Implementation.Queries
{
    public class EfGetCategoriesQuery : IGetCategoriesQuery
    {
        private readonly ScsContext context;

        public EfGetCategoriesQuery(ScsContext context)
        {
            this.context = context;
        }
        
        public int Id => 2;

        public string Name => "Category Search";


        public PagedResponse<CategoryDto> Execute(CategorySearch search)
        {

            var query = context.Categories.AsQueryable();

            if (!string.IsNullOrEmpty(search.Name) || !string.IsNullOrWhiteSpace(search.Name))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));
            }

            var skipCount = search.PerPage * (search.Page - 1);

            var response = new PagedResponse<CategoryDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new CategoryDto {
                    Id = x.Id,
                    Name = x.Name
                }).ToList()
            };

            return response;

        }

    }
}
