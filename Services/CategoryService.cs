using BusinessObjects;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CategoryService : ICatergoryService
    {
        private readonly ICategoryRepository icategoryRepository;
        public CategoryService()
        {
            icategoryRepository = new CategoryRepository();
        }

        public List<Category> GetCategories()
        {
            return icategoryRepository.GetCategories();

        }
    }
}
