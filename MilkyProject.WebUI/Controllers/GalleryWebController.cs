using Microsoft.AspNetCore.Mvc;
using MilkyProject.WebUI.DTOS.GalleryDto;
using Newtonsoft.Json;

namespace MilkyProject.WebUI.Controllers
{
    public class GalleryWebController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public GalleryWebController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var result = await client.GetAsync("https://localhost:7237/api/GalleryApi");
            if(result.IsSuccessStatusCode)
            {
                var jsonData = await result.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultGalleryDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
