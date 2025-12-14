using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp1.Customer
{
    internal class CustomerUI
    {
        private CustomerService service;

        public CustomerUI()
        {
            service = new CustomerService();
        }


        public void CustomerDriver()
        {
            while (true)
            {
                Console.Clear();
                string option = CustomerMenu();

                if (option == "1")
                {
                    service.SaveCustomer(TakeInput());
                    Console.WriteLine("Customer added successfully...");
                    Console.ReadKey();
                }
                else if (option == "2")
                {
                    if (service.UpdateCustomer(TakeUpdateCustomer()))
                    {
                        Console.WriteLine("Updated successfully...");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Customer not found");
                        Console.ReadKey();
                    }
                }
                else if (option == "3")
                {
                    if (service.DeleteCustomer(DeleteCustomer()))
                    {
                        Console.WriteLine("Customer deleted successfully...");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Customer not found");
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





        public string CustomerMenu()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("========================================");
            Console.WriteLine("           CUSTOMER MANAGEMENT           ");
            Console.WriteLine("========================================");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("1. Add New Customer");
            Console.WriteLine("2. Update Customer");
            Console.WriteLine("3. Delete Customer");
            Console.WriteLine("4. View All Customers");
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

        public CustomerModel TakeInput()
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


        public CustomerModel TakeUpdateCustomer()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Enter the customer id : ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            int id = int.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Enter the customer name : ");
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
            CustomerModel customer = new CustomerModel(id, name, age, contact, adress);

            return customer;
        }


        public int DeleteCustomer()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Enter the customer id : ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            int id = int.Parse(Console.ReadLine());

            return id;
        }

        public void DisplayAllData()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("========================================");
            Console.WriteLine("             ALL CUSTOMERS              ");
            Console.WriteLine("========================================");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("ID,Name,phoneNumber,Age,Adress");
            foreach (var customer in service.GetAllCustomers())
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(customer.ToString());
            }
            Console.ReadKey();
        }
    }
}
