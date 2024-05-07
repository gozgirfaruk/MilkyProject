using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MilkyProject.DTOLayer.AuthDto;
using MilkyProject.EntityLayer.Concrete;
using MilkyProject.WebUI.Models;
using Newtonsoft.Json;
using System.Text;

namespace MilkyProject.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public LoginController(IHttpClientFactory httpClientFactory, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _httpClientFactory = httpClientFactory;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(AdminLoginDto adminLogin)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(adminLogin);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var result = await client.PostAsync("https://localhost:7237/api/AdminResgisterApi/Login", content);
            if(result.IsSuccessStatusCode)
            {
                var user = await _userManager.FindByEmailAsync(adminLogin.Email);
                await _signInManager.PasswordSignInAsync(user,adminLogin.Password,false,false);
                return RedirectToAction("AboutList","About");
            }
            return View();

        }
    }
}
