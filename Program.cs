// See https://aka.ms/new-console-template for more information
using InventoryManagment;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagmentSystem
{

    class program
    {
        public static void Main(string[] args)
        {
            
            ProductService productService = new ProductService();

            //create a new product
            List<Product> products = new List<Product>();

            //Display Menu
            DisplayMenu();

            
            Console.Write("Enter an option:");

            //choose option from the menu
            string input = Console.ReadLine();

            do
            {
                switch (input)
                {
                    case "1":
                        productService.DisplayProduct(products);
                        break;
                    case "2":
                        products.Add(productService.CreateProduct());
                        break;
                    case "3":
                        productService.EditProduct(products);
                        productService.DisplayProduct(products);
                        break;
                    case "4":
                        productService.DeleteProduct(products);
                        break;
                    case "5":
                        productService.SearchProduct(products);
                        break;
 
                }
                DisplayMenu();
                Console.Write("Enter an option:");
                input = Console.ReadLine();



            } while (input != "exit");
        
        }
        public static void DisplayMenu()
        {
            Console.WriteLine("");
            Console.WriteLine("Menu items");
            Console.WriteLine("1.Display products");
            Console.WriteLine("2.Add products");
            Console.WriteLine("3.Edit products");
            Console.WriteLine("4.Delete products");
            Console.WriteLine("5.Search products");
        }
    }
    
}



