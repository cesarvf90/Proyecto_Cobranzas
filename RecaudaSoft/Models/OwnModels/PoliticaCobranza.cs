namespace RecaudaSoft.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(PoliticaCobranzaMetaData))]
    public partial class PoliticaCobranza { }

    public class PoliticaCobranzaMetaData
    {
        [DisplayName("Id")]
        public int idPoliticaCobranza { get; set; }
        [DisplayName("Id Cartera")]
        public int idCartera { get; set; }
        [DisplayName("Nombre")]
        public string nombre { get; set; }
        [DisplayName("Descripción")]
        public string descripcion { get; set; }
        [DisplayName("Obligatoria")]
        public int obligatoria { get; set; }
        [DisplayName("Interés refinanciación")]
        public Nullable<decimal> interesRefinanciacion { get; set; }
        [DisplayName("Máximo cuotas de refinanciación")]
        public Nullable<int> maximoCuotasRefinanciacion { get; set; }

        [DisplayName("Cartera")]
        public virtual Cartera Cartera { get; set; }
        [DisplayName("Tipos de actividades")]
        public virtual ICollection<PoliticaCobranzaXTipoActividad> PoliticaCobranzaXTipoActividads { get; set; }
    }
}
