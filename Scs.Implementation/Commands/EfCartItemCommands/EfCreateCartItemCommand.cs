using FluentValidation;
using Scs.Application.Commands;
using Scs.Application.DataTransfer;
using Scs.DataAccess;
using Scs.Domain;
using Scs.Implementation.Validators;
using System;

namespace Scs.Implementation
{
    public class EfCreateCartItemCommand : ICreateCartItemCommand
    {
        
        private readonly ScsContext _context;
        private readonly CreateCartItemValidator _validator;

        public EfCreateCartItemCommand(CreateCartItemValidator validator, ScsContext context)
        {
            _validator = validator;
            _context = context;
        }

        public int Id => 1;

        public string Name => "Create New CartItem using EF";


        public void Execute(CartItemDto request)
        {
            _validator.ValidateAndThrow(request);

            var cartItem = new CartItem
            {
                Id = request.Id,
                ProductId = request.ProductId,
                Quantity = request.Quantity,
                OrderId = request.OrderId,
            };

            _context.CartItems.Add(cartItem);

            _context.SaveChanges();
        }
    }
}
