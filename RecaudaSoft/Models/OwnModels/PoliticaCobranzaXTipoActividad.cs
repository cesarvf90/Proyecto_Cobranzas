namespace RecaudaSoft.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(PoliticaCobranzaXTipoActividadMetaData))]
    public partial class PoliticaCobranzaXTipoActividad { }

    public class PoliticaCobranzaXTipoActividadMetaData
    {
        [DisplayName("Id Política de Cobranza")]
        public int idPoliticaCobranza { get; set; }
        [DisplayName("Id Tipo de actividad")]
        public int idTipoActividad { get; set; }
        [DisplayName("Paso N°")]
        public int numeroPaso { get; set; }
        [DisplayName("Fecha de inicio")]
        public System.DateTime fechaInicio { get; set; }
        [DisplayName("Fecha de fin")]
        public System.DateTime fechaFin { get; set; }

        [DisplayName("Política de cobranza")]
        public virtual PoliticaCobranza PoliticaCobranza { get; set; }
        [DisplayName("Tipo de Actividad")]
        public virtual TipoActividad TipoActividad { get; set; }
    }
}
