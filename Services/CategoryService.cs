using BusinessObjects;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepositorycs icategoryRepository;
        public CategoryService()
        {
            icategoryRepository = new CategoryRepository(); // Assuming CategoryRepository implements ICategoryRepository
        }
        public List<Category> GetCategories()
        {
            return icategoryRepository.GetCategories();
        }
    }
}
