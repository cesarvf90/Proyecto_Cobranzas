namespace RecaudaSoft.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(GestorMetaData))]
    public partial class Gestor { }

    public class GestorMetaData
    {
        [DisplayName("Id")]
        public int idGestor { get; set; }
        [DisplayName("Id Nivel Gestor")]
        public int idNivelGestor { get; set; }
        [DisplayName("Id Tipo Gestor")]
        public int idTipoGestor { get; set; }
        [DisplayName("Nombres")]
        public string nombres { get; set; }
        [DisplayName("Apellido paterno")]
        public string apellidoPaterno { get; set; }
        [DisplayName("Apellido materno")]
        public string apellidoMaterno { get; set; }
        [DisplayName("Fecha de ingreso")]
        public System.DateTime fechaIngreso { get; set; }
        [DisplayName("Deudas recuperadas")]
        public Nullable<int> deudasRecuperadas { get; set; }
        [DisplayName("Disponible")]
        public int disponible { get; set; }
        [DisplayName("Tipo de documento")]
        public int tipoDocumento { get; set; }
        [DisplayName("Número de documento")]
        public string numeroDocumento { get; set; }

        [DisplayName("Nivel")]
        public virtual Parametro Parametro { get; set; }
        [DisplayName("Tipo de documento")]
        public virtual Parametro Parametro1 { get; set; }
        [DisplayName("Tipo")]
        public virtual Parametro Parametro2 { get; set; }
        [DisplayName("Deudas asignadas")]
        public virtual ICollection<GestorXDeuda> GestorXDeudas { get; set; }
        [DisplayName("Usuarios")]
        public virtual ICollection<Usuario> Usuarios { get; set; }
        [DisplayName("Jefe")]
        public virtual ICollection<Gestor> Gestor1 { get; set; }
        [DisplayName("Gestores asignados")]
        public virtual ICollection<Gestor> Gestors { get; set; }

        /*
        [DisplayName("Nivel")]
        public virtual Parametro NivelGestor { 
        get {
            return Parametro;
            } 
        set {
            Parametro = value;
            }
        }
        [DisplayName("Tipo de documento")]
        public virtual Parametro TipoDocumento { 
        get {
            return Parametro1;
            } 
        set {
            Parametro1 = value;
            }
        }
        [DisplayName("Tipo")]
        public virtual Parametro TipoGestor { 
        get {
            return Parametro2;
            } 
        set {
            Parametro2 = value;
            }
        }
         * */
    }
}
