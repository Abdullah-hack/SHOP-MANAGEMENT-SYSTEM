using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Product
{
    internal class ProductModel
    {
        public int id {  get; set; }
        public string name { get; set; }
        public float salePrice { get; set; }
        public float purchasePrice { get; set; }
        public float discount {  get; set; }

        public ProductModel(int id, string name, float purchasePrice, float salePrice, float discount)
        {
            this.id = id;
            this.name = name;
            this.salePrice = salePrice;
            this.purchasePrice = purchasePrice;
            this.discount = discount;
        }

        public ProductModel(string name, float purchasePrice, float salePrice, float discount)
        {
            this.name = name;
            this.salePrice = salePrice;
            this.purchasePrice = purchasePrice;
            this.discount = discount;
        }

        public override string ToString()
        {
            return id + "," + name + "," + purchasePrice + "," + salePrice + "," + discount;
        }
    }
}
