using Microsoft.AspNetCore.Mvc;
using MilkyProject.WebUI.Models;
using Newtonsoft.Json;
using System.Text;

namespace MilkyProject.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public LoginController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(AdminLoginViewModel loginViewModel)
        {
            var client = _httpClientFactory.CreateClient();
            var read = JsonConvert.SerializeObject(loginViewModel);
            var content = new StringContent(read, Encoding.UTF8,"application/json");
            var result = await client.PostAsync("", content);
            return View(result);
        }
    }
}
