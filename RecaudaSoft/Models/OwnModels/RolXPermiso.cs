namespace RecaudaSoft.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel;

    [MetadataType(typeof(RolXPermisoMetaData))]
    public partial class RolXPermiso { }

    public class RolXPermisoMetaData
    {
        [DisplayName("Id")]
        public int idRolXPermiso { get; set; }
        [DisplayName("Id Rol")]
        public int idRol { get; set; }
        [DisplayName("Id Permiso")]
        public int idPermiso { get; set; }

        [DisplayName("Permiso")]
        public virtual Permiso Permiso { get; set; }
        [DisplayName("Rol")]
        public virtual Rol Rol { get; set; }
    }
}
