using Aya.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Aya.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        private readonly ILogger<CategoryController> _logger;

        public CategoryController(ILogger<CategoryController> logger, ICategoryService categoryService)
        {
            _logger = logger;
            _categoryService = categoryService;
        }

        [HttpGet("detail/{id}")]
        public async Task<IActionResult> Detail([FromRoute] Guid? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var result = await _categoryService.FindByIdAsync(id.Value);
            return Ok(result);
        }
    }
}