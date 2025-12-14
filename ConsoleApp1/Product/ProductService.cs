using ConsoleApp1.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Product
{
    internal class ProductService
    {
        private ProductRepoDb _dbRepo;

        public ProductService()
        {
            _dbRepo = new ProductRepoDb();
        }

        public void SaveProduct(ProductModel product)
        {
            _dbRepo.Create(product);
        }

        public bool UpdateProduct(ProductModel product)
        {
            return _dbRepo.Update(product);
        }

        public bool DeleteProduct(string name)
        {
            return _dbRepo.Delete(name);
        }

        public List<ProductModel> GetAll()
        {
            return _dbRepo.GetAllProducts();
        }

        public bool CheckByName(string name)
        {
            foreach (var product in _dbRepo.GetAllProducts())
            {
                if (product.name == name)
                {
                    return true;
                }
            }
            return false;
        }

        public ProductModel SearchByName(string name)
        {
            foreach (var product in _dbRepo.GetAllProducts())
            {
                if (product.name == name)
                {
                    return product;
                }
            }
            return null;
        }
    }
}
