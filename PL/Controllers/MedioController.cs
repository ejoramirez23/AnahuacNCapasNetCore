using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class MedioController : Controller
    {
       public IActionResult GetAll()
        {
            return View();
        }
    }
}
