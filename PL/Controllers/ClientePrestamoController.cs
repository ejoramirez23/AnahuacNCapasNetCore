﻿using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class ClientePrestamoController : Controller
    {


        [HttpGet]
        public IActionResult GetAll()
        {
            return View();
        }

        [HttpGet]
        public JsonResult PrestamoGetAll()
        {
            ML.Result result = BL.Prestamo.GetAll();

            return Json(result);
        }



    }
}
