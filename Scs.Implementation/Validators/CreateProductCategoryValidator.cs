using FluentValidation;
using Scs.Application.DataTransfer;
using Scs.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scs.Implementation.Validators
{
    public class CreateProductCategoryValidator : AbstractValidator<ProductCategoryDto>
    {
        public CreateProductCategoryValidator(ScsContext context)
        {
            RuleFor(x => x.CategoryId).Must(x => context.Categories.Any(c => c.Id == x)).WithMessage("Category doesn't exist.");
           // RuleFor(x => x.ProductId).Must(x => context.Products.Any(c => c.Id == x)).WithMessage("Product doesn't exist.");

        }
    }
}
