using asseco_pfm.Models;

namespace asseco_pfm.Database.Repositories
{
    public interface ICategoryRepository
    {
        Task<Category> GetCategoryByCode(string Code);
        Task<Category> AddCategory(Category Category);
        Task<Category> UpdateCategory(Category Category);
        void DeleteCategoryByCode(string Code);
    }
}
