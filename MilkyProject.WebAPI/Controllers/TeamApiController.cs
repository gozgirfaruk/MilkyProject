using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkyProject.BusinessLayer.Abstract;
using MilkyProject.EntityLayer.Concrete;

namespace MilkyProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamApiController : ControllerBase
    {
        private readonly ITeamService _teamService;

        public TeamApiController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpGet]
        public IActionResult TeamList()
        {
            var values = _teamService.TGetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult InsertTeam(Team team)
        {
            _teamService.TInsert(team);
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteTeam(int id)
        {
            var values = _teamService.TGetByID(id);
            _teamService.TDelete(values);
            return Ok();
        }
        [HttpGet("GetTeam")]
        public IActionResult GetTeam(int id)
        {
            var values = _teamService.TGetByID(id);
            return Ok(values);
        }
        [HttpPut]
        public IActionResult UpdateTeam(Team team)
        {
            _teamService.TUpdate(team);
            return Ok();
        }
    }
}
