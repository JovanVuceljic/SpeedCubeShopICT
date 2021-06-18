using Scs.Application.Commands;
using Scs.Application.Exceptions;
using Scs.DataAccess;
using Scs.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scs.Implementation.Commands
{
    public class EfDeleteProductCategoryCommand : IDeleteProductCategoryCommand
    {
        public readonly ScsContext _context;

        public EfDeleteProductCategoryCommand(ScsContext context)
        {
            _context = context;
        }

        public int Id => 1;

        public string Name => "Deleting category";

        public void Execute(int request)
        {
            var productCategory = _context.ProductCategories.Find(request);
            if(productCategory == null)
            {
                throw new EntityNotFoundException(request, typeof(ProductCategory));
            }
            _context.ProductCategories.Remove(productCategory);
            _context.SaveChanges();
        }

    }
}
