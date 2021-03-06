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
    
    public partial class Mascota
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Mascota()
        {
            this.Direccion = new HashSet<Direccion>();
            this.VeterinarioMascota = new HashSet<VeterinarioMascota>();
            this.Vacunacion = new HashSet<Vacunacion>();
            this.MedicamentosMascotas = new HashSet<MedicamentosMascotas>();
            this.Campania = new HashSet<Campania>();
        }
    
        public long MascotaID { get; set; }
        public string ImagenChapita { get; set; }
        public Nullable<int> Peso { get; set; }
        public string Imagen { get; set; }
        public Nullable<System.DateTime> FechaDeNacimiento { get; set; }
        public Nullable<System.DateTime> FechaValidacion { get; set; }
        public string NroIdentificadorCriadero { get; set; }
        public string CodigoDeChip { get; set; }
        public string DIeta { get; set; }
        public string OtrosMedicamentos { get; set; }
        public string Pelaje { get; set; }
        public short Sexo { get; set; }
        public short CondicionDeSalud { get; set; }
        public string OtrosDatosDeSalud { get; set; }
        public short Tamanio { get; set; }
        public string CertificadoAntirrabica { get; set; }
        public string SeguroResponsabilidadCivil { get; set; }
        public string Nombre { get; set; }
        public int UsuarioID { get; set; }
        public string RazaID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Direccion> Direccion { get; set; }
        public virtual Fallecimiento Fallecimiento { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VeterinarioMascota> VeterinarioMascota { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vacunacion> Vacunacion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MedicamentosMascotas> MedicamentosMascotas { get; set; }
        public virtual Raza Raza { get; set; }
        public virtual Usuarios Usuarios { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Campania> Campania { get; set; }
    }
}
