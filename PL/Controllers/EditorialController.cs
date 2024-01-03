using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class EditorialController : Controller
    {


        [HttpGet]
        public IActionResult GetAll()
        {
            ML.Result result = BL.Editorial.GetAll();
            ML.Editorial editorial = new ML.Editorial();
         

            editorial.Editoriales = new List<object>();

            editorial.Editoriales = result.Objects;


            return View(editorial);
        }



        public JsonResult EditorialGetById(int idEditorial)
        {

            ML.Result result = BL.Editorial.GetById(idEditorial);

            return Json(result);

        }


         public JsonResult EditorialAdd(ML.Editorial editorial)
        {

            ML.Result result = BL.Editorial.Add(editorial);

            return Json(result);

        }
        
        
        public JsonResult EditorialUpdate(ML.Editorial editorial)
        {

            ML.Result result = BL.Editorial.Update(editorial);

            return Json(result);

        }






    }
}
