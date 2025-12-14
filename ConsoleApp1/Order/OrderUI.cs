using ConsoleApp1.Customer;
using ConsoleApp1.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Order
{
    internal class OrderUI
    {
        private OrderService service;

        public OrderUI()
        {
            service = new OrderService();
        }

        public void OrderDriver()
        {
            service.SaveOrderInFile(TakeOrder());
        }

        public OrderModel TakeOrder()
        {
            Console.Clear();
            Header();
            OrderModel order = null;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Enter customer name : ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            string name = Console.ReadLine();

            if (service.FindCustomer(name))
            {
                CustomerModel customer = service.GetCustomer(name);
                Console.WriteLine(customer.ToString());
                order = new OrderModel(customer.name, customer.contact, customer.adress);

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Customer not found , please enter new customer details .... ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                CustomerModel customer = TakeCustomerInput();
                service.SaveCustomer(customer);
                order = new OrderModel(customer.name, customer.contact, customer.adress);

            }

            while (true)
            {
                Console.Clear();
                Header();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Do you want to purchase something ? yes / no ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                string choice = Console.ReadLine();
                if (choice == "yes")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Enter product name : ");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    string productName = Console.ReadLine();
                    if (service.FindProduct(productName))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Enter the quantity : ");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        int quantity = int.Parse(Console.ReadLine());
                        ProductModel product = service.GetProduct(productName);
                        OrderItem item = new OrderItem(product.name, product.salePrice, quantity);
                        order.AddOrderItem(item);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Product not found ..");
                        Console.ReadKey();
                        Console.ForegroundColor = ConsoleColor.Magenta;
                    }
                }

                else if (choice == "no")
                {
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Enter a valid option ");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                }
            }

            return order;


        }

        public CustomerModel TakeCustomerInput()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Enter the name : ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            string name = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Enter the age : ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            int age = int.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Enter the phone number : ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            string contact = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Enter the adress : ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            string adress = Console.ReadLine();
            CustomerModel customer = new CustomerModel(name, age, contact, adress);
            return customer;
        }

        public void DisplayAllOrders()
        {
            List<OrderModel> orders = service.display();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("========================================");
            Console.WriteLine("               ALL ORDERS               ");
            Console.WriteLine("========================================");
            Console.ForegroundColor = ConsoleColor.Magenta;
            foreach (var order in orders)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine(order.ToString());
                foreach (var item in order.items)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(item.ToString());
                }
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"Total : {order.TotalBill()}");
                Console.WriteLine();
            }

            Console.ReadKey();
        }

        public void Header()
        {
            Console.WriteLine("========================================");
            Console.WriteLine("              TAKE ORDERS               ");
            Console.WriteLine("========================================");
        }
    }
}
