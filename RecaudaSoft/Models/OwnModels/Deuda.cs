namespace RecaudaSoft.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(DeudaMetaData))]
    public partial class Deuda { }

    public class DeudaMetaData
    {
        [DisplayName("Id")]
        public int idDeuda { get; set; }
        [DisplayName("Id Deudor")]
        public int idDeudor { get; set; }
        [DisplayName("Id Producto deuda")]
        public int idProducto { get; set; }
        [DisplayName("Id Cartera")]
        public int idCartera { get; set; }
        [DisplayName("Monto")]
        public decimal monto { get; set; }
        [DisplayName("Fecha inicio")]
        public Nullable<System.DateTime> fechaInicio { get; set; }
        [DisplayName("Moneda")]
        public int moneda { get; set; }
        [DisplayName("Tipo")]
        public int esCuota { get; set; }
        [DisplayName("Dificultad")]
        public Nullable<int> dificultad { get; set; }
        [DisplayName("Pagada")]
        public int pagada { get; set; }
        [DisplayName("Monto pagado")]
        public Nullable<decimal> montoPagado { get; set; }

        [DisplayName("Actividades")]
        public virtual ICollection<Actividad> Actividads { get; set; }
        [DisplayName("Cartera")]
        public virtual Cartera Cartera { get; set; }
        [DisplayName("Deudor")]
        public virtual Deudor Deudor { get; set; }
        [DisplayName("Moneda")]
        public virtual Parametro Parametro { get; set; }
        [DisplayName("Gestores asignados")]
        public virtual ICollection<GestorXDeuda> GestorXDeudas { get; set; }
        [DisplayName("Refinanciaciones")]
        public virtual ICollection<Refinanciacion> Refinanciacions { get; set; }
    }
}
