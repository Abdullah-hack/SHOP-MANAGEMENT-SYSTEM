using ConsoleApp1.Customer;
using ConsoleApp1.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Order
{
    internal class OrderService
    {
        private OrderRepoDB orderRepo;
        private CustomerService customerService;
        private ProductService productService;

        public OrderService()
        {
            orderRepo = new OrderRepoDB();
            customerService = new CustomerService();
            productService = new ProductService();
        }

        public bool FindCustomer(string name)
        {
            return customerService.CheckByName(name);
        }

        public bool FindProduct(string name)
        {
            return productService.CheckByName(name);
        }
        public CustomerModel GetCustomer(string name)
        {
            CustomerModel customer = customerService.SearchByName(name);
            return customer;
        }

        public ProductModel GetProduct(string name)
        {
            return productService.SearchByName(name);
        }

        public void SaveCustomer(CustomerModel customer)
        {
            customerService.SaveCustomer(customer);
        }

        public void SaveOrderInFile(OrderModel order)
        {
            orderRepo.Create(order);
        }

        public List<OrderModel> display()
        {
            return orderRepo.GetOrders();
        }





        //public List<string> Names(string name, int count)
        //{
        //    List<string> names = new List<string>();
        //    foreach (var item in orderRepo.GetOrders())
        //    {
        //        if (item.GetName() == name & item.GetCount() == count)
        //        {
        //            names.Add(item.GetName());
        //        }
        //    }
        //    return names;

        //}
    }
}
