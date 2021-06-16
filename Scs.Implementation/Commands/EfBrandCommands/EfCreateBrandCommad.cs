using FluentValidation;
using Scs.Application.Commands;
using Scs.Application.DataTransfer;
using Scs.DataAccess;
using Scs.Domain;
using Scs.Implementation.Validators;
using System;

namespace Scs.Implementation
{
    public class EfCreateBrandCommad : ICreateBrandCommand
    {
        private readonly ScsContext _context;
        private readonly CreateBrandValidator _validator;

        public EfCreateBrandCommad(CreateBrandValidator validator, ScsContext context)
        {
            _validator = validator;
            _context = context;
        }

        public int Id => 1;

        public string Name => "Create New Brand Name using EF";

        public void Execute(BrandDto request)
        {
            _validator.ValidateAndThrow(request);

            var brand = new Brand
            {
                Name = request.Name
            };

            _context.Brands.Add(brand);

            _context.SaveChanges();
        }
    }
}
