using Microsoft.AspNetCore.Mvc;
using MilkyProject.WebUI.DTOS.AddressDto;
using MilkyProject.WebUI.DTOS.ContactDto;
using Newtonsoft.Json;

namespace MilkyProject.WebUI.ViewComponents._LayoutPartialComponent
{
    public class _ContactPageDetailPartialComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _ContactPageDetailPartialComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var result = await client.GetAsync("https://localhost:7237/api/AddressApi");
            if(result.IsSuccessStatusCode)
            {
                var jsonData = await result.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAddressDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
