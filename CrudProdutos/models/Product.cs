using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudProdutos.models
{
    public class Product
    {
        public Product()
        {

        }

        public Product(int id, string name, string price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
    }
}
