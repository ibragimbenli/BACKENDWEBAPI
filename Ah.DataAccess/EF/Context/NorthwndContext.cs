using Ah.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ah.DataAccess.EF.Context
{
    public class NorthwndContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.\\;database=Northwind;trusted_connection=true;");
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
