using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class AutorController : Controller
    {
        public IActionResult GetAll()
        {
            ML.Autor autor = new ML.Autor();
            ML.Result result = BL.Autor.GetAll();

           if (result.Correct)
            {
                autor.Autores = result.Objects;
                return View(autor);
            }
            else
            {
                return View();
            }
        }
        
        //[HttpGet]
        //public IActionResult Form(int? idAutor)
        //{
        //    ML.Autor autor = new ML.Autor();

        //    if (idAutor == null)
        //    {
        //        ViewBag.Titulo = "Registro";
        //        return View(autor);
        //    }
        //    else
        //    {
        //        ML.Result result = BL.Autor.GetById(idAutor.Value);

        //        if (result.Correct)
        //        {
        //            autor = (ML.Autor)result.Object;

        //            ViewBag.Titulo = "Actualizar";
        //            return View(autor);
        //        }
        //        else
        //        {
        //            ViewBag.Titulo = "Erro";
        //            ViewBag.Message = result.Message; 
        //            return View("Modal");
        //        }
        //    }
        //}

        [HttpPost]
        public JsonResult GetById(int idAutor)
        {
            ML.Result result = BL.Autor.GetById(idAutor);

            return Json(result);
        }

        [HttpPost]
        public JsonResult Add(ML.Autor autor)
        {
            ML.Result result = BL.Autor.Add(autor);

            return Json(result);
        }

        [HttpPut]
        public JsonResult Update(ML.Autor autor)
        {
            ML.Result result = BL.Autor.Update(autor);

            return Json(result);
        }

        [HttpDelete]
        public JsonResult Delete(int idAutor)
        {
            ML.Result result = BL.Autor.Delete(idAutor);

            return Json(result);
        }
    }
}
