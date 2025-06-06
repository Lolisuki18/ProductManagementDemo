using BusinessObjects;
using DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ProductRepository : IProductRepository
    {

        public void SaveProduct(Product product) => ProductDAO.saveProduct(product);
        
            
      
        public void DeleteProduct(Product p) => ProductDAO.deleteProduct(p);
        
        public void UpdateProduct(Product p) => ProductDAO.updateProduct(p);

        public List<Product> GetProducts() => ProductDAO.GetProducts();

        public Product GetProductById(int id) => ProductDAO.GetProductById(id);

    }
    {
    }
}
