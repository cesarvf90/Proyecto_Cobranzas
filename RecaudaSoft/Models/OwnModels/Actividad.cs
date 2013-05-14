using System.ComponentModel;

namespace RecaudaSoft.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(ActividadMetaData))]
    public partial class Actividad { }

    public class ActividadMetaData
    {
        [DisplayName("Id")]
        public int idActividad { get; set; }
        [DisplayName("Id Tipo Actividad")]
        public int idTipoActividad { get; set; }
        [DisplayName("Id Deuda")]
        public int idDeuda { get; set; }
        [DisplayName("Id Gestor")]
        public int idGestor { get; set; }
        [DisplayName("Id Resultado")]
        public int idResultado { get; set; }
        [DisplayName("Fecha")]
        public System.DateTime fecha { get; set; }
        [DisplayName("Detalles")]
        public string detalles { get; set; }
        [DisplayName("Detalles")]
        public virtual Deuda Deuda { get; set; }
        [DisplayName("Tipo Actividad")]
        public virtual TipoActividad TipoActividad { get; set; }
        [DisplayName("Refinanciaciones")]
        public virtual ICollection<Refinanciacion> Refinanciacions { get; set; }
    }
}
