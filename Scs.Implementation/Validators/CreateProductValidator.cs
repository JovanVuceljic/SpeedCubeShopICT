using FluentValidation;
using Scs.Application.DataTransfer;
using Scs.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scs.Implementation.Validators
{
    public class CreateProductValidator : AbstractValidator<ProductDto>
    {
        public CreateProductValidator(ScsContext context)
        {
            RuleFor(x => x.BrandId).Must(x => context.Brands.Any(c => c.Id == x)).WithMessage("Brand doesn't exist.");

            RuleFor(x => x.Name).NotEmpty().Must(name => !context.Products.Any(b => b.Name == name))
                .WithMessage("Products name must be unique");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Needs description");

        }
    }
}
