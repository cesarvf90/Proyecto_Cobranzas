namespace RecaudaSoft.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(DeudorMetaData))]
    public partial class Deudor { }

    public class DeudorMetaData
    {
        [DisplayName("Id")]
        public int idDeudor { get; set; }
        [DisplayName("Nombres")]
        public string nombres { get; set; }
        [DisplayName("Apellido Paterno")]
        public string apellidoPaterno { get; set; }
        [DisplayName("Apellido Materno")]
        public string apellidoMaterno { get; set; }
        [DisplayName("Tipo de documento")]
        public int tipoDocumento { get; set; }
        [DisplayName("Número de documento")]
        public string numeroDocumneto { get; set; }
        [DisplayName("Teléfono personal")]
        public string telefonoPersonal { get; set; }
        [DisplayName("Teléfono de domicilio")]
        public string telefonoDomicilio { get; set; }
        [DisplayName("Teléfono de trabajo")]
        public string telefonoTrabajo { get; set; }
        [DisplayName("Correo electrónico")]
        public string correo { get; set; }
        [DisplayName("Dirección")]
        public string direccion { get; set; }
        [DisplayName("Posee trabajo")]
        public Nullable<int> poseeTrabajo { get; set; }
        [DisplayName("Fecha de nacimiento")]
        public System.DateTime fechaNacimiento { get; set; }
        [DisplayName("Número total de deudas")]
        public int numeroTotalDeudas { get; set; }
        [DisplayName("Total adeudado")]
        public decimal totalAdeudado { get; set; }
        [DisplayName("Estado civil")]
        public Nullable<int> estadoCivil { get; set; }
        [DisplayName("Número de hijos")]
        public Nullable<int> numeroHijos { get; set; }
        [DisplayName("Sexo")]
        public Nullable<int> sexo { get; set; }
        [DisplayName("Detalles")]
        public string detalles { get; set; }
        
        [DisplayName("Deudas")]
        public virtual ICollection<Deuda> Deudas { get; set; }
        [DisplayName("Estado civil")]
        public virtual Parametro Parametro { get; set; }
        [DisplayName("Sexo")]
        public virtual Parametro Parametro1 { get; set; }
        [DisplayName("Tipo de documento")]
        public virtual Parametro Parametro2 { get; set; }
    }
}
