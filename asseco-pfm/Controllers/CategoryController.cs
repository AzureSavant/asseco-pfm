using asseco_pfm.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace asseco_pfm.Controllers
{
    [ApiController]
    [Route("categories")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        [Route("import")]
        public IActionResult ImportCategories(IFormFile file)
        {

            _categoryService.ImportFile(file);

            return Ok("Imported");
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var result = await _categoryService.GetAllCategories();
            if (result == null)
                return BadRequest(result);
           
            return Ok(result);
        }
       
    }
}
