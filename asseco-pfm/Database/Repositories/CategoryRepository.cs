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

        public  Category AddCategory(Category Category)
        {


            if (!string.IsNullOrEmpty(Category.ParentCode) && IsCategoryExist(Category.ParentCode))
            {
                var parentCategory =  GetCategoryByCode(Category.ParentCode);
                Category.Parent = parentCategory;
                var category = _dbContext.Category.Add(Category);
            }
            else
            {
                var category = _dbContext.Category.Add(Category);
            }

            _dbContext.SaveChanges();

            return Category;
        }

        public void DeleteCategoryByCode(string Code)
        {
            var category = GetCategoryByCodeAsync(Code);
            if (category == null)
                return;

            _dbContext.Remove(category);
            _dbContext.SaveChanges();
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return await _dbContext.Category.ToListAsync();
        }

        public Category GetCategoryByCode(string Code)
        {
            return _dbContext.Category.First(c => c.Code.Equals(Code));
        }

        public async Task<Category> GetCategoryByCodeAsync(string Code)
        {
            return await _dbContext.Category.FirstAsync(c => c.Code.Equals(Code));
        }

        public bool IsCategoryExist(string Code)
        {
            return _dbContext.Category.AsEnumerable().Any(c => c.Code.Equals(Code));
        }

        public  Category UpdateCategory(Category Category)
        {
            var category =  _dbContext.Category.Update(Category);
            _dbContext.SaveChanges();
            return Category;

        }
    }
}
