using BusinessObjects;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository iProductRepository;

        public void DeleteProduct(Product product)
        {
            iProductRepository.DeleteProduct(product);
        }

        public List<Product> GetProduct()
        {
            return iProductRepository.GetProduct();
        }

        public Product GetProductById(int id)
        {
            return iProductRepository.GetProductById(id);
        }

        public void SaveProduct(Product p)
        {
          iProductRepository.SaveProduct(p);
        }

        public void UpdateProduct(Product product)
        {
           iProductRepository.UpdateProduct(product);
        }
    }
}
