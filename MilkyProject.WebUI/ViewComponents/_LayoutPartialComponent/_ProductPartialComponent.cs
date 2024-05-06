using Microsoft.AspNetCore.Mvc;
using MilkyProject.WebUI.DTOS;
using MilkyProject.WebUI.DTOS.ProductDto;
using Newtonsoft.Json;

namespace MilkyProject.WebUI.ViewComponents._LayoutPartialComponent
{
    public class _ProductPartialComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _ProductPartialComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var result = await client.GetAsync("https://localhost:7237/api/Product");
            if(result.IsSuccessStatusCode)
            {
                var jsonData = await result.Content.ReadAsStringAsync();    
                var values = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(jsonData);
                return View(values.Take(4).ToList());
            }
            return View();
        }
    }
}
