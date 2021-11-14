using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DIM_WEB.Models
{
    public class MascotaPeligrosaModel
    {
        public MascotaPeligrosaModel() { 
        
        }

        public long CodigoDim { get; set; }
        public String NombreMascota { get; set; }
        public String Especie { get; set; }
        public String RazaMascota { get; set; }
        public String SexoMascota { get; set; }
        public String PelajeMascota { get; set; }
        public DateTime FechaDeNacimientoMascota { get; set; }
        public String NombreDueño { get; set; }
        public String ApellidoDueño { get; set; }
        public DateTime? FechaVerificacionMascota { get; set; }

    }
}