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
    
    public partial class Acreedor
    {
        public Acreedor()
        {
            this.Carteras = new HashSet<Cartera>();
            this.Usuarios = new HashSet<Usuario>();
        }
    
        public int idAcreedor { get; set; }
        public string nombre { get; set; }
        public string razonSocial { get; set; }
        public string ruc { get; set; }
        public string direccion { get; set; }
        public int rubro { get; set; }
        public string telefono { get; set; }
    
        public virtual ICollection<Cartera> Carteras { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
