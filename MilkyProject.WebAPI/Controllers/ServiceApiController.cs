using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkyProject.BusinessLayer.Abstract;
using MilkyProject.EntityLayer.Concrete;

namespace MilkyProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceApiController : ControllerBase
    {
        private readonly IServiceService _serviceService;

        public ServiceApiController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [HttpGet]
        public IActionResult GetServiceList()
        {
            var values = _serviceService.TGetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult InsertService(Service service)
        {
            _serviceService.TInsert(service);
            return Ok("Başarılı bir şekilde ekleme işlemi tamamlandı.");
        }
        [HttpDelete]
        public IActionResult DeleteService(int id)
        {
            var values = _serviceService.TGetByID(id);
            _serviceService.TDelete(values);
            return Ok("Silme işlemi başarı ile uygulandı.");
        }
        [HttpGet("GetIdService")]
        public IActionResult GetIdService(int id)
        {
            var values = _serviceService.TGetByID(id);
            return Ok(values);
        }
        [HttpPut]
        public IActionResult UpdateService(Service service)
        {
            _serviceService.TUpdate(service);
            return Ok("Güncelleme işlemi başarı ile tamamlanıd.");
        }
    }
}
