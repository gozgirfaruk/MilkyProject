using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MilkyProject.DTOLayer.AuthDto;
using MilkyProject.EntityLayer.Concrete;

namespace MilkyProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminResgisterApiController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AdminResgisterApiController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(AdminRegisterDto adminRegister)
        {
            if (!ModelState.IsValid)
            {
                if (adminRegister.Password == adminRegister.ConfirmPassword)
                {
                    var user = new AppUser()
                    {
                        UserName = adminRegister.UserName,
                        Email = adminRegister.Email,
                        Name = adminRegister.Name,
                        Surname = adminRegister.Surname,

                    };
                    var newUser = await _userManager.CreateAsync(user, adminRegister.Password);
                    if (newUser.Succeeded)
                    {
                        return Ok("Kayıt edildi");

                    }
                    else
                    {
                        foreach (var item in newUser.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }
                        return BadRequest(newUser.Errors);
                    }
                }
            }
            return Ok();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(AdminLoginDto adminLogin)
        {
            var user = await _userManager.FindByEmailAsync(adminLogin.Email);
            var result = await _signInManager.PasswordSignInAsync(user.UserName, adminLogin.Password, false, false);
            if (result.Succeeded)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }

        }

    }
}
