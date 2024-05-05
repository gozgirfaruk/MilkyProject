using Microsoft.AspNetCore.Mvc;
using MilkyProject.EntityLayer.Concrete;
using MilkyProject.WebUI.DTOS.CarouselDto;
using Newtonsoft.Json;
using System.Text;

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
        [HttpDelete]
        public async Task<IActionResult> DeleteCarousel(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7237/api/CarouselApi?id=" + id);
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("CarouselList");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Insert()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Insert(CreateCarouselDto createCarouselDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData= JsonConvert.SerializeObject(createCarouselDto);
            StringContent content = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PostAsync("https://localhost:7237/api/CarouselApi", content);
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("CarouselList");
            }
            return View();
        }

        [HttpGet("UpdateCarousel")]
        public async Task<IActionResult> UpdateCarousel(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7237/api/CarouselApi/GetCarousel?id=" + id);
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultCarouselDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost("UpdateCarousel")]
        public async Task<IActionResult> UpdateCarousel(UpdateCarouselDto updateCarouselDto)
        {
            var client = _httpClientFactory.CreateClient(); 
            var jsonData = JsonConvert.SerializeObject(updateCarouselDto);
            StringContent content=new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PutAsync("https://localhost:7237/api/CarouselApi", content);
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("CarouselList");

            }
            return View();
        }


    }
}
