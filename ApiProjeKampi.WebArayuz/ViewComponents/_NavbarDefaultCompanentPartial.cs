using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampi.WebArayuz.ViewComponents
{
    public class _NavbarDefaultCompanentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
