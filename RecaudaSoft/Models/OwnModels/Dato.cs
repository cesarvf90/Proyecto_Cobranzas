namespace RecaudaSoft.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(DatoMetaData))]
    public partial class Dato { }

    public class DatoMetaData 
    {
        [DisplayName("Id")]
        public int idDato { get; set; }
        [DisplayName("Tipo")]
        public string tipo { get; set; }
        [DisplayName("Nombre")]
        public string nombre { get; set; }
        [DisplayName("Calificaciones del dato")]
        public virtual ICollection<CalificacionDato> CalificacionDatoes { get; set; }
    }
}
