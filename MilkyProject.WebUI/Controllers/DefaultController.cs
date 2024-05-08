using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MilkyProject.BusinessLayer.Abstract;
using MilkyProject.WebUI.DTOS.NewLetterDto;
using Newtonsoft.Json;
using System.Text;

namespace MilkyProject.WebUI.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }

       
    }
}
