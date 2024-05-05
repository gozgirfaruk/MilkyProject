using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkyProject.BusinessLayer.Abstract;
using MilkyProject.EntityLayer.Concrete;

namespace MilkyProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureApiController : ControllerBase
    {
        private readonly IFeatureService _featureService;

        public FeatureApiController(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        [HttpGet]
        public IActionResult FeatureList()
        {
            var values = _featureService.TGetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateFeature(Feature feature)
        {
            _featureService.TInsert(feature);
            return Ok("Başarılı bir şekilde eklendir");
        }
        [HttpDelete]
        public IActionResult DeleteFeature(int id)
        {
            var values = _featureService.TGetByID(id);
            _featureService.TDelete(values);
            return Ok("Başarılı bir şekilde kaldırıldır.");
        }

        [HttpGet("GetFeature")]
        public IActionResult GetFeature(int id)
        {
            var values = _featureService.TGetByID(id);
            return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateFeature(Feature feature)
        {
            _featureService.TUpdate(feature);
            return Ok("Başarılı bir şekilde güncellendi.");
        }
    }
}
