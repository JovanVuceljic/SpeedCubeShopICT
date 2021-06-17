using Scs.Application.Commands;
using Scs.Application.Exceptions;
using Scs.DataAccess;
using Scs.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scs.Implementation.Commands
{
    public class EfDeleteCategoryCommand : IDeleteCategoryCommand
    {
        public readonly ScsContext _context;

        public EfDeleteCategoryCommand(ScsContext context)
        {
            _context = context;
        }

        public int Id => 1;

        public string Name => "Deleting category";

        public void Execute(int request)
        {
            var category = _context.Categories.Find(request);
            if(category == null)
            {
                throw new EntityNotFoundException(request, typeof(Category));
            }
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }
    }
}
