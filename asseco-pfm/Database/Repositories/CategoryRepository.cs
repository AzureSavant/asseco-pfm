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

        public async Task<Category> AddCategory(Category Category)
        {

            _dbContext.Category.Add(Category);

            await _dbContext.SaveChangesAsync();

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

        public async Task<Category> GetCategoryByCode(string code)
        {
            return await _dbContext.Category.FirstOrDefaultAsync(c => c.Code.Equals(code));
        }

        public async Task<Category> UpdateCategory(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
