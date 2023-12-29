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

        public JsonResult MedioGetAll()
        {
            ML.Result result = BL.Medio.GetAll();

            return Json(result);
        }

        public JsonResult MedioGetById(int idMedio)
        {
            ML.Result result = BL.Medio.GetById(idMedio);

            return Json(result);
        }

        public JsonResult MedioAdd(ML.Medio medio)
        {
            ML.Result result = BL.Medio.Add(medio);

            return Json(result);
        }


        public JsonResult MedioUpdate(ML.Medio medio)
        {
            ML.Result result = BL.Medio.Update(medio);

            return Json(result);
        }
        
    }
}
