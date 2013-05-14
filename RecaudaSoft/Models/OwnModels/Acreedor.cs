using System.ComponentModel;

namespace RecaudaSoft.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
 
    [MetadataType(typeof(AcreedorMetaData))]
    public partial class Acreedor { }

    public class AcreedorMetaData {
        [DisplayName("Id")]
        public int idAcreedor { get; set; }
        [DisplayName("Nombre")]
        public string nombre { get; set; }
        [DisplayName("Razón social")]
        public string razonSocial { get; set; }
        [DisplayName("RUC")]
        public string ruc { get; set; }
        [DisplayName("Dirección")]
        public string direccion { get; set; }
        [DisplayName("Rubro")]
        public int rubro { get; set; }
        [DisplayName("Teléfono")]
        public string telefono { get; set; }

        [DisplayName("Carteras")]
        public virtual ICollection<Cartera> Carteras { get; set; }
        [DisplayName("Usuarios")]
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
