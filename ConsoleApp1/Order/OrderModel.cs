using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Order
{
    internal class OrderModel
    {
        public int id { get; set; }
        public string customerName;
        public string phoneNumber;
        public string adress;
        public List<OrderItem> items = new List<OrderItem>();

        public OrderModel() { }

        public OrderModel(string customerName, string phone, string adress)
        {
            this.customerName = customerName;
            this.phoneNumber = phone;
            this.adress = adress;
        }

        public OrderModel(int id, string customerName, string phoneNumber, string adress)
        {
            this.id = id;
            this.customerName = customerName;
            this.phoneNumber = phoneNumber;
            this.adress = adress;
        }

        public string GetName()
        {
            return customerName;
        }

        public string GetPhone()
        {
            return phoneNumber;
        }

        public string GetAdress()
        {
            return adress;
        }

        public void AddOrderItem(OrderItem item)
        {
            items.Add(item);
        }

        public float TotalBill()
        {
            float total = 0;
            foreach (var item in items)
            {
                total += item.GetBill();
            }
            return total;
        }


        public string ListToString()
        {
            string data = "";
            foreach (var item in items)
            {
                data += item.ToString() + "\n";
            }

            return data;
        }


        public void StringToList(string allItems)
        {
            string[] orderItems = allItems.Split('\n');

            foreach (var item in orderItems)
            {
                string[] parts = item.Split(',');
                if (parts.Length < 3)
                {
                    continue;
                }
                string name = parts[0];
                float price = float.Parse(parts[1]);
                int quantity = int.Parse(parts[2]);

                OrderItem orderItem = new OrderItem(name, price, quantity);
                items.Add(orderItem);

            }
        }



        public override string ToString()
        {
            return $"{customerName},{phoneNumber},{adress},{TotalBill()}";
        }
    }
}

