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

        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult MascotasPeligrosas()
        {
            MascotasPeligrosasModel model = new MascotasPeligrosasModel();
            DimEntidades2 context = new DimEntidades2();
            List<Raza> razasPeligrosas = context.Raza.Where(x => x.EsRazaPeligrosa == 1).ToList();
            List<Mascota> mascotas = context.Mascota.ToList();
            foreach (Mascota mascota in mascotas) {

                Raza raza = razasPeligrosas.Find(x => x.RazaID == mascota.RazaID);
                if (raza != null) {

                    MascotaPeligrosaModel mascotaPeligrosa = new MascotaPeligrosaModel();
                    mascotaPeligrosa.NombreDueño = mascota.Usuarios.Nombre;
                    mascotaPeligrosa.ApellidoDueño = mascota.Usuarios.Apellido;
                    mascotaPeligrosa.NombreMascota = mascota.Nombre;
                    mascotaPeligrosa.SexoMascota = mascota.Sexo == 1 ? "Hembra" : "Macho";
                    mascotaPeligrosa.RazaMascota = raza.Descripcion;
                    mascotaPeligrosa.PelajeMascota = mascota.Pelaje;
                    mascotaPeligrosa.CodigoDim = mascota.MascotaID;
                    mascotaPeligrosa.FechaDeNacimientoMascota = mascota.FechaDeNacimiento.Value;
                    mascotaPeligrosa.FechaVerificacionMascota = mascota.FechaValidacion;
                    mascotaPeligrosa.Especie = raza.EspecieID;
                    
                    model.listaMascotaPeligrosas.Add(mascotaPeligrosa);
                                  
                }
            
            }

            return View(model);
        }

        public ActionResult Campania()
        {
            CampaniasModel model = new CampaniasModel();
            DimEntidades2 context = new DimEntidades2();
            var campanias = context.Campania.ToList();
            foreach (var campania in campanias) {
                CampaniaModel campaniaAMostrar = new CampaniaModel();
                campaniaAMostrar.Campania = campania;
                campaniaAMostrar.Direccion = context.Direccion.ToList().Find(x => x.CampaniaID == campania.CampaniaID);
                campaniaAMostrar.RazasPermitidas = String.Join(", ", campania.Raza.Select(x => x.Descripcion));
                model.Campanias.Add(campaniaAMostrar); 
            }

            return View(model);

        }

        public ActionResult AdminHome()
        {
            return View();
        }

        public ActionResult Veterinaria()
        {
            VeterinariasModel model = new VeterinariasModel();
            DimEntidades2 context = new DimEntidades2();
            var veterinarias = context.Veterinario.ToList();
            var usuarios = context.Usuarios.ToList();
            foreach (var veterinario in veterinarias) {
                VeterinariaModel veterinariaAMostrar = new VeterinariaModel();
                var usuario = usuarios.Where(x => x.UsuarioID == veterinario.VeterinarioID).FirstOrDefault();
                veterinariaAMostrar.UsuarioID = veterinario.VeterinarioID;
                veterinariaAMostrar.FechaDeAlta = usuario.FechaAlta;
                veterinariaAMostrar.Nombre = usuario.Nombre;
                veterinariaAMostrar.Apellido = usuario.Apellido;
                veterinariaAMostrar.Email = usuario.Email;
                veterinariaAMostrar.NumeroDocumento = usuario.NumeroDocumento;
                veterinariaAMostrar.NumeroMatricula = veterinario.NumeroMatricula;
                veterinariaAMostrar.Telefono = usuario.Telefono;
                veterinariaAMostrar.FechaDeVerificacionMatricula = veterinario.FechaVerificacionMatricula;
                model.ListaVeterinaria.Add(veterinariaAMostrar);
            }

            return View(model);
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
            string calle, int numero, Int16? piso, string departamento, string localidad, string provincia)
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

        public JsonResult EliminarCampania(long idCampania) {

            string resultado = null;

            try {

                DimEntidades2 context = new DimEntidades2();
                Direccion direccion = context.Direccion.Where(x => x.CampaniaID == idCampania).FirstOrDefault();
                Campania campania = context.Campania.Where(x => x.CampaniaID == idCampania).FirstOrDefault();
                context.Direccion.Remove(direccion);
                context.Campania.Where(x => x.CampaniaID == campania.CampaniaID).FirstOrDefault().Raza.Clear();
                context.Campania.Remove(campania);
                context.SaveChanges();
                resultado = "OK";

            } catch(Exception ex) {

                return Json(new { Respuesta = ex.Message });
            }

            return Json(new { Respuesta = resultado });
        }

        public JsonResult VerificarVeterinario(int usuarioID) {

            string resultado = null;
            DimEntidades2 context = new DimEntidades2();

            var veterinarias = context.Veterinario.ToList();

            var veterinarioVerificado = veterinarias.Find(x => x.VeterinarioID == usuarioID);
            if (veterinarioVerificado != null)
            {
                veterinarioVerificado.FechaVerificacionMatricula = DateTime.Now.Date;
                resultado = "OK";
                context.SaveChanges();

            }
            else {
                resultado = "Veterinario no encontrado";            
            }

            return Json(new { Respuesta = resultado });
        }

        public JsonResult ValidarMascotaPeligrosa(long mascotaID) {

            string resultado = null;
            DimEntidades2 context = new DimEntidades2();

            var mascotas = context.Mascota.ToList();

            var aascotaVerificada = mascotas.Find(x => x.MascotaID == mascotaID);
            if (aascotaVerificada != null)
            {
                aascotaVerificada.FechaValidacion = DateTime.Now.Date;
                resultado = "OK";
                context.SaveChanges();

            }
            else
            {
                resultado = "Mascota no encontrada";
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