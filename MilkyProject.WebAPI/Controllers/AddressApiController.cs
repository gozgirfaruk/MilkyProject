using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkyProject.BusinessLayer.Abstract;
using MilkyProject.EntityLayer.Concrete;

namespace MilkyProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressApiController : ControllerBase
    {
        private IAddressService _addressService;

        public AddressApiController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet]
        public IActionResult AddressList()
        {
            var values = _addressService.TGetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult InsertAddress(Address address)
        {
            _addressService.TInsert(address);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteAddress(int id)
        {
            var values = _addressService.TGetByID(id);
            _addressService.TDelete(values);
            return Ok();
        }
        [HttpGet("GetAddress")]
        public IActionResult GetAddress(int id)
        {
            var values = _addressService.TGetByID(id);
            return Ok(values);
        }
        [HttpPut]
        public IActionResult UpdateAddress(Address address)
        {
            _addressService.TUpdate(address);
            return Ok();
        }
    }
}
