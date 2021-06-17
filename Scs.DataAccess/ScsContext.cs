using Microsoft.EntityFrameworkCore;
using Scs.Domain;
using Scs.EfDataAccess.Configurations;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new BrandConfiguration());
        }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
