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
    
    public partial class GestorXDeuda
    {
        public int idGestorXDeuda { get; set; }
        public int idGestor { get; set; }
        public int idDeuda { get; set; }
        public System.DateTime fechaAsignacion { get; set; }
        public int exito { get; set; }

        public virtual Deuda Deuda { get; set; }
        public virtual Gestor Gestor { get; set; }
    }
}
