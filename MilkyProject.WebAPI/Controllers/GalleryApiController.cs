using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkyProject.BusinessLayer.Abstract;
using MilkyProject.EntityLayer.Concrete;

namespace MilkyProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GalleryApiController : ControllerBase
    {
        private readonly IGalleryService _galleryService;

        public GalleryApiController(IGalleryService galleryService)
        {
            _galleryService = galleryService;
        }

        [HttpGet]
        public IActionResult GalleryList()
        {
            var values = _galleryService.TGetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult InsertGallery(Gallery gallery)
        {
            _galleryService.TInsert(gallery);
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteGalery(int id)
        {
            var values = _galleryService.TGetByID(id);
            _galleryService.TDelete(values);
            return Ok();
        }
        [HttpGet("GetGallery")]
        public IActionResult GetGallery(int id)
        {
            var values = _galleryService.TGetByID(id);
            return Ok(values);
        }
        [HttpPut]
        public IActionResult UpdateGallery(Gallery gallery)
        {
            _galleryService.TUpdate(gallery);
            return Ok();
        }
    }
}
