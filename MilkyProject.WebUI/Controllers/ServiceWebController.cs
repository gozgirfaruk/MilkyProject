using Microsoft.AspNetCore.Mvc;

namespace MilkyProject.WebUI.Controllers
{
    public class ServiceWebController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
