using asseco_pfm.Models;

namespace asseco_pfm.Services
{
    public interface ICategoryService
    {
        Category AddCategory(Category category);
        Task<List<Category>> GetAllCategories();
        void ImportFile(IFormFile file);
    }
}
