using Application.Interfaces;
using Domain.Entities;

namespace Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IApplicationDbContext _context;

        public CategoryService(IApplicationDbContext context)
        {
            _context = context;
        }

        public void AddCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public void DeleteCategory(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetAllCategories()
        {
            throw new NotImplementedException();
        }

        public Category GetCategoryById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateCategory(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
