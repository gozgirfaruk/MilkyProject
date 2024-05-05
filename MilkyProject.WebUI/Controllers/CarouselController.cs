using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MilkyProject.WebUI.Controllers
{
    public class CarouselController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CarouselController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> CarouselList()
        {
            var client =_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7237/api/CarouselApi");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<MilkyProject.WebUI.DTOS.CarouselDto.ResultCarouselDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
