using asseco_pfm.DTO;
using asseco_pfm.Models;

namespace asseco_pfm.Services
{
    public interface ICategoryService
    {
        Category AddCategory(Category category);
        Task<CategoryList> GetAllCategories(string? parentId);
        void ImportFile(IFormFile file);
    }
}
