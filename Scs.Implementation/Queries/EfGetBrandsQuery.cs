

using Scs.Application;
using Scs.Application.DataTransfer;
using Scs.Application.Queries;
using Scs.Application.Searches;
using Scs.DataAccess;
using System.Collections.Generic;
using System.Linq;

namespace Scs.Implementation.Queries
{
    public class EfGetBrandsQuery : IGetBrandsQuery
    {
        private readonly ScsContext context;

        public EfGetBrandsQuery(ScsContext context)
        {
            this.context = context;
        }
        
        public int Id => 1;

        public string Name => "Brand Search";


        public PagedResponse<BrandDto> Execute(BrandSearch search)
        {

            var query = context.Brands.AsQueryable();

            if (!string.IsNullOrEmpty(search.Name) || !string.IsNullOrWhiteSpace(search.Name))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));
            }

            var skipCount = search.PerPage * (search.Page - 1);

            var response = new PagedResponse<BrandDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new BrandDto {
                    Id = x.Id,
                    Name = x.Name
                }).ToList()
            };

            return response;
    
    /*      
            return query.Select(x => new BrandDto
            {
                Id = x.Id,
                Name = x.Name

            }).ToList();
    */

        }

    }
}
