using System.ComponentModel;

namespace RecaudaSoft.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(RolMetaData))]
    public partial class Rol { }

    public class RolMetaData
    {
        [DisplayName("ID Rol")]
        public int idRol { get; set; }
        [DisplayName("Nombre")]
        public string nombre { get; set; }
        [DisplayName("Descripción")]
        public string descripcion { get; set; }
        [DisplayName("Estado")]
        public int estado { get; set; }
        [DisplayName("Usuarios")]
        public virtual ICollection<Usuario> Usuarios { get; set; }
        [DisplayName("Permisos")]
        public virtual ICollection<Permiso> Permisoes { get; set; }
    }
}
