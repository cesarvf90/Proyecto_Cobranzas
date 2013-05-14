using System.ComponentModel;

namespace RecaudaSoft.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(CalificacionDatoMetaData))]
    public partial class CalificacionDato { }

    public class CalificacionDatoMetaData
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
