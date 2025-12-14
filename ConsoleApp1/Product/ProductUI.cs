using ConsoleApp1.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Product
{
    internal class ProductUI
    {
        private ProductService service;

        public ProductUI()
        {
            service = new ProductService();
        }

        public void ProductDriver()
        {
            while (true)
            {
                Console.Clear();
                string option = ProductMenu();

                if (option == "1")
                {
                    service.SaveProduct(TakeInput());
                    Console.WriteLine("Product added successfully...");
                    Console.ReadKey();
                }
                else if (option == "2")
                {
                    if (service.UpdateProduct(TakeUpdateProduct()))
                    {
                        Console.WriteLine("Updated successfully...");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Product not found");
                        Console.ReadKey();
                    }
                }
                else if (option == "3")
                {
                    if (service.DeleteProduct(DeleteProduct()))
                    {
                        Console.WriteLine("Product deleted successfully...");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Product not found");
                        Console.ReadKey();
                    }
                }
                else if (option == "4")
                {
                    DisplayAllData();
                }
                else if (option == "0")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Enter a valid option ...");
                    Console.ReadKey();
                }
            }
        }





        public string ProductMenu()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("========================================");
            Console.WriteLine("           PRODUCT MANAGEMENT           ");
            Console.WriteLine("========================================");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("1. Add New Product");
            Console.WriteLine("2. Update Product");
            Console.WriteLine("3. Delete Product");
            Console.WriteLine("4. View All Products");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("0. Go Back to Main Menu");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("-----------------------------------------");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter Your Choice : ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            string option = Console.ReadLine();
            return option;
        }

        public ProductModel TakeInput()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Enter the name : ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            string name = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Enter the Purchase Price : ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            float purchasePrice = float.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Enter the Sale Price : ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            float salePrice = float.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Enter the Discount : ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            float discount = float.Parse(Console.ReadLine());
            ProductModel product = new ProductModel(name, purchasePrice, salePrice, discount);
            return product;
        }


        public ProductModel TakeUpdateProduct()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Enter the Product ID  : ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            int id = int.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Enter the Product name : ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            string name = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Enter the Purchase Price : ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            float purchasePrice = float.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Enter the Sale Price : ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            float salePrice = float.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Enter the Discount : ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            float discount = float.Parse(Console.ReadLine());
            ProductModel product = new ProductModel(id, name, purchasePrice, salePrice, discount);

            return product;
        }


        public string DeleteProduct()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Enter the Product Name : ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            string name = Console.ReadLine();

            return name;
        }

        public void DisplayAllData()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("========================================");
            Console.WriteLine("             ALL Products              ");
            Console.WriteLine("========================================");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("ID,Name,PurchasePrice,SalePrice,Discount");
            foreach (var product in service.GetAll())
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(product.ToString());
            }
            Console.ReadKey();
        }
    }
}
