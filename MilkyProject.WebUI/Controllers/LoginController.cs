using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MilkyProject.DTOLayer.AuthDto;
using MilkyProject.EntityLayer.Concrete;
using Newtonsoft.Json;
using System.Security.Claims;

namespace MilkyProject.WebUI.Controllers
{
    [AllowAnonymous]
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
        public async Task<IActionResult> Index (AdminLoginDto adminLoginDto)
        {
            var client = _httpClientFactory.CreateClient();
            var result = await client.GetAsync("https://localhost:7237/api/AdminApi");
            if(result.IsSuccessStatusCode)
            {
                var jsonData = await result.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<AdminLoginDto>>(jsonData);
              
                foreach (var adminLogin in values)
                {
                    if(adminLogin.Email == adminLoginDto.Email && adminLogin.Password == adminLoginDto.Password)
                    {
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Email, adminLogin.Email)
                        };
                        var useridentity = new ClaimsIdentity(claims, "Login");
                        ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                        await HttpContext.SignInAsync(principal);
                        return RedirectToAction("Index", "Product");
                    }

                }
            }
            return View();
        }


        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");
        }
    }
}
