using CrudProdutos.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudProdutos.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options)
        {

        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>().HasData(new List<Product>()
            {
                new Product(1, "Caneta BIC Preta", "5.89"),
                new Product(2, "Notebook Mac Pro", "12000.89"),
                new Product(3, "Samsung S20 +", "5000"),
            });
        }
    }
}
