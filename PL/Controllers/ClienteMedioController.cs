using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class ClienteMedioController : Controller
    {

        [HttpGet]
        public IActionResult GetAll()
        {
            return View();
        }

        [HttpGet]
        public JsonResult MedioGetAll()
        {
            ML.Result result = BL.Medio.GetAll();

            return Json(result);
        }
    }
}
