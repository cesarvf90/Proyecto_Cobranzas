//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

using System.ComponentModel;

namespace RecaudaSoft.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CalificacionDato
    {
        [DisplayName("Id")]
        public int idCalificacion { get; set; }
        [DisplayName("Id Dato")]
        public int idDato { get; set; }
        [DisplayName("Valor calificación")]
        public decimal valorCalificacion { get; set; }
        [DisplayName("Valor")]
        public string valorDato { get; set; }
        [DisplayName("Valor mínimo")]
        public Nullable<decimal> valorDatoMinimo { get; set; }
        [DisplayName("Valor máximo")]
        public Nullable<decimal> valorDatoMaximo { get; set; }
        [DisplayName("Dato")]
        public virtual Dato Dato { get; set; }
    }
}
