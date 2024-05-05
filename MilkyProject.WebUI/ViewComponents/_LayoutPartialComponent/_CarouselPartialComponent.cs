using Microsoft.AspNetCore.Mvc;
using MilkyProject.BusinessLayer.Abstract;

namespace MilkyProject.WebUI.ViewComponents._LayoutPartialComponent
{
    public class _CarouselPartialComponent : ViewComponent
    {
        private readonly ICarouselService _carouselService;

        public _CarouselPartialComponent(ICarouselService carouselService)
        {
            _carouselService = carouselService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _carouselService.TGetAll();
            return View(values);
        }
    }
}
