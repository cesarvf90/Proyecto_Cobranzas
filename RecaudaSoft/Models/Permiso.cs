//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    using System.ComponentModel;
    
    public partial class Permiso
    {
        public Permiso()
        {
            this.Rols = new HashSet<Rol>();
        }

        [DisplayName("Id")]
        public int idPermiso { get; set; }
        [DisplayName("Nombre")]
        public string nombre { get; set; }
        [DisplayName("Funcionalidad")]
        public string funcionalidad { get; set; }
        [DisplayName("Descripción")]    
        public string descripcion { get; set; }

        [DisplayName("Roles")]
        public virtual ICollection<Rol> Rols { get; set; }
    }
}
