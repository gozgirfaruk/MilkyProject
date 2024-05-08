using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkyProject.BusinessLayer.Abstract;

namespace MilkyProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly ITestimonialService _testimonialService;

        public StatisticController(ICategoryService categoryService, IProductService productService, ITestimonialService testimonialService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _testimonialService = testimonialService;
        }

        [HttpGet]
        public IActionResult CategoryCount()
        {
            return Ok(_categoryService.TGetCategoryCount());
        }

        [HttpGet("GetProductCount")]
        public IActionResult GetProductCount()
        {
            return Ok(_productService.GetProductCount());
        }

        [HttpGet("GetTestCount")]
        public IActionResult GetTestCount()
        {
            return Ok(_testimonialService.GetTestCount());
        }

    }
}
