using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public partial class Product
    {
        public Product(int id, string name, int catId,
            short unitInStock, decimal price)
        {
            this.productId = id;
            this.productName = name;
            this.categoryId = catId;
            this.unitsInStock = unitInStock;
            this.untiPrice = price; 
        }

        public int productId { get; set; }
        public string productName { get; set; }
        public int? categoryId { get; set; }
        public short? unitsInStock { get; set; }

        public decimal? untiPrice { get; set; }

        public virtual Category Category { get; set; }

    }

}
