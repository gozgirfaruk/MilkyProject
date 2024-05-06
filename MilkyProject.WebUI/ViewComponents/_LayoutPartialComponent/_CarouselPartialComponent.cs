using Microsoft.AspNetCore.Mvc;
using MilkyProject.BusinessLayer.Abstract;
using MilkyProject.WebUI.DTOS.CarouselDto;
using Newtonsoft.Json;

namespace MilkyProject.WebUI.ViewComponents._LayoutPartialComponent
{
    public class _CarouselPartialComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _CarouselPartialComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var result = await client.GetAsync("https://localhost:7237/api/CarouselApi");
            if(result.IsSuccessStatusCode)
            {
                var jsonData = await result.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarouselDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
