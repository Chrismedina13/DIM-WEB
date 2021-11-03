using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DIM_WEB.Models
{
    public class VeterinariaModel
    {
        public VeterinariaModel() { 
        
        }

        public int UsuarioID { get; set; }
        public DateTime FechaDeAlta { get; set; }
        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public String Email { get; set; }
        public decimal NumeroDocumento { get; set; }
        public decimal NumeroMatricula { get; set; }
        public DateTime? FechaDeVerificacionMatricula { get;  set; }
        public string Telefono { get; set; }
    }
}