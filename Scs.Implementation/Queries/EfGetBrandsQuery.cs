

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
        
        public int Id => 4;

        public string Name => "Brand Search";


        public IEnumerable<BrandDto> Execute(BrandSearch search)
        {

            var query = context.Brands.AsQueryable();

            if (!string.IsNullOrEmpty(search.Name) || !string.IsNullOrWhiteSpace(search.Name))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));
            }

            return query.Select(x => new BrandDto
            {
                Id = x.Id,
                Name = x.Name

            }).ToList();

        }

    }
}
