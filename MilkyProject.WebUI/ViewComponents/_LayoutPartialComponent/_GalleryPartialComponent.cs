using Microsoft.AspNetCore.Mvc;

namespace MilkyProject.WebUI.ViewComponents._LayoutPartialComponent
{
    public class _GalleryPartialComponent : ViewComponent
    {
        //private readonly IHttpClientFactory _httpClientFactory;

        //public _GalleryPartialComponent(IHttpClientFactory httpClientFactory)
        //{
        //    _httpClientFactory = httpClientFactory;
        //}

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
