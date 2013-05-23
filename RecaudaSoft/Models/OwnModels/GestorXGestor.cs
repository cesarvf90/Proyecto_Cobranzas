namespace RecaudaSoft.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel;

    [MetadataType(typeof(GestorXGestorMetaData))]
    public partial class GestorXGestor { }

    public class GestorXGestorMetaData
    {
        [DisplayName("Id")]
        public int idGestorXGestor { get; set; }
        [DisplayName("Id Gestor Supervisor")]
        public int idGestorSupervisor { get; set; }
        [DisplayName("Id Gestor Supervisado")]
        public int idGestorSupervisado { get; set; }

        [DisplayName("Gestor Supervisor")]
        public virtual Gestor Gestor { get; set; }
        [DisplayName("Gestor Supervisado")]
        public virtual Gestor Gestor1 { get; set; }
    }
}
