namespace RecaudaSoft.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(PermisoMetaData))]
    public partial class Permiso { }

    public class PermisoMetaData
    {
        [DisplayName("Id")]
        public int idPermiso { get; set; }
        [DisplayName("Nombre")]
        public string nombre { get; set; }
        [DisplayName("Funcionalidad")]
        public string funcionalidad { get; set; }
        [DisplayName("Descripción")]    
        public string descripcion { get; set; }

        [DisplayName("Roles")]
        public virtual ICollection<Rol> Rols { get; set; }
    }
}
