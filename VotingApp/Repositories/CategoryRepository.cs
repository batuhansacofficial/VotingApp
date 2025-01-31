using VotingApp.Models;

namespace VotingApp.Repositories
{
    public class CategoryRepository
    {
        private readonly List<Category> _categories = new List<Category>()
        {
            new Category(1, "Teknoloji"),
            new Category(2, "Mutfak"),
            new Category(3, "Eğlence"),
            new Category(4, "Sport"),
            new Category(5, "Seyahat"),
            new Category(6, "Sağlık"),
            new Category(7, "Moda"),
            new Category(8, "Eğitimm")
        };

        public List<Category> GetAllCategories()
        {
            return _categories;
        }

        public Category? GetCategoryById(int id)
        {
            return _categories.FirstOrDefault(c => c.Id == id);
        }

        public void AddCategory(string name)
        {
            int newId = _categories.Max(c => c.Id) + 1;
            _categories.Add(new Category(newId, name));
        }
    }
}
