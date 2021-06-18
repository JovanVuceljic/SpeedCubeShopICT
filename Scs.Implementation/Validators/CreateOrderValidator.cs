using FluentValidation;
using Scs.Application.DataTransfer;
using Scs.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scs.Implementation.Validators
{
    public class CreateOrderValidator : AbstractValidator<OrderDto>
    {
        public CreateOrderValidator(ScsContext context)
        {

            RuleFor(x => x.Address).NotEmpty().WithMessage("Address is required");
            /*
            RuleFor(x => x.OrderLines).NotEmpty().WithMessage("Order lines are required.").DependentRules(() =>
            {
                RuleFor(x => x.OrderLines).Must(orderLines =>
                {
                    var orderIds = orderLines.Select(x => x.ProductId).Distinct();

                    return orderIds.Count() == orderLines.Count();
                }).WithMessage("There are duplicate order lines.").DependentRules(() =>
                {
                    RuleForEach(x => x.OrderLines).SetValidator(new CreateOrderLineValidator(context));
                });
            });
            */
        }
    }
}
