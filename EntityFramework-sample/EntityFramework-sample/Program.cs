using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EntityFramework_sample
{
    class Program
    {
        static void Main(string[] args)
        {
            var product = new Product()
            {
                Name = "TestItem",
                Price = 100
            };
            using (var context = new ShoppingContext())
            {
                context.Products.Add(product);
                context.SaveChanges();

                foreach(var p in context.Products)
                {
                    Console.WriteLine(p.ProductId + " " + p.Name + " " + p.Price);
                }
            }
        }

        class Product
        {
            public int ProductId { get; set; }
            public string Name { get; set; }
            public int Price { get; set; }
        }

        class ShoppingContext : DbContext
        {
            public DbSet<Product> Products { get; set; }
        }
    }
}
