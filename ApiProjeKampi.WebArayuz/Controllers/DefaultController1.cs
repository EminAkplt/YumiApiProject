using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampi.WebArayuz.Controllers
{
    public class DefaultController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
