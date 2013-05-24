namespace RecaudaSoft.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(GestorXDeudaMetaData))]
    public partial class GestorXDeuda { }

    public class GestorXDeudaMetaData
    {
        [DisplayName("Id")]
        public int idGestorXDeuda { get; set; }
        [DisplayName("Id Gestor")]
        public int idGestor { get; set; }
        [DisplayName("Id deuda")]
        public int idDeuda { get; set; }
        [DisplayName("Fecha de asignación")]
        public System.DateTime fechaAsignacion { get; set; }
        [DisplayName("Éxito")]
        public int exito { get; set; }

        [DisplayName("Deuda")]
        public virtual Deuda Deuda { get; set; }
        [DisplayName("Gestor")]
        public virtual Gestor Gestor { get; set; }
    }
}
