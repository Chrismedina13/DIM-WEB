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
           
                    DimEntidades2 entidades = new DimEntidades2();
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
        public JsonResult CampaniaAlta(string nombre, int cuposDisponibles, string descripcion, Int16 tipo, string contacto, string usuarioID, List<string> razasPermitidas,
            string calle, int numero, Int16 piso, string departamento, string localidad, string provincia)
        {
            string resultado = null;
            long idCampania;
            long idDireccion;
            resultado = ValidarCampania(nombre,cuposDisponibles, descripcion,tipo, contacto, usuarioID, razasPermitidas);
            if (resultado == null) {
                resultado = ValidarDireccionCampania(calle, numero, localidad);
                
                if (resultado == null) {

                    DimEntidades2 context = new DimEntidades2();
                    var campanias = context.Campania.ToList();
                    var direcciones = context.Direccion.ToList();
                    if (campanias.Count == 0)
                        idCampania = 1;
                    else { 
                        idCampania = campanias.Max(x => x.CampaniaID) + 1;                          
                    }

                    if (direcciones.Count == 0)
                        idDireccion = 1;
                    else
                    {
                        idDireccion = direcciones.Max(x => x.DireccionID) + 1;
                    }

                    Campania campaniaAGuardar = new Campania();
                    campaniaAGuardar.CampaniaID = idCampania;
                    campaniaAGuardar.CuposDisponibles = cuposDisponibles;
                    campaniaAGuardar.FechaCreacion = DateTime.Now;
                    campaniaAGuardar.Descripcion = descripcion;
                    campaniaAGuardar.Tipo = tipo;
                    campaniaAGuardar.Nombre = nombre;
                    campaniaAGuardar.Contacto = contacto;
                    campaniaAGuardar.UsuarioID = Convert.ToInt32(usuarioID);
                    foreach (var raza in razasPermitidas) {
                        campaniaAGuardar.Raza.Add(ObtenerObjetoRaza(context.Raza.ToList(), raza));
                    }

                    Direccion direccion = new Direccion();
                    direccion.Calle = calle;
                    direccion.Numero = numero;
                    direccion.DireccionID = idDireccion;
                    direccion.Piso = piso;
                    direccion.Departamento = departamento;
                    direccion.Localidad = localidad;
                    direccion.Provincia = provincia;
                    direccion.MascotaID = null;
                    direccion.CampaniaID = idCampania;
                    direccion.UsuarioID = null;

                    context.Campania.Add(campaniaAGuardar);
                    context.Direccion.Add(direccion);
                    context.SaveChanges();
                    resultado = "OK";
                
                }
            }

            return Json(new { Respuesta = resultado });
        }




        #region Utils
        private Raza ObtenerObjetoRaza(List<Raza> razasDeLaBase, string raza)
        {
            Raza resultado = razasDeLaBase.Find(x => x.Descripcion == raza );
            return resultado;
        }

        private string ValidarDireccionCampania(string calle, int numero, string localidad)
        {
            string resultado = null;
            if (calle == null)
                resultado = "Debe ingresar una calle";
            if (resultado == null && numero <= 0)
                resultado = "Debe ingresar un número de calle mayor a 0";
            if (resultado == null && localidad == null)
                resultado = "Debe ingresar una localidad";

            return resultado;

        }

        private string ValidarCampania(string nombre, int cuposDisponibles, string descripcion, short tipo, string contacto, string usuarioID, List<string> razasPermitidas)
        {
            string resultado = null;
            if (nombre == null)
                resultado = "Debe ingresar un nombre a la campania";
            if (resultado == null && cuposDisponibles <= 0)
                resultado = "Debe ingresar la cantidad de cupos disponibles";
            if (resultado == null && tipo != 1 && tipo != 2 && tipo != 3)
                resultado = "Tipo de campania desconocido";
            if (resultado == null && contacto == null)
                resultado = "Debe ingresar un contacto";
            if (resultado == null && razasPermitidas.Count <= 0)
                resultado = "Debe ingresar alguna raza permitida";

            return resultado;
        }

        [HttpPost]
        public JsonResult ObtenerRazasDeEspecie(string especie)
        {
            DimEntidades2 entidades = new DimEntidades2();
            List<String> resultado = new List<string>();

            List<Raza> razas = entidades.Raza.Where(x => x.EspecieID == especie).ToList();
            if (razas.Count > 0) {
                resultado = razas.Select(x => x.Descripcion).ToList();
            }

            return Json(new { Respuesta = resultado });
        }

        #endregion
    }
}