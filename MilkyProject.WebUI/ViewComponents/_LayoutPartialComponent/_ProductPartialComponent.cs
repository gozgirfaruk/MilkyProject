using Microsoft.AspNetCore.Mvc;

namespace MilkyProject.WebUI.ViewComponents._LayoutPartialComponent
{
    public class _ProductPartialComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
