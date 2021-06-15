using Scs.Application.Commands;
using Scs.Application.Exceptions;
using Scs.DataAccess;
using Scs.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scs.Implementation.Commands
{
    public class EfDeleteBrandCommand : IDeleteBrandCommand
    {
        public readonly ScsContext _context;

        public EfDeleteBrandCommand(ScsContext context)
        {
            _context = context;
        }

        public int Id => 1;

        public string Name => "Deleting group";

        public void Execute(int request)
        {
            var brand = _context.Brands.Find(request);
            if(brand == null)
            {
                throw new EntityNotFoundException(request, typeof(Brand));
            }
            _context.Brands.Remove(brand);
            _context.SaveChanges();
        }
    }
}
