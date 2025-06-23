using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class Category
{
    public Category(int id, string name)
    {
        CategoryId = id;
        CategoryName = name;
    }

    public Category() { }
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
