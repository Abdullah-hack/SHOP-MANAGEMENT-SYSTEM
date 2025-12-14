using ConsoleApp1.Customer;
using ConsoleApp1.Product;
using ConsoleApp1.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Shop
    {
        CustomerUI customerUI = new CustomerUI();
        ProductUI productUI = new ProductUI();
        OrderUI orderUI = new OrderUI();
        public void Start()
        {
            while (true)
            {
                Console.Clear();
                string option = MainMenu();

                if (option == "1")
                {
                    productUI.ProductDriver();
                }

                else if (option == "2")
                {
                    customerUI.CustomerDriver();
                }

                else if (option == "3")
                {
                    orderUI.OrderDriver();
                }

                else if (option == "4")
                {
                    orderUI.DisplayAllOrders();

                }

                else if (option == "0")
                {
                    break;
                }

                else
                {
                    Console.WriteLine("Enter a valid option : ");
                    Console.ReadKey();
                }

            }
        }
        public string MainMenu()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("========================================");
            Console.WriteLine("        SHOP MANAGEMENT SYSTEM          ");
            Console.WriteLine("========================================");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("1. Product Management");
            Console.WriteLine("2. Customer Management");
            Console.WriteLine("3. Create New Sale (Order)");
            Console.WriteLine("4. View Order History");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("0. Exit Application");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("-----------------------------------------");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter Your Choice : ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            string option = Console.ReadLine();
            return option;
        }

        //public string AdvanceSearchMenu()
        //{
        //    Console.ForegroundColor = ConsoleColor.Green;
        //    Console.WriteLine("========================================");
        //    Console.WriteLine("             ADVANCE SEARCH             ");
        //    Console.WriteLine("========================================");
        //    Console.ForegroundColor = ConsoleColor.Blue;
        //    Console.WriteLine("1. Find Customer by Name");
        //    Console.WriteLine("2. Find Customer by First Character");
        //    Console.WriteLine("3. Find Customer by Phone Number");
        //    Console.WriteLine("4. Find Customer by Address");
        //    Console.WriteLine("5. Find Customer by Age");
        //    Console.WriteLine("6. Find Product by Name");
        //    Console.WriteLine("7. Find Product by Price");
        //    Console.WriteLine("8. Find Products Between a Given Price Range");
        //    Console.WriteLine("9. Find Products by Price Difference");
        //    Console.WriteLine("10. Find Products by Substring");
        //    Console.ForegroundColor = ConsoleColor.Red;
        //    Console.WriteLine("0. Exit");
        //    Console.ForegroundColor = ConsoleColor.Green;
        //    Console.WriteLine("-----------------------------------------");
        //    Console.ForegroundColor = ConsoleColor.Yellow;
        //    Console.Write("Enter Your Choice : ");
        //    Console.ForegroundColor = ConsoleColor.Magenta;
        //    string option = Console.ReadLine();
        //    return option;
        //}
    }
}
