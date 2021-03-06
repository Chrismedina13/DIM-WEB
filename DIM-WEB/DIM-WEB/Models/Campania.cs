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
    
    public partial class Campania
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Campania()
        {
            this.Direccion = new HashSet<Direccion>();
            this.Mascota = new HashSet<Mascota>();
            this.Raza = new HashSet<Raza>();
        }
    
        public long CampaniaID { get; set; }
        public decimal CuposDisponibles { get; set; }
        public string Descripcion { get; set; }
        public short Tipo { get; set; }
        public string Nombre { get; set; }
        public string Contacto { get; set; }
        public int UsuarioID { get; set; }
        public System.DateTime FechaCreacion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Direccion> Direccion { get; set; }
        public virtual Usuarios Usuarios { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Mascota> Mascota { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Raza> Raza { get; set; }
    }
}
