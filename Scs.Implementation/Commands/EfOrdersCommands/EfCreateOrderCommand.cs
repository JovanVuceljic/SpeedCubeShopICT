using Scs.Application.Commands.OrderCommands;
using Scs.Application.DataTransfer;
using Scs.DataAccess;
using Scs.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scs.Implementation.Commands.EfOrdersCommands
{
    public class EfCreateOrderCommand : ICreateOrderCommand
    {
        private readonly ScsContext _context;

        public EfCreateOrderCommand(ScsContext context)
        {
            _context = context;
        }

        public int Id => 1;

        public string Name => "Create New Order using Ef";

        public void Execute(OrderDto request)
        {
            var order = new Order
            {
                Address = request.Address,
                UserId = request.UserId,
                CreatedAt = DateTime.Now,
            };

            _context.Orders.Add(order);
            _context.SaveChanges();
            
        }
    }
}
