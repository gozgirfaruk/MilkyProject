using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using MilkyProject.BusinessLayer.Abstract;
using MilkyProject.EntityLayer.Concrete;

namespace MilkyProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialApiController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;

        public TestimonialApiController(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        [HttpGet]
        public IActionResult GetTestList()
        {
            var values = _testimonialService.TGetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult InsertTest(Testimonial testimonial)
        {
            _testimonialService.TInsert(testimonial);
            return Ok();    
        }
        [HttpDelete]
        public IActionResult DeleteTest(int id)
        {
            var values = _testimonialService.TGetByID(id);
            _testimonialService.TDelete(values);
            return Ok();
        }

        [HttpGet("GetTest")]
        public IActionResult GetTest(int id)
        {
            var values = _testimonialService.TGetByID(id);
            return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateTest(Testimonial testimonial)
        {
            _testimonialService.TUpdate(testimonial);
            return Ok();
        }
    }
}
