﻿//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RecaudaSoft.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CobranzasEntities : DbContext
    {
        public CobranzasEntities()
            : base("name=CobranzasEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Acreedor> Acreedors { get; set; }
        public DbSet<Actividad> Actividads { get; set; }
        public DbSet<CalificacionDato> CalificacionDatoes { get; set; }
        public DbSet<Cartera> Carteras { get; set; }
        public DbSet<Cuota> Cuotas { get; set; }
        public DbSet<DatoDeudor> DatoDeudors { get; set; }
        public DbSet<DatoGestor> DatoGestors { get; set; }
        public DbSet<Deuda> Deudas { get; set; }
        public DbSet<Deudor> Deudors { get; set; }
        public DbSet<Gestor> Gestors { get; set; }
        public DbSet<GestorXDeuda> GestorXDeudas { get; set; }
        public DbSet<Parametro> Parametroes { get; set; }
        public DbSet<Permiso> Permisoes { get; set; }
        public DbSet<PoliticaCobranza> PoliticaCobranzas { get; set; }
        public DbSet<PoliticaCobranzaXTipoActividad> PoliticaCobranzaXTipoActividads { get; set; }
        public DbSet<Refinanciacion> Refinanciacions { get; set; }
        public DbSet<Rol> Rols { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<TipoActividad> TipoActividads { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
