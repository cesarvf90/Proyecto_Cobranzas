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
        [DisplayName("Acreedores")]
        public Nullable<int> idAcreedor { get; set; }
        [DisplayName("ID Gestor")]
        public Nullable<int> idGestor { get; set; }
        [DisplayName("ID Rol")]
        public int idRol { get; set; }
        [DisplayName("Nombre usuario")]
        public string nombreUsuario { get; set; }
        [DisplayName("Contraseña")]
        public string contrasena { get; set; }
        [DisplayName("Tipo")]
        public int tipoUsuario { get; set; }
        [DisplayName("Estado")]
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
