using FluentValidation;
using Scs.Application.Commands;
using Scs.Application.DataTransfer;
using Scs.DataAccess;
using Scs.Domain;
using Scs.Implementation.Validators;
using System;

namespace Scs.Implementation
{
    public class EfCreateCategoryCommand : ICreateCategoryCommand
    {
     private readonly ScsContext _context;
        private readonly CreateCategoryValidator _validator;

        public EfCreateCategoryCommand(CreateCategoryValidator validator, ScsContext context)
        {
            _validator = validator;
            _context = context;
        }

        public int Id => 1;

        public string Name => "Create New Category Name using EF";


        public void Execute(CategoryDto request)
        {
            _validator.ValidateAndThrow(request);

            var category = new Category
            {
                Name = request.Name
            };

            _context.Categories.Add(category);

            _context.SaveChanges();
        }

    }
}
