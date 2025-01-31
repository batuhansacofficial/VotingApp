using VotingApp.Models;
using VotingApp.Repositories;

namespace VotingApp.Services
{
    public class CategoryService
    {
        private readonly CategoryRepository _categoryRepository;

        public CategoryService(CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public List<Category> GetCategories()
        {
            return _categoryRepository.GetAllCategories();
        }

        public void RequestNewCategory(string name)
        {
            _categoryRepository.AddCategory(name);
        }
    }
}
