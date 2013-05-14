using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RecaudaSoft.Models
{
    using System;
    using System.Collections.Generic;

    [MetadataType(typeof(CarteraMetaData))]
    public partial class Cartera { }

    public class CarteraMetaData
    {
        [DisplayName("Id")]
        public int idCartera { get; set; }
        [DisplayName("Id Acreedor")]
        public int idAcreedor { get; set; }
        [DisplayName("Nombre")]
        public string nombre { get; set; }
        [DisplayName("Tipo")]
        public int esVencida { get; set; }
        [DisplayName("Porcentaje ganancia")]
        public int porcentajeGanancia { get; set; }
        [DisplayName("Detalles")]
        public string detalles { get; set; }
        [DisplayName("Cantidad de deudas")]
        public int cantidadDeudas { get; set; }

        [DisplayName("Acreedor")]
        public virtual Acreedor Acreedor { get; set; }
        [DisplayName("Deudas")]
        public virtual ICollection<Deuda> Deudas { get; set; }
        [DisplayName("Políticas de Cobranza")]
        public virtual ICollection<PoliticaCobranza> PoliticaCobranzas { get; set; }
    }
}
