using Microsoft.AspNetCore.Mvc;
using MilkyProject.WebUI.DTOS.TestimonialDto;
using Newtonsoft.Json;
using System.Reflection.Metadata.Ecma335;

namespace MilkyProject.WebUI.Controllers
{
    public class TestimonialController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TestimonialController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> TestList()
        {
            var client = _httpClientFactory.CreateClient();
            var result =await client.GetAsync("https://localhost:7237/api/TestimonialApi");
            if (result.IsSuccessStatusCode)
            {
                var jsonData = await result.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultTestimonialDto>>(jsonData);
                return View(values);
             
            }
            return View();
        }


    }
}
