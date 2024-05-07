using Microsoft.AspNetCore.Mvc;

namespace MilkyProject.WebUI.Controllers
{
    public class GalleryWebController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
