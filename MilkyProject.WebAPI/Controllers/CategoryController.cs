using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkyProject.BusinessLayer.Abstract;
using MilkyProject.EntityLayer.Concrete;

namespace MilkyProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult CategoryList()
        {
            var values = _categoryService.TGetAll();
            return Ok(values);
        }
        [HttpPost]  
        public IActionResult CreatedCategory(Category category)
        {
            _categoryService.TInsert(category);
            return Ok("Kategori Başarılı Bir Şekilde Eklendi.");
        }

        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            var values = _categoryService.TGetByID(id);
            _categoryService.TDelete(values);
            return Ok("Başarılı Bir Şekilde Silindi.");
        }
        [HttpPut]
        public IActionResult PutCategory(Category category)
        {
            _categoryService.TUpdate(category);
            return Ok("Kategori Başarılı Bir Şekilde Güncellendi.");
        }

        [HttpGet("GetCategory")]
        public IActionResult GetCategory(int id)
        {
            var values = _categoryService.TGetByID(id);
            return Ok(values);
        }
    }
}
