using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class MedioController : Controller
    {
        [HttpGet]
       public IActionResult GetAll()
        {
            return View();
        }


        public JsonResult MedioGetById(int idMedio)
        {
            ML.Result result = BL.Medio.GetById(idMedio);

            return Json(result);
        }
    }
}
