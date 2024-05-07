using Microsoft.AspNetCore.Mvc;

namespace MilkyProject.WebUI.Controllers
{
    public class AboutUsWebController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
