using asseco_pfm.Models;

namespace asseco_pfm.Database.Repositories
{
    public interface ICategoryRepository
    {
        Task<Category> GetCategoryByCodeAsync(string Code);
        Category GetCategoryByCode(string Code);
        Category AddCategory(Category Category);
        Category UpdateCategory(Category Category);
        Task<List<Category>> GetAllCategories(String? Query);
        void DeleteCategoryByCode(string Code);
        bool IsCategoryExist(string Code);
    }
}
