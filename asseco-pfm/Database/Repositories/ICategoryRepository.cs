using asseco_pfm.Models;

namespace asseco_pfm.Database.Repositories
{
    public interface ICategoryRepository
    {
        Task<Category> GetCategoryByCode(string Code);
        Category AddCategory(Category Category);
        Task<Category> UpdateCategory(Category Category);
        Task<List<Category>> GetAllCategories();
        void DeleteCategoryByCode(string Code);
        bool IsCategoryExist(string Code);
    }
}
