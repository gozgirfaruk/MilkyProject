using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkyProject.BusinessLayer.Abstract;
using MilkyProject.EntityLayer.Concrete;

namespace MilkyProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarouselApiController : ControllerBase
    {
        private readonly ICarouselService _carouselService;

        public CarouselApiController(ICarouselService carouselService)
        {
            _carouselService = carouselService;
        }
        [HttpGet]
        public IActionResult CarouselList()
        {
            var values = _carouselService.TGetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateCarousel(Carousel carousel)
        {
            _carouselService.TInsert(carousel);
            return Ok("Başarılı bir şekilde eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteCarousel(int id)
        {
            var values = _carouselService.TGetByID(id);
            _carouselService.TDelete(values);
            return Ok("Başarılı bir şekilde kaldırıldı.");
        }

        [HttpGet("GetCarousel")]
        public IActionResult GetCarousel(int id)
        {
            var values = _carouselService.TGetByID(id);
            return Ok(values);
        }
        [HttpPut]
        public IActionResult UpdateCarousel(Carousel carousel)
        {
            _carouselService.TUpdate(carousel);
            return Ok();
        }
    }
}
