using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MilkyProject.WebUI.Controllers
{
    [AllowAnonymous]
    public class ServiceWebController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
