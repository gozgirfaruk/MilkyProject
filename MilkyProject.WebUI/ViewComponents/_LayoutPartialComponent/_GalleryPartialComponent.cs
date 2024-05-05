using Microsoft.AspNetCore.Mvc;

namespace MilkyProject.WebUI.ViewComponents._LayoutPartialComponent
{
    public class _GalleryPartialComponent : ViewComponent
    {
       public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
