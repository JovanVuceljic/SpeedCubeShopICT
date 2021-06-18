using Scs.Application.Commands.OrderCommands;
using Scs.Application.Exceptions;
using Scs.DataAccess;
using Scs.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scs.Implementation.Commands.EfOrdersCommands
{
    public class EfDeleteOrderCommand : IDeleteOrderCommand
    {
        public readonly ScsContext _context;

        public EfDeleteOrderCommand(ScsContext context)
        {
            _context = context;
        }

        public int Id => 1;

        public string Name => "Deleting Order";

        public void Execute(int request)
        {
            var order = _context.Orders.Find(request);
            if (order == null)
            {
                throw new EntityNotFoundException(request, typeof(Order));
            }
            _context.Orders.Remove(order);
            _context.SaveChanges();
        }
    }
}
