using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkyProject.BusinessLayer.Abstract;
using MilkyProject.EntityLayer.Concrete;

namespace MilkyProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactApiController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactApiController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public IActionResult ContactList()
        {
            var values = _contactService.TGetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult InsertContact(Contact contact)
        {
            _contactService.TInsert(contact);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteContact(int id)
        {
            var values = _contactService.TGetByID(id);
            _contactService.TDelete(values);
            return Ok();
        }
        [HttpGet("GetContact")]
        public IActionResult GetContact(int id)
        {
            var values = _contactService.TGetByID(id);
            return Ok(values);
        }
        [HttpPut]
        public IActionResult UpdateContact(Contact contact)
        {
            _contactService.TUpdate(contact);
            return Ok();
        }
    }
}
