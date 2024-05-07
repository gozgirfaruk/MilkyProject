using Microsoft.AspNetCore.Mvc;
using MilkyProject.DTOLayer.AuthDto;
using Newtonsoft.Json;
using System.Text;

namespace MilkyProject.WebUI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RegisterController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(AdminRegisterDto adminRegisterDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(adminRegisterDto);
            StringContent content = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var result = await client.PostAsync("https://localhost:7237/api/AdminResgisterApi/Register", content);
            if(result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index","Login");
            }
            return View();
        }
    }
}
