using FluentValidation;
using Scs.Application.DataTransfer;
using Scs.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scs.Implementation.Validators
{
    public class CreateBrandValidator : AbstractValidator<BrandDto>
    {
        public CreateBrandValidator(ScsContext context)
        {
            RuleFor(x => x.Name).NotEmpty().Must(name => !context.Brands.Any(b => b.Name == name))
                .WithMessage("Brand name must be unique");
        }
    }
}
