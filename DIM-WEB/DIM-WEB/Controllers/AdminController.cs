using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DIM_WEB.Models;
using DIM_WEB.Managers;

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

        public ActionResult Campania()
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
        public JsonResult ValidarAdmin(string email, string password)
        {

            string respuesta = null;
            int? usuarioID = null;
            string usuarioNombre = null;
            string usuarioApellido = null;
    
            DimEntidades entidades = new DimEntidades();
            List<Usuarios> usuarios = entidades.Usuarios.Where(x => x.Email == email && x.TipoUsuario == "ADM").ToList();
            if (usuarios.Count > 0)
            {
                foreach (Usuarios usuario in usuarios)
                {

                    if (respuesta != "OK")
                    {
                        string passwordDesencritado = SecurityManager.DesencriptarTexto(usuario.Password);
                        if (passwordDesencritado == password) { 
                            respuesta = "OK";
                            usuarioID = usuario.UsuarioID;
                            usuarioApellido = usuario.Apellido;
                            usuarioNombre = usuario.Nombre;
                        }
                        else
                            respuesta = "Credenciales incorrectas";
                    }
                }
            }
            else
                respuesta = "Credenciales incorrectas";

            return Json(new { Respuesta = respuesta, UsuarioID = usuarioID, UsuarioNombre = usuarioNombre, UsuarioApellido = usuarioApellido });
        }

        [HttpPost]
        public JsonResult CampaniaAlta(string nombre, int cuposDisponibles, int descripcion, Int16 tipo, string contacto, string usuarioID, List<string> razasPermitidas,
            string calle, int numero, Int16 piso, string departamento, string localidad, string provincia)
        {


            return Json(new { Respuesta = "OK" });
        }
    }
}