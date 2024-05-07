using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkyProject.BusinessLayer.Abstract;
using MilkyProject.EntityLayer.Concrete;
using System.Runtime.CompilerServices;

namespace MilkyProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsLetterApiController : ControllerBase
    {
        private readonly ILetterService _letterService;

        public NewsLetterApiController(ILetterService letterService)
        {
            _letterService = letterService;
        }

        [HttpGet]
        public IActionResult LetterList()
        {
            var values = _letterService.TGetAll();
            return Ok(values);  
        }
        [HttpPost]
        public IActionResult InsertLetter(MailLetter letter)
        {
            _letterService.TInsert(letter);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteLetter(int id)
        {
            var values =_letterService.TGetByID(id);
            _letterService.TDelete(values);
            return Ok();
        }
        [HttpGet("GetLetter")]
        public IActionResult GetLetter(int id)
        {
            var values = _letterService.TGetByID(id);
            return Ok(values);
        }
        [HttpPut]
        public IActionResult UpdateLetter(MailLetter letter)
        {
            _letterService.TUpdate(letter);
            return Ok();
        }
    }
}
