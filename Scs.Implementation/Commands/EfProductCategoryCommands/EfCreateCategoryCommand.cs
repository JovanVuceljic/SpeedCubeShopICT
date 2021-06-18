using FluentValidation;
using Scs.Application.Commands;
using Scs.Application.DataTransfer;
using Scs.DataAccess;
using Scs.Domain;
using Scs.Implementation.Validators;
using System;

namespace Scs.Implementation
{
    public class EfCreateProductCategoryCommand : ICreateProductCategoryCommand
    {
        
        private readonly ScsContext _context;
        private readonly CreateProductCategoryValidator _validator;

        public EfCreateProductCategoryCommand(CreateProductCategoryValidator validator, ScsContext context)
        {
            _validator = validator;
            _context = context;
        }

        public int Id => 1;

        public string Name => "Create New Product Category Name using EF";


        public void Execute(ProductCategoryDto request)
        {
            _validator.ValidateAndThrow(request);

            var category = new ProductCategory
            {
                CategoryId = request.CategoryId,
                ProductId = request.ProductId,
            };

            _context.ProductCategories.Add(category);

            _context.SaveChanges();
        }
        

    }
}
