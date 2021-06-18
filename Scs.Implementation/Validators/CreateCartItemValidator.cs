using FluentValidation;
using Scs.Application.DataTransfer;
using Scs.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scs.Implementation.Validators
{
    public class CreateCartItemValidator : AbstractValidator<CartItemDto>
    {
        public CreateCartItemValidator(ScsContext context)
        {
            RuleFor(x => x.ProductId).Must(x => context.Products.Any(c => c.Id == x)).WithMessage("Product doesn't exist.");


        }
    }
}
