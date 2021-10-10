using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DIM_WEB.Controllers
{
    public class AdminController : Controller
    {
        // GET: admin
        public ActionResult Admin()
        {
            return View();
        }

        public ActionResult CampaniaAlta()
        {
            return View();
        }

        public ActionResult AdminHome()
        {
            return View();
        }

        public ActionResult Veterinaria()
        {
            return View();
        }
        
        [HttpPost]
        public JsonResult ValidarAdmin(string usuario, string password) {

            return Json(new { Respuesta = "OK" });
        }

    }
}