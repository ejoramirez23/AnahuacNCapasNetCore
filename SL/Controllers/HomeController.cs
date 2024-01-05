using Microsoft.AspNetCore.Mvc;

namespace SL.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
