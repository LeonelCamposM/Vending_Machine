using Domain.Products.Entities;
using System.Collections.Generic;

namespace Infrastructure.Products
{
    internal class ProductDbContext
    {
        public ProductDbContext()
        {
        }

        // IList simulates a database
        public IList<Product> Products = new List<Product>(){
            new Product(10,500,"Coca cola"),
            new Product(8,600,"Pepsi"),
            new Product(10,550,"Fanta"),
            new Product(15,725,"Sprite"),   
        };
    }
}
