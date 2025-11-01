using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Product
{
    internal class ProductService
    {
        private ProductRepoDb dbRepo;

        public ProductService()
        {
            dbRepo = new ProductRepoDb();
        }

        public void SaveProduct(ProductModel product)
        {
            dbRepo.Create(product);
        }

        public bool UpdateProduct(ProductModel product)
        {
            return dbRepo.Update(product);
        }

        public bool DeleteProduct(string name)
        {
            return dbRepo.Delete(name);
        }

        public List<ProductModel> GetAll()
        {
            return dbRepo.GetAllProducts();
        }
    }
}
