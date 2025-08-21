using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampi.WebArayuz.ViewComponents
{
    public class _HeadDefaultCompanentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
