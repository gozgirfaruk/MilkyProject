using Microsoft.AspNetCore.Mvc;
using MilkyProject.WebUI.DTOS.GalleryDto;
using Newtonsoft.Json;
using System.Text;

namespace MilkyProject.WebUI.Controllers
{
    public class GalleryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public GalleryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> GalleryList()
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


        [HttpDelete]
        public async Task<IActionResult> DeleteGallery(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var result = await client.GetAsync("https://localhost:7237/api/GalleryApi?id="+id);
            if(result.IsSuccessStatusCode)
            {
                return RedirectToAction("GalleryList");
            }
            return View();
        }

        public IActionResult CreateGallery()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateGallery(CreateGalleryDto createGallery)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createGallery);
            StringContent content = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var result = await client.PostAsync("https://localhost:7237/api/GalleryApi", content);
            if(result.IsSuccessStatusCode)
            {
                return RedirectToAction("GalleryList");
            }
            return View();

        }
    }
}
