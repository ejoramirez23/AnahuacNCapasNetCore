using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class ClientePrestamoController : Controller
    {
        [HttpGet]
        public JsonResult GetAll()
        {
            ML.Result result = BL.Prestamo.GetAll();
            ML.Result resultMedio = BL.Medio.GetAll();
            ML.Result resultUsuario = BL.UserIdentity.GetAll();
            ML.Prestamo prestamo = new ML.Prestamo();

            prestamo.Medio = new ML.Medio();
            prestamo.Usuario = new ML.Usuario();

            if (result.Correct)
            {
                prestamo.Prestamos = result.Objects;
                prestamo.Medio.Medios = resultMedio.Objects;
                prestamo.Usuario.Usuarios = resultUsuario.Objects;

                ML.Prestamo resulJson = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Prestamo>(result.ToString());
                return Json(result);
            }
            else
            {
                return Json(result.Message);
            }
            
        }
               
    }
}
