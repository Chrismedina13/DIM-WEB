//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DIM_WEB.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Fallecimiento
    {
        public long MascotaID { get; set; }
        public string Lugar { get; set; }
        public string EspecificacionRiesgoEpidemiologico { get; set; }
        public System.DateTime Fecha { get; set; }
        public string Causa { get; set; }
        public byte RiesgoEpidemiologico { get; set; }
        public Nullable<int> RenglonVisita { get; set; }
        public string Modo { get; set; }
        public string Certificado { get; set; }
    
        public virtual Mascota Mascota { get; set; }
        public virtual VeterinarioMascota VeterinarioMascota { get; set; }
    }
}
