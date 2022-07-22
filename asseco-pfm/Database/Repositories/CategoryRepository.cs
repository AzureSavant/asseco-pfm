using asseco_pfm.Models;
using Microsoft.EntityFrameworkCore;

namespace asseco_pfm.Database.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _dbContext;

        public CategoryRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Category AddCategory(Category Category)
        {

            _dbContext.Category.Add(Category);

            _dbContext.SaveChanges();

            return Category;
        }

        public void DeleteCategoryByCode(string Code)
        {
            var category = GetCategoryByCode(Code);
            if (category == null)
                return;

            _dbContext.Remove(category);
            _dbContext.SaveChanges();
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return await _dbContext.Category.ToListAsync();
        }

        public async Task<Category> GetCategoryByCode(string code)
        {
            return await _dbContext.Category.FirstOrDefaultAsync(c => c.Code.Equals(code));
        }

        public bool IsCategoryExist(string Code)
        {
            return _dbContext.Category.AsEnumerable().Any(c => c.Code.Equals(Code));
        }

        public async Task<Category> UpdateCategory(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
