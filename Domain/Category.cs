using System;
using System.Collections.Generic;
using System.Text;

namespace Scs.Domain
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ProductCategory> ProductCategories { get; set; } = new HashSet<ProductCategory>();

    }
}
