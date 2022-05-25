using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCodeFirstCRUD
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice = -1;
            do
            {
                Console.WriteLine("1.Add");
                Console.WriteLine("2.View All");
                Console.WriteLine("3.Edit");
                Console.WriteLine("4.Delete");
                Console.WriteLine("-1.Exit");
                Console.WriteLine("Enter your choice:");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1: Add(); break;
                    case 2: View(); break;
                    case 3: Edit(); break;
                    case 4: Delete(); break;
                    default: break;
                }
            } while (choice != -1);
        }

        private static void Delete()
        {
            //1.Create data context
            var context = new Model1();
            //2.Search for product to delete
            Console.WriteLine("Enter product id to search:");
            var id = int.Parse(Console.ReadLine());
            var prod = context.Products.Find(id);
            if (prod == null)
            {
                Console.WriteLine("Invalid Product id"); return;
            }

            //3.Call Remove() on DbSet
            context.Products.Remove(prod);

            //4.Call SaveChanges()
            int rows = context.SaveChanges();
            Console.WriteLine("{0} rows deleted", rows);
        }

        private static void Edit()
        {
            //1.Create data context
            var context = new Model1();
            //2.Search for product to edit
            Console.WriteLine("Enter product id to search:");
            var id = int.Parse(Console.ReadLine());
            var prod = context.Products.Find(id);
            if (prod == null)
            {
                Console.WriteLine("Invalid Product id"); return;
            }

            //3.Change properties of product object
            Console.WriteLine("Enter the new product name:");
            prod.Name = Console.ReadLine();
            Console.WriteLine("Enter the new product price:");
            prod.Price = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter the new product description:");
            prod.Description = Console.ReadLine();


            //4.Call SaveChanges() on data context
            int rows=context.SaveChanges();
            Console.WriteLine("{0} rows updated", rows);
        }

        private static void View()
        {
            //1. Create Data Context
            var context = new Model1();
            //2.Write LINQ query
            var data = from i in context.Products
                       select i;
            //3. Execute query by .ToList() or foreach loop
            foreach(var item in data)
            {
                Console.WriteLine("ID=" + item.Id);
                Console.WriteLine("Name=" + item.Name);
                Console.WriteLine("Price=" + item.Price);
                Console.WriteLine("Description=" + item.Description);
                Console.WriteLine();
            }

        }

        private static void Add()
        {
            //1. Create object of class
            var prod = new Product();

            //2. Assign properties
            //Console.WriteLine("Enter the product id:");
           // prod.Id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the product name:");
            prod.Name = Console.ReadLine();
            Console.WriteLine("Enter the product price:");
            prod.Price = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter the product description:");
            prod.Description =Console.ReadLine();

            //3. Create data context
            var context = new Model1();
            //4. Pass to DbSet Add() of data context
            context.Products.Add(prod);
            //5. Call SaveChanges() on data context
            int rows=context.SaveChanges();
            Console.WriteLine("{0} rows added",rows);
        }
    }
}
