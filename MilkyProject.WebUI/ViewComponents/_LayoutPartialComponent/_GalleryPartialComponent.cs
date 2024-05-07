using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using MilkyProject.WebUI.DTOS.GalleryDto;
using Newtonsoft.Json;

namespace MilkyProject.WebUI.ViewComponents._LayoutPartialComponent
{
    public class _GalleryPartialComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _GalleryPartialComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var result =await client.GetAsync("https://localhost:7237/api/GalleryApi");
            if (result.IsSuccessStatusCode)
            {
                var jsonData = await result.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultGalleryDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
