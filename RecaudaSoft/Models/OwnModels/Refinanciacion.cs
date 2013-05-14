namespace RecaudaSoft.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(RefinanciacionMetaData))]
    public partial class Refinanciacion { }

    public class RefinanciacionMetaData
    {
        [DisplayName("Id")]
        public int idRefinanciacion { get; set; }
        [DisplayName("Id Actividad")]
        public int idActividad { get; set; }
        [DisplayName("Id Deuda")]
        public int idDeuda { get; set; }
        [DisplayName("Número de cuotas")]
        public int numeroCuotas { get; set; }
        [DisplayName("Monto de cuota")]
        public decimal montoCuota { get; set; }
        [DisplayName("Moneda")]
        public int moneda { get; set; }
        [DisplayName("Fecha de refinanciación")]
        public System.DateTime fechaRefinanciacion { get; set; }
        [DisplayName("Periodicidad (Meses)")]
        public int periodicidadMeses { get; set; }
        [DisplayName("Tasa de Interés")]
        public decimal interes { get; set; }

        [DisplayName("Actividad")]
        public virtual Actividad Actividad { get; set; }
        [DisplayName("Cuotas")]
        public virtual ICollection<Cuota> Cuotas { get; set; }
        [DisplayName("Deuda")]
        public virtual Deuda Deuda { get; set; }
    }
}
