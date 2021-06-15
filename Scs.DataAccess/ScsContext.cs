using Microsoft.EntityFrameworkCore;
using Scs.Domain;
using System;

namespace Scs.DataAccess
{
    public class ScsContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=COJA-PC\SQLEXPRESS;Initial Catalog=Setup;Integrated Security=True");
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Brand> Brands { get; set; }
    }
}
