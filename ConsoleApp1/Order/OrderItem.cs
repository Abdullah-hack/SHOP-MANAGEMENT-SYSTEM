using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Order
{
    internal class OrderItem
    {
        public string productName;
        public float salePrice;
        public int quantity;
        public float bill;

        public OrderItem() { }

        public OrderItem(string productName, float salePrice, int quantity)
        {
            this.productName = productName;
            this.salePrice = salePrice;
            this.quantity = quantity;
            bill = quantity * salePrice;
        }

        public string GetName()
        {
            return productName;
        }

        public float GetSalePrice()
        {
            return salePrice;
        }

        public int GetQuantity()
        {
            return quantity;
        }

        public float GetBill()
        {
            return quantity * salePrice;
        }


        public override string ToString()
        {
            return $"{productName},{salePrice},{quantity}";
        }
    }
}
