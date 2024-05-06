using Microsoft.AspNetCore.Mvc;
using MilkyProject.WebUI.DTOS.AboutDto;
using Newtonsoft.Json;

namespace MilkyProject.WebUI.ViewComponents._LayoutPartialComponent
{
    public class _AboutPartialComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AboutPartialComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var result = await client.GetAsync("https://localhost:7237/api/AboutApi");
            if(result.IsSuccessStatusCode)
            {
                var jsonData = await result.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
