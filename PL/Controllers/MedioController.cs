﻿using Microsoft.AspNetCore.Http;
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




        [HttpGet]
        public IActionResult Form(int idMedio)
        {


            ML.Medio medio = new ML.Medio();

            medio.Autor = new ML.Autor();
            medio.Genero = new ML.Genero();
            medio.Idioma = new ML.Idioma();
            medio.Editorial = new ML.Editorial();
            medio.TipoMedio = new ML.TipoMedio();

            ML.Result resultAutores = BL.Autor.GetAll();
            medio.Autor.Autores = resultAutores.Objects;

            ML.Result resultGeneros = BL.Genero.GetAll();
            medio.Genero.Generos = resultGeneros.Objects;

            ML.Result resultIdiomas = BL.Idioma.GetAll();
            medio.Idioma.Idiomas = resultIdiomas.Objects;

            ML.Result resultEditoriales = BL.Editorial.GetAll();
            medio.Editorial.Editoriales = resultEditoriales.Objects;

            ML.Result resultTipoMedios = BL.TipoMedio.GetAll();
            medio.TipoMedio.TipoMedios = resultTipoMedios.Objects;



            if (idMedio == 0)
            {

                @ViewBag.Accion = "Agregar";

            }
            else
            {

                ML.Result result = BL.Medio.GetById(idMedio);

                medio = (ML.Medio)result.Object;

                medio.Autor.Autores = resultAutores.Objects;
                medio.Genero.Generos = resultGeneros.Objects;
                medio.Idioma.Idiomas = resultIdiomas.Objects;
                medio.Editorial.Editoriales = resultEditoriales.Objects;
                medio.TipoMedio.TipoMedios = resultTipoMedios.Objects;

                @ViewBag.Accion = "Actualizar";
            }

            return View(medio);
        }




        public JsonResult MedioGetById(int idMedio)
        {

            ML.Result result = BL.Medio.GetById(idMedio);

            return Json(result);

        }


        [HttpPost]

        public IActionResult MedioGetAll()
        {
            ML.Result result = BL.Medio.GetAll(); 
            return Json(result);
        }



        [HttpPost]

        public JsonResult GeneroGetAll()
        {
            ML. Result result = BL.Genero.GetAll();  

            return Json(result);
        }
        
        
        [HttpPost]

        public JsonResult AutorGetAll()
        {
            ML. Result result = BL.Autor.GetAll();  

            return Json(result);
        }
          
        
        public JsonResult EditorialGetAll()
        {
            ML. Result result = BL.Editorial.GetAll();  

            return Json(result);
        }  
        
        
        
        public JsonResult IdiomaGetAll()
        {
            ML. Result result = BL.Idioma.GetAll();  

            return Json(result);
        }

        
        public JsonResult AddMedio(ML.Editorial editorial)
        {
            
            //if (Request.Form.Files.Count > 0)
            //{
            //    IFormFile image = Request.Form.Files[0];
               
            //}

           

            //ML. Result result = BL.Medio.Add(medio);      

            return Json("");
        }









        [HttpPost]
        public IActionResult Form(ML.Medio medio)
        {

            IFormFile image = Request.Form.Files["FuImagen"];

            if (image != null)
            {
                byte[] ImagenBytes = convertFileToByteArray(image);
                medio.Imagen = Convert.ToBase64String(ImagenBytes);
            }




            if (medio.IdMedio == 0)
            {
                ML.Result result = BL.Medio.Add(medio);
                @ViewBag.Message = result.Message;

                return View("Modal");
            }
            else
            {
                ML.Result result = BL.Medio.Update(medio);
                @ViewBag.Message = result.Message;
                return View("Modal");
            }

            

            

        }


        public byte[] convertFileToByteArray(IFormFile Imagen)
        {

            MemoryStream target = new MemoryStream();
            Imagen.CopyTo(target);
            byte[] data = target.ToArray();

            return data;
        }

    }
}
