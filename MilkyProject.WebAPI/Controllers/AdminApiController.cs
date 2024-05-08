using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkyProject.BusinessLayer.Abstract;
using MilkyProject.EntityLayer.Concrete;

namespace MilkyProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminApiController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminApiController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet]
        public IActionResult AdminList()
        {
            var values = _adminService.TGetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult InsertAdmin(Admin admin)
        {
            _adminService.TInsert(admin);
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteAdmin(int id) 
        {
           var values = _adminService.TGetByID(id);
            _adminService.TDelete(values);
            return Ok();
        }
        [HttpGet("GetAdmin")]
        public IActionResult GetAdmin(int id)
        {
            var values = _adminService.TGetByID(id);
            return Ok(values);
        }

        [HttpPut]
        public IActionResult    UpdateAdmin(Admin admin)
        {
            _adminService.TUpdate(admin);
            return Ok();
        }
    }
}
