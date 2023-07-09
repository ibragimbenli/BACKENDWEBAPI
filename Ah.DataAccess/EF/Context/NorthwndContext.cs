using Ah.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Ah.DataAccess.EF.Context
{
    public class NorthwndContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.\\;database=Northwind;trusted_connection=true;");
        }
        public DbSet<Product> Products { get; set; } //Veri Tabanındaki Tablonun Gerçek Modeli
        public DbSet<Category> Categories { get; set; }
        public DbSet<Employee> Employees { get; set; }

        //Mapping
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Product>().Property(x => x.ProductName).HasColumnName("UrunAdi");
        //    modelBuilder.Entity<Product>().ToTable("Products");
        //}
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    //Write Fluent API configurations here

        //    //Property Configurations
        //    modelBuilder.Entity<Employee>()
        //            .Property(x => x.BirthDate)
        //            .HasColumnName("DogumTarihi")
        //            .HasDefaultValue(0)
        //            .IsRequired()
        //            .HasMaxLength(50)
        //            ;
        //}



    }
}
