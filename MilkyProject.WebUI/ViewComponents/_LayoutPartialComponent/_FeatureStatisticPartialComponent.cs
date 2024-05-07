using Microsoft.AspNetCore.Mvc;
using MilkyProject.BusinessLayer.Abstract;
using MilkyProject.BusinessLayer.Concrete;
using MilkyProject.DataAccessLayer.Abstract;
using MilkyProject.DataAccessLayer.EntityFramework;

namespace MilkyProject.WebUI.ViewComponents._LayoutPartialComponent
{
    public class _FeatureStatisticPartialComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
           
            return View();
        }
    }
}
