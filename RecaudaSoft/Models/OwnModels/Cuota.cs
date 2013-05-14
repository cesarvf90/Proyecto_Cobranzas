using System.ComponentModel;

namespace RecaudaSoft.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(CuotaMetaData))]
    public partial class Cuota { }

    public class CuotaMetaData
    {
        [DisplayName("Id")]
        public int idCuota { get; set; }
        [DisplayName("Id Refinanciación")]
        public int idRefinanciacion { get; set; }
        [DisplayName("Fecha pactada")]
        public System.DateTime fechaPactada { get; set; }
        [DisplayName("Fecha de pago")]
        public Nullable<System.DateTime> fechaPago { get; set; }
        [DisplayName("Refinanciación")]
        public virtual Refinanciacion Refinanciacion { get; set; }
    }
}
