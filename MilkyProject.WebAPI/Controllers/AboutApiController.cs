using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkyProject.BusinessLayer.Abstract;
using MilkyProject.EntityLayer.Concrete;

namespace MilkyProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutApiController : ControllerBase
    {
        private readonly IAboutService _aboutService;

        public AboutApiController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [HttpGet]
        public IActionResult AboutList()
        {
            var values  = _aboutService.TGetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult InsertAbout(About about)
        {
            _aboutService.TInsert(about);
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteAbout(int id)
        {
            var values = _aboutService.TGetByID(id);
            _aboutService.TDelete(values);
            return Ok();
        }
        [HttpGet("GetAbout")]
        public IActionResult GetAbout(int id)
        {
            var values = _aboutService.TGetByID(id);
                return Ok(values);
        }
        [HttpPut]
        public IActionResult UpdateAbout(About about)
        {
            _aboutService.TUpdate(about);
            return Ok();
        }
    }
}
