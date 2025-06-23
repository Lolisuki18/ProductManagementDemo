using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ProductDAO
    {
        private static List<Product>? listProducts = new();

        //static ProductDAO()
        //{
        //    Product chai = new Product(1, "Chai", 3, 12, 18);
        //    Product chang = new Product(2, "Chang", 1, 23, 19);
        //    Product aniseed = new Product(3, "Aniseed Syrup", 2, 23, 10);
        //    listProducts = new List<Product> { chai, chang, aniseed };

        //    //Product chef = new Product(4, "Chef Anton's Cajun Seasoning", 2, 34, 22);
        //    //Product chefMix = new Product(5, "Chef Anton's Gumbo Mix", 2, 45, 34);
        //    //Product grandma = new Product(6, "Grandma's Boysenberry Spread", 2, 21, 25);
        //    //Product uncle = new Product(7, "Uncle Bob's Organic Dried Pears", 7, 22, 30);
        //    //Product northwoods = new Product(8, "Northwoods Cranberry Sauce", 2, 10, 40);
        //    //Product mishi = new Product(9, "Mishi Kobe Niku", 6, 12, 97);
        //    //Product ikura = new Product(10, "Ikura", 8, 13, 32);

        //    // listProducts = new List<Product> { chai, chang, aniseed, chef, chefMix, grandma, uncle, northwoods, mishi, ikura };
        //}

        //public List<Product> GetProduct()
        //{
        //    return ProductDAO.listProducts;
        //}
        public static  List<Product> GetProducts()
        {
            var listProducts = new List<Product>();
            try
            {
                using var db = new MyStoreContext();
                listProducts = db.Products.ToList();
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
            }
            return listProducts;
        }

        ///lưu 1 product
        public static void SaveProduct(Product p)
        {
            try
            {
                //listProducts.Add(p);
                using var context = new MyStoreContext();
                context.Products.Add(p);//add product vào collection
                context.SaveChanges(); //lưu vào database
            }catch(Exception e)
            {
                throw new Exception(e.Message);
            }

        }
        //cập nhập 1 product
        public static void UpdateProduct(Product product)
        {
            try
            {
                using var context = new MyStoreContext();
                context.Entry<Product>(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //Xoá 1 product
        public static void DeleteProduct(Product product)
        {
            try
            {
                using var context = new MyStoreContext();
                var p1 = context.Products.SingleOrDefault(c => c.ProductId == product.ProductId);
                context.Products.Remove(p1);
                context.SaveChanges();
            }catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //Lấy product theo id
        public static Product GetProductById(int id)
        {
           using var db = new MyStoreContext();
            return db.Products.FirstOrDefault(c => c.ProductId.Equals(id));
        }
    }
}
