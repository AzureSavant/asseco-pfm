using asseco_pfm.Database.Repositories;
using asseco_pfm.DTO;
using asseco_pfm.Models;
using System.Text.RegularExpressions;

namespace asseco_pfm.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public Category AddCategory(Category category)
        {
            return _categoryRepository.AddCategory(category);
        }

        public async Task<CategoryList> GetAllCategories(string? parentId)
        {
            string query = BuildQuery(parentId);
            CategoryList categoryList = new CategoryList();
            categoryList.Items = await _categoryRepository.GetAllCategories(query);
            return categoryList;

        }

        public void ImportFile(IFormFile file)
        {
            if (file.FileName.EndsWith(".csv"))
            {
                using (var sreader = new StreamReader(file.OpenReadStream()))
                {
                    Regex CSVParser = new Regex(",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");
                    string headers = sreader.ReadLine(); //split first title row
                    while (!sreader.EndOfStream)
                    {
                        string row = sreader.ReadLine();
                        string[] parsedRow = CSVParser.Split(row);
                        string Code = parsedRow[0];
                        string? ParentCode = parsedRow[1];
                        string Name = parsedRow[2];
                        if (!_categoryRepository.IsCategoryExist(Code))
                        {
                            Category categoryToSave = new Category(Code, ParentCode, Name);
                            var c = AddCategory(categoryToSave);
                        }
                    }
                }
            }
        }

        public string BuildQuery(string parentId)
        {
            string query = "SELECT * FROM category WHERE \"ParentCode\" = ''";
            if (!string.IsNullOrEmpty(parentId))
            {
                var q = $"SELECT * FROM category WHERE \"ParentCode\" = '{parentId}'";
                query = q.ToString();
                return query;
            }
            else
                return query;
        }
    }
}
