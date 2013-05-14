namespace RecaudaSoft.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(TipoActividadMetaData))]
    public partial class TipoActividad { }

    public class TipoActividadMetaData
    {
        [DisplayName("Id")]            
        public int idTipoActividad { get; set; }
        [DisplayName("Nombre")]
        public string nombre { get; set; }
        [DisplayName("Descripción")]
        public string descripcion { get; set; }

        [DisplayName("Actividades")]
        public virtual ICollection<Actividad> Actividads { get; set; }
        [DisplayName("Política de Cobranza")]
        public virtual ICollection<PoliticaCobranzaXTipoActividad> PoliticaCobranzaXTipoActividads { get; set; }
    }
}
