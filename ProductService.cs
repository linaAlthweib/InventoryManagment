using InventoryManagmentSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace InventoryManagment
{
    class ProductService
    {

        public Product CreateProduct()
        {
            Console.Write("Welcome to the Inventory Managment System\n");
            //name
            Console.WriteLine("Enter the product name: ");
            string name = Console.ReadLine();
            //quantity
            Console.WriteLine("Enter the product quantity: ");
            string quantityinput = Console.ReadLine();
            int quantity;
            if (!int.TryParse(quantityinput, out quantity))
            {
                Console.WriteLine("Invalid input quantity");
            }
            //price
            Console.Write("Enter the price : ");
            string priceinput = Console.ReadLine();
            int price;
            if (!int.TryParse(priceinput, out price))
            {
                Console.WriteLine("Invalid input price");
            }
            return new Product(name, quantity, price);

        }




        public void EditProduct(List<Product> products)
        {
            DisplayProduct(products);
            Console.Write("\nEnter the product name to edit:(press enter to skip) ");
            string name = Console.ReadLine();

            Product product = products.Find(p => p.ProductName.Equals(name,StringComparison.OrdinalIgnoreCase));

            if (product != null)
            {
                Console.WriteLine("Enter the new product name (press enter to skip)");
                string newName = Console.ReadLine();
                if (!string.IsNullOrEmpty(newName))
                {
                    product.ProductName = newName;
                }
                Console.WriteLine("Enter the new product quantity: (press enter to skip)");
                string newQuantity = Console.ReadLine();
                if (!string.IsNullOrEmpty(newQuantity))
                {
                    product.ProductQuantity = ReadIntFromConsole("error quantity");
                }

                Console.WriteLine("Enter the new product price: (press enter to skip)");
                string newPrice = Console.ReadLine();
                if (!string.IsNullOrEmpty(newPrice))
                {
                    product.ProductPrice = ReadIntFromConsole("error pric");
                }
            }
            else
            {
                Console.WriteLine("Product not found");
            }
        }


        public void DisplayProduct(List<Product> products)
        {
            if (products.Count == 0)
            {
                Console.WriteLine("No products available");
                return;
            }
            Console.WriteLine("Available Products:");
            foreach (Product product in products)
            {
                Console.Write($"Product:{product.ProductName},Quantity:{product.ProductQuantity},Price:{product.ProductPrice}");

            }
        }

        public void DeleteProduct(List<Product> products)
        {
            DisplayProduct(products);
            Console.WriteLine("Enter the product name to delete:");
            string name = Console.ReadLine();
            Product product = products.Find(p => p.ProductName.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (product != null)
            {
                products.Remove(product);
                Console.WriteLine("Product deleted");
            }
            else { Console.WriteLine("product not found");
            }
        }

        public void SearchProduct(List<Product> products)
        {
            Console.WriteLine("Enter the product name to search: ");
            string searchQuery = Console.ReadLine().ToLower();
            var foundProducts = products.Where(p => p.ProductName.ToLower().Contains(searchQuery)).ToList();
            if (foundProducts.Count > 0)
            {
                Console.WriteLine("Found products:");
                foreach (var product in foundProducts)
                {
                    Console.WriteLine($"Product:{product.ProductName},Quantity:{product.ProductQuantity},Price:{product.ProductPrice}");

                }

            }
            else Console.WriteLine(" No products found ");
        }

        public int ReadIntFromConsole(string errorMessage)
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int result)) 
                { 
                    return result;
                }
                Console.WriteLine(errorMessage);
            }

        }

        public decimal ReadDecimalFromConsole(string errorMessage)
        {
            while (true)
            {
                if (decimal.TryParse(Console.ReadLine(), out decimal result))
                {
                    return result;
                }
                Console.WriteLine(errorMessage);
            }

        }

    }
}
