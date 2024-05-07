using Microsoft.AspNetCore.Mvc;

namespace MilkyProject.WebUI.ViewComponents._LayoutPartialComponent
{
    public class _NewsLetterPartialComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _NewsLetterPartialComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
