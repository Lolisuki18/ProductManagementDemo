using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public Category(int catId, string catName)
        {
            this.categoryId = catId;
            this.categoryName = catName;
           
        }

        public int categoryId { get; set; } 
        public string categoryName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
