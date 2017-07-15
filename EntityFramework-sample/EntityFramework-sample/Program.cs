using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace EntityFramework_sample
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Initializer
            Database.SetInitializer(
                new DropCreateDatabaseIfModelChanges<ShoppingContext>());
            #endregion

            var product = new Product()
            {
                Name = "TestItem",
                Price = 100
            };
            using (var context = new ShoppingContext())
            {
                context.Products.Add(product);
                context.SaveChanges();

                #region Console display
                //foreach(var p in context.Products)
                //{
                //    Console.WriteLine(p.ProductId + " " + p.Name + " " + p.Price);
                //}
                #endregion
            }
        }

        class Product
        {
            public int ProductId { get; set; }
            
            /*Annotation*/
            //[Required]
            //[MaxLength(200)]
            public string Name { get; set; }
            public int Price { get; set; }
            //public int Stock { get; set; }
        }

        class ShoppingContext : DbContext
        {
            public DbSet<Product> Products { get; set; }

            /*Fluent API*/
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);

                modelBuilder.Entity<Product>()
                    .Property(d => d.Name)
                    .IsRequired()
                    .HasMaxLength(200);
            }
        }
    }
}
