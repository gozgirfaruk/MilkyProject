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
        public IActionResult Profile()
        {
            var values = _adminService.TGetAll();
            return Ok(values);
        }
        [HttpGet("Details")]
        public IActionResult Details(int id)
        {

            var values = _adminService.TGetByID(id);
            return Ok(values);
        }

        [HttpPost]
        public IActionResult  InsertAdmin(Admin admin)
        {
            _adminService.TInsert(admin);
            return Ok(admin);
        }
    }
}
