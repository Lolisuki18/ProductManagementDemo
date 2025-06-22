using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IProductService
    {

        List<Product> GetProduct();
        void SaveProduct(Product p);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
        Product GetProductById(int id);
    }
}
