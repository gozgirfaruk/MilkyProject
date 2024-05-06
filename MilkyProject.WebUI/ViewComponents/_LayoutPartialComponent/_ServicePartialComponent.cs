using Microsoft.AspNetCore.Mvc;
using MilkyProject.WebUI.DTOS.ServiceDto;
using Newtonsoft.Json;
using System.Reflection.Metadata.Ecma335;

namespace MilkyProject.WebUI.ViewComponents._LayoutPartialComponent
{
    public class _ServicePartialComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _ServicePartialComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var resutl = await client.GetAsync("https://localhost:7237/api/ServiceApi");
            if(resutl.IsSuccessStatusCode)
            {
                var jsonData = await resutl.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
