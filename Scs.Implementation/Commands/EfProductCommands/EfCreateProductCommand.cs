using FluentValidation;
using Scs.Application.Commands;
using Scs.Application.DataTransfer;
using Scs.DataAccess;
using Scs.Domain;
using Scs.Implementation.Validators;
using System;

namespace Scs.Implementation
{
    public class EfCreateProductCommand : ICreateProductCommand
    {
        
        private readonly ScsContext _context;
        private readonly CreateProductValidator _validator;

        public EfCreateProductCommand(CreateProductValidator validator, ScsContext context)
        {
            _validator = validator;
            _context = context;
        }

        public int Id => 1;

        public string Name => "Create New Product using EF";


        public void Execute(ProductDto request)
        {
            _validator.ValidateAndThrow(request);

            var product = new Product
            {
                Name = request.Name,
                Price = request.Price,
                Description = request.Description,
                BrandId = request.BrandId
            };

            _context.Products.Add(product);

            _context.SaveChanges();
        }
        

    }
}
