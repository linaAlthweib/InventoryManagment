using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagment
{
    class Product
    {
        public string ProductName { get; set; }
        public int ProductQuantity { get; set; }
        public decimal ProductPrice { get; set; }

        public Product(string productName, int productQuantity, decimal productPrice)
        {
            ProductName = productName;
            ProductQuantity = productQuantity;
            ProductPrice = productPrice;
        }
    }
}
