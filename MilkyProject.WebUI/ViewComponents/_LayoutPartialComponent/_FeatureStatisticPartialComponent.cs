using Microsoft.AspNetCore.Mvc;
using MilkyProject.BusinessLayer.Abstract;
using MilkyProject.BusinessLayer.Concrete;
using MilkyProject.DataAccessLayer.Abstract;
using MilkyProject.DataAccessLayer.EntityFramework;

namespace MilkyProject.WebUI.ViewComponents._LayoutPartialComponent
{
    public class _FeatureStatisticPartialComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _FeatureStatisticPartialComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var result = await client.GetAsync("https://localhost:7237/api/Statistic/GetProductCount");
           var jsonData = await result.Content.ReadAsStringAsync();
            ViewBag.a = jsonData;


            var deneme = await client.GetAsync("https://localhost:7237/api/Statistic");
            var deneme1 = await deneme.Content.ReadAsStringAsync();
            ViewBag.b = deneme1;

            var testcount = await client.GetAsync("https://localhost:7237/api/Statistic/GetTestCount");
            var testjson= await testcount.Content.ReadAsStringAsync();
            ViewBag.c = testjson;
            return View();
        }
    }
}
