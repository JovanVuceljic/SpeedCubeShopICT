using Scs.Application.Commands;
using Scs.Application.Exceptions;
using Scs.DataAccess;
using Scs.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scs.Implementation.Commands
{
    public class EfDeleteCartItemCommand : IDeleteCartItemCommand
    {
        public readonly ScsContext _context;

        public EfDeleteCartItemCommand(ScsContext context)
        {
            _context = context;
        }

        public int Id => 1;

        public string Name => "Deleting cart item";

        public void Execute(int request)
        {
            var cartItem = _context.CartItems.Find(request);
            if(cartItem == null)
            {
                throw new EntityNotFoundException(request, typeof(CartItem));
            }
            _context.CartItems.Remove(cartItem);
            _context.SaveChanges();
        }

    }
}
