﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Campania> Campania { get; set; }
        public virtual DbSet<Direccion> Direccion { get; set; }
        public virtual DbSet<Especie> Especie { get; set; }
        public virtual DbSet<Fallecimiento> Fallecimiento { get; set; }
        public virtual DbSet<Mascota> Mascota { get; set; }
        public virtual DbSet<Medicamento> Medicamento { get; set; }
        public virtual DbSet<MedicamentosMascotas> MedicamentosMascotas { get; set; }
        public virtual DbSet<Raza> Raza { get; set; }
        public virtual DbSet<TipoVacuna> TipoVacuna { get; set; }
        public virtual DbSet<TipoVisita> TipoVisita { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<Vacunacion> Vacunacion { get; set; }
        public virtual DbSet<Veterinario> Veterinario { get; set; }
        public virtual DbSet<VeterinarioMascota> VeterinarioMascota { get; set; }
    }
}
