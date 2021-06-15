using Scs.Application.Commands;
using Scs.Application.DataTransfer;
using Scs.DataAccess;
using Scs.Domain;
using System;

namespace Scs.Implementation
{
    public class EfCreateBrandCommad : ICreateBrandCommand
    {
        private readonly ScsContext _context;

        public EfCreateBrandCommad(ScsContext context)
        {
            _context = context;
        }

        public int Id => throw new NotImplementedException();

        public string Name => "Create New Brand Name using EF";

        public void Execute(BrandDto request)
        {
            var brand = new Brand
            {
                Name = request.Name
            };

            _context.Brands.Add(brand);

            _context.SaveChanges();
        }
    }
}
