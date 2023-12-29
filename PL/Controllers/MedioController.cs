using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class MedioController : Controller
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            ML.Result result = BL.Medio.GetAll();
            ML.Medio medio = new ML.Medio();
            medio.TipoMedio = new ML.TipoMedio();
            medio.Editorial = new ML.Editorial();
            medio.Idioma = new ML.Idioma();
            medio.Genero = new ML.Genero();
            medio.Autor = new ML.Autor();


            medio.Medios = new List<object>();

            medio.Medios = result.Objects;

            return View(medio);
        }



        public JsonResult MedioGetById(int idMedio)
        {

            ML.Result result = BL.Medio.GetById(idMedio);

            return Json(result);

        }

    }
}
