using FluentValidation;
using Scs.Application.DataTransfer;
using Scs.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scs.Implementation.Validators
{
    public class CreateCategoryValidator : AbstractValidator<CategoryDto>
    {
        public CreateCategoryValidator(ScsContext context)
        {
            RuleFor(x => x.Name).NotEmpty().Must(name => !context.Categories.Any(b => b.Name == name))
                .WithMessage("Category name must be unique");
        }
    }
}
