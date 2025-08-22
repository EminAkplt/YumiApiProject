using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampi.WebArayuz.ViewComponents
{
    public class _FeatureDefaultCompanentPartial : ViewComponent

    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
