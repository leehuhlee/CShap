using ContosoPets.Data;
using ContosoPets.Models;
using System;
using System.Linq;

namespace ContosoPets
{
    class Program
    {
        static void Main(string[] args)
        {
            using ContosoPetsContext context = new ContosoPetsContext();

            //Product squeakyBone = new Product()
            //{
            //    Name = "Squeaky Dog Bone",
            //    Price = 4.99M
            //};
            //context.Products.Add(squeakyBone);

            //Product tennisBalls = new Product()
            //{
            //    Name = "Tennis Ball 3-Pack",
            //    Price = 9.99M
            //};
            //context.Add(tennisBalls);

            //context.SaveChanges();

            //var products = context.Products
            //    .Where(p => p.Price >= 5.00m)
            //    .OrderBy(p => p.Name);

            var squeakyBone = context.Products
                                .Where(p => p.Name == "Squeaky Dog Bone")
                                .FirstOrDefault();
            if(squeakyBone is Product)
            {
                squeakyBone.Price = 7.99m;
                context.Remove(squeakyBone);
            }
            context.SaveChanges();

            var products = from product in context.Products
                           where product.Price > 5.00m
                           orderby product.Name
                           select product;

            foreach(Product p in products)
            {
                Console.WriteLine($"Id:     {p.Id}");
                Console.WriteLine($"Name:   {p.Name}");
                Console.WriteLine($"Price:  {p.Price}");
                Console.WriteLine(new string('-',20));
            }
        }
    }
}
