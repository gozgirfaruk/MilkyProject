using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Experimental.ProjectCache;
using MilkyProject.WebUI.DTOS.TeamDto;
using Newtonsoft.Json;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace MilkyProject.WebUI.Controllers
{
    public class TeamController : Controller
    {
       private readonly IHttpClientFactory _httpClientFactory;

        public TeamController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> TeamList()
        {
            var client = _httpClientFactory.CreateClient();
            var result = await client.GetAsync("https://localhost:7237/api/TeamApi");
            if (result.IsSuccessStatusCode)
            {
                var jsonData = await result.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<MilkyProject.WebUI.DTOS.TeamDto.ResultTeamDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        public IActionResult CreateTeam()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateTeam(CreateTeamDto createTeamDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createTeamDto);
            StringContent content = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var result = await client.PostAsync("https://localhost:7237/api/TeamApi", content);
            if(result.IsSuccessStatusCode)
            {
                return RedirectToAction("TeamList");
            }
            return View();
        }

        public async Task<IActionResult> DeleteTeam(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var result = await client.DeleteAsync("https://localhost:7237/api/TeamApi?id=" + id);
            if (result.IsSuccessStatusCode) { return RedirectToAction("TeamLsit"); }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateTeam(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var result = await client.GetAsync("https://localhost:7237/api/TeamApi/GetTeam?id="+id);
            if (result.IsSuccessStatusCode)
            {
                var jsonData = await result.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateTeamDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateTeam(UpdateTeamDto updateTeamDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateTeamDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8,"applicaton/json");
            var result = await client.PutAsync("https://localhost:7237/api/TeamApi", content);
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("TeamList");
            }
            return View();
        }
     
    }
}
