using System.ComponentModel;

namespace RecaudaSoft.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(UsuarioMetaData))]
    public partial class Usuario { }

    public class UsuarioMetaData
    {
        [DisplayName("Id")]
        public int idUsuario { get; set; }
        [DisplayName("Id Acreedor")]
        public Nullable<int> idAcreedor { get; set; }
        [DisplayName("Id Gestor")]
        public Nullable<int> idGestor { get; set; }
        [DisplayName("Id Rol")]
        public int idRol { get; set; }
        [DisplayName("Nombre usuario")]
        public string nombreUsuario { get; set; }
        [DisplayName("Contraseña")]
        public string contrasena { get; set; }
        /* 1: Gestor, 2: Acreedor*/
        [DisplayName("Tipo")]
        public int tipoUsuario { get; set; }
        [DisplayName("Estado")]
        /* 0: Inactivo, 1: Activo */
        public int estado { get; set; }
        [DisplayName("Correo electrónico")]
        public string correo { get; set; }
        [DisplayName("Acreedor")]
        public virtual Acreedor Acreedor { get; set; }
        [DisplayName("Colaborador")]
        public virtual Gestor Gestor { get; set; }
        [DisplayName("Rol")]
        public virtual Rol Rol { get; set; }
    }
}
