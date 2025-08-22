using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampi.WebArayuz.ViewComponents
{
    public class _AboutDefaultCompanentPartial : ViewComponent

    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
